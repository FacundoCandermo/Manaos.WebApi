using AutoMapper;
using Manaos.Application;
using Manaos.Application.Dtos.OrdenCompra;
using Manaos.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Manaos.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenesCompraController : ControllerBase
    {
        private readonly ILogger<OrdenesCompraController> _logger;
        private readonly IApplication<OrdenCompra> _ordenCompra;
        private readonly IMapper _mapper;
        public OrdenesCompraController(
            ILogger<OrdenesCompraController> logger
            , IApplication<OrdenCompra> ordenCompra
            , IMapper mapper)
        {
            _logger = logger;
            _ordenCompra = ordenCompra;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> All()
        {
            return Ok(_mapper.Map<IList<OrdenCompraResponseDto>>(_ordenCompra.GetAll()));
        }

        [HttpGet]
        [Route("ById")]
        public async Task<IActionResult> ById(int? Id)
        {
            if (!Id.HasValue)
            {
                return BadRequest();
            }
            OrdenCompra ordenCompra = _ordenCompra.GetById(Id.Value);
            if (ordenCompra is null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<OrdenCompraResponseDto>(ordenCompra));
        }

        [HttpPost]
        public async Task<IActionResult> Crear(OrdenCompraRequestDto ordenCompraRequestDto)
        {
            if (!ModelState.IsValid)
            { return BadRequest(); }
            var ordenCompra = _mapper.Map<OrdenCompra>(ordenCompraRequestDto);
            _ordenCompra.Save(ordenCompra);
            return Ok(ordenCompra.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Editar(int? Id, OrdenCompraRequestDto ordenCompraRequestDto)
        {
            if (!Id.HasValue)
            { return BadRequest(); }
            if (!ModelState.IsValid)
            { return BadRequest(); }
            var ordenCompra = _ordenCompra.GetById(Id.Value);
            if (ordenCompra is null)
            { return NotFound(); }
            ordenCompra = _mapper.Map<OrdenCompra>(ordenCompraRequestDto);
            _ordenCompra.Save(ordenCompra);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Borrar(int? Id)
        {
            if (!Id.HasValue)
            { return BadRequest(); }
            if (!ModelState.IsValid)
            { return BadRequest(); }
            var ordenCompra = _ordenCompra.GetById(Id.Value);
            if (ordenCompra is null)
            { return NotFound(); }
            _ordenCompra.Delete(ordenCompra.Id);
            return Ok();
        }
    }
}
