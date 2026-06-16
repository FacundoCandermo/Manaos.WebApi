using AutoMapper;
using Manaos.Application;
using Manaos.Application.Dtos.DetalleOrdenCompra;
using Manaos.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Manaos.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetallesOrdenesCompraController : ControllerBase
    {
        private readonly ILogger<DetallesOrdenesCompraController> _logger;
        private readonly IApplication<DetalleOrdenCompra> _detalleOrdenCompra;
        private readonly IMapper _mapper;
        public DetallesOrdenesCompraController(
            ILogger<DetallesOrdenesCompraController> logger
            , IApplication<DetalleOrdenCompra> detalleOrdenCompra
            , IMapper mapper)
        {
            _logger = logger;
            _detalleOrdenCompra = detalleOrdenCompra;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> All()
        {
            return Ok(_mapper.Map<IList<DetalleOrdenCompraResponseDto>>(_detalleOrdenCompra.GetAll()));
        }

        [HttpGet]
        [Route("ById")]
        public async Task<IActionResult> ById(int? Id)
        {
            if (!Id.HasValue)
            {
                return BadRequest();
            }
            DetalleOrdenCompra detalleOrdenCompra = _detalleOrdenCompra.GetById(Id.Value);
            if (detalleOrdenCompra is null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<DetalleOrdenCompraResponseDto>(detalleOrdenCompra));
        }

        [HttpPost]
        public async Task<IActionResult> Crear(DetalleOrdenCompraRequestDto detalleOrdenCompraRequestDto)
        {
            if (!ModelState.IsValid)
            { return BadRequest(); }
            var detalleOrdenCompra = _mapper.Map<DetalleOrdenCompra>(detalleOrdenCompraRequestDto);
            _detalleOrdenCompra.Save(detalleOrdenCompra);
            return Ok(detalleOrdenCompra.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Editar(int? Id, DetalleOrdenCompraRequestDto detalleOrdenCompraRequestDto)
        {
            if (!Id.HasValue)
            { return BadRequest(); }
            if (!ModelState.IsValid)
            { return BadRequest(); }
            var detalleOrdenCompra = _detalleOrdenCompra.GetById(Id.Value);
            if (detalleOrdenCompra is null)
            { return NotFound(); }
            detalleOrdenCompra = _mapper.Map<DetalleOrdenCompra>(detalleOrdenCompraRequestDto);
            _detalleOrdenCompra.Save(detalleOrdenCompra);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Borrar(int? Id)
        {
            if (!Id.HasValue)
            { return BadRequest(); }
            if (!ModelState.IsValid)
            { return BadRequest(); }
            var detalleOrdenCompra = _detalleOrdenCompra.GetById(Id.Value);
            if (detalleOrdenCompra is null)
            { return NotFound(); }
            _detalleOrdenCompra.Delete(detalleOrdenCompra.Id);
            return Ok();
        }
    }
}
