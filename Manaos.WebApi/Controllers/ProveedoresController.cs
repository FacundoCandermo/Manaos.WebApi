using AutoMapper;
using Manaos.Application;
using Manaos.Application.Dtos.Proveedor;
using Manaos.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Manaos.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedoresController : ControllerBase
    {
        private readonly ILogger<ProveedoresController> _logger;
        private readonly IApplication<Proveedor> _proveedor;
        private readonly IMapper _mapper;
        public ProveedoresController(
            ILogger<ProveedoresController> logger
            , IApplication<Proveedor> proveedor
            , IMapper mapper)
        {
            _logger = logger;
            _proveedor = proveedor;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> All()
        {
            return Ok(_mapper.Map<IList<ProveedorResponseDto>>(_proveedor.GetAll()));
        }

        [HttpGet]
        [Route("ById")]
        public async Task<IActionResult> ById(int? Id)
        {
            if (!Id.HasValue)
            {
                return BadRequest();
            }
            Proveedor proveedor = _proveedor.GetById(Id.Value);
            if (proveedor is null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ProveedorResponseDto>(proveedor));
        }

        [HttpPost]
        public async Task<IActionResult> Crear(ProveedorRequestDto proveedorRequestDto)
        {
            if (!ModelState.IsValid)
            { return BadRequest(); }
            var proveedor = _mapper.Map<Proveedor>(proveedorRequestDto);
            _proveedor.Save(proveedor);
            return Ok(proveedor.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Editar(int? Id, ProveedorRequestDto proveedorRequestDto)
        {
            if (!Id.HasValue)
            { return BadRequest(); }
            if (!ModelState.IsValid)
            { return BadRequest(); }
            var proveedor = _proveedor.GetById(Id.Value);
            if (proveedor is null)
            { return NotFound(); }
            proveedor = _mapper.Map<Proveedor>(proveedorRequestDto);
            _proveedor.Save(proveedor);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Borrar(int? Id)
        {
            if (!Id.HasValue)
            { return BadRequest(); }
            if (!ModelState.IsValid)
            { return BadRequest(); }
            var proveedor = _proveedor.GetById(Id.Value);
            if (proveedor is null)
            { return NotFound(); }
            _proveedor.Delete(proveedor.Id);
            return Ok();
        }
    }
}
