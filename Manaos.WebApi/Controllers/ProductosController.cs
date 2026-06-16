using AutoMapper;
using Manaos.Application;
using Manaos.Application.Dtos.Producto;
using Manaos.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Manaos.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly ILogger<ProductosController> _logger;
        private readonly IApplication<Producto> _producto;
        private readonly IMapper _mapper;
        public ProductosController(
            ILogger<ProductosController> logger
            , IApplication<Producto> producto
            , IMapper mapper)
        {
            _logger = logger;
            _producto = producto;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> All()
        {
            return Ok(_mapper.Map<IList<ProductoResponseDto>>(_producto.GetAll()));
        }

        [HttpGet]
        [Route("ById")]
        public async Task<IActionResult> ById(int? Id)
        {
            if (!Id.HasValue)
            {
                return BadRequest();
            }
            Producto producto = _producto.GetById(Id.Value);
            if (producto is null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ProductoResponseDto>(producto));
        }

        [HttpPost]
        public async Task<IActionResult> Crear(ProductoRequestDto productoRequestDto)
        {
            if (!ModelState.IsValid)
            { return BadRequest(); }
            var producto = _mapper.Map<Producto>(productoRequestDto);
            _producto.Save(producto);
            return Ok(producto.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Editar(int? Id, ProductoRequestDto productoRequestDto)
        {
            if (!Id.HasValue)
            { return BadRequest(); }
            if (!ModelState.IsValid)
            { return BadRequest(); }
            Producto productoBack = _producto.GetById(Id.Value);
            if (productoBack is null)
            { return NotFound(); }
            productoBack = _mapper.Map<Producto>(productoRequestDto);
            _producto.Save(productoBack);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Borrar(int? Id)
        {
            if (!Id.HasValue)
            { return BadRequest(); }
            if (!ModelState.IsValid)
            { return BadRequest(); }
            Producto productoBack = _producto.GetById(Id.Value);
            if (productoBack is null)
            { return NotFound(); }
            _producto.Delete(productoBack.Id);
            return Ok();
        }
    }
}
