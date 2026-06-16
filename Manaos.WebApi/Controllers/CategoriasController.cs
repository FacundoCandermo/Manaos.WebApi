using AutoMapper;
using Manaos.Application;
using Manaos.Application.Dtos.CategoriaProducto;
using Manaos.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Manaos.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ILogger<CategoriasController> _logger;
        private readonly IApplication<CategoriaProducto> _categoria;
        private readonly IMapper _mapper;
        public CategoriasController(
            ILogger<CategoriasController> logger
            , IApplication<CategoriaProducto> categoria
            , IMapper mapper)
        {
            _logger = logger;
            _categoria = categoria;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> All()
        {
            return Ok(_mapper.Map<IList<CategoriaProductoResponseDto>>(_categoria.GetAll()));
        }

        [HttpGet]
        [Route("ById")]
        public async Task<IActionResult> ById(int? Id)
        {
            if (!Id.HasValue)
            {
                return BadRequest();
            }
            CategoriaProducto categoria = _categoria.GetById(Id.Value);
            if (categoria is null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<CategoriaProductoResponseDto>(categoria));
        }

        [HttpPost]
        public async Task<IActionResult> Crear(CategoriaProductoRequestDto categoriaRequestDto)
        {
            if (!ModelState.IsValid)
            { return BadRequest(); }
            var categoria = _mapper.Map<CategoriaProducto>(categoriaRequestDto);
            _categoria.Save(categoria);
            return Ok(categoria.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Editar(int? Id, CategoriaProductoRequestDto categoriaRequestDto)
        {
            if (!Id.HasValue)
            { return BadRequest(); }
            if (!ModelState.IsValid)
            { return BadRequest(); }
            CategoriaProducto categoriaBack = _categoria.GetById(Id.Value);
            if (categoriaBack is null)
            { return NotFound(); }
            categoriaBack = _mapper.Map<CategoriaProducto>(categoriaRequestDto);
            _categoria.Save(categoriaBack);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Borrar(int? Id)
        {
            if (!Id.HasValue)
            { return BadRequest(); }
            if (!ModelState.IsValid)
            { return BadRequest(); }
            CategoriaProducto categoriaBack = _categoria.GetById(Id.Value);
            if (categoriaBack is null)
            { return NotFound(); }
            _categoria.Delete(categoriaBack.Id);
            return Ok();
        }
    }
}
