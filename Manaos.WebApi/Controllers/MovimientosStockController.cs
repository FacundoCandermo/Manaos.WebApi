using AutoMapper;
using Manaos.Application;
using Manaos.Application.Dtos.MovimientoStock;
using Manaos.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Manaos.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientosStockController : ControllerBase
    {
        private readonly ILogger<MovimientosStockController> _logger;
        private readonly IApplication<MovimientoStock> _movimientoStock;
        private readonly IMapper _mapper;
        public MovimientosStockController(
            ILogger<MovimientosStockController> logger
            , IApplication<MovimientoStock> movimientoStock
            , IMapper mapper)
        {
            _logger = logger;
            _movimientoStock = movimientoStock;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> All()
        {
            return Ok(_mapper.Map<IList<MovimientoStockResponseDto>>(_movimientoStock.GetAll()));
        }

        [HttpGet]
        [Route("ById")]
        public async Task<IActionResult> ById(int? Id)
        {
            if (!Id.HasValue)
            {
                return BadRequest();
            }
            MovimientoStock movimientoStock = _movimientoStock.GetById(Id.Value);
            if (movimientoStock is null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<MovimientoStockResponseDto>(movimientoStock));
        }

        [HttpPost]
        public async Task<IActionResult> Crear(MovimientoStockRequestDto movimientoStockRequestDto)
        {
            if (!ModelState.IsValid)
            { return BadRequest(); }
            var movimientoStock = _mapper.Map<MovimientoStock>(movimientoStockRequestDto);
            _movimientoStock.Save(movimientoStock);
            return Ok(movimientoStock.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Editar(int? Id, MovimientoStockRequestDto movimientoStockRequestDto)
        {
            if (!Id.HasValue)
            { return BadRequest(); }
            if (!ModelState.IsValid)
            { return BadRequest(); }
            var movimientoStock = _movimientoStock.GetById(Id.Value);
            if (movimientoStock is null)
            { return NotFound(); }
            movimientoStock = _mapper.Map<MovimientoStock>(movimientoStockRequestDto);
            _movimientoStock.Save(movimientoStock);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Borrar(int? Id)
        {
            if (!Id.HasValue)
            { return BadRequest(); }
            if (!ModelState.IsValid)
            { return BadRequest(); }
            var movimientoStock = _movimientoStock.GetById(Id.Value);
            if (movimientoStock is null)
            { return NotFound(); }
            _movimientoStock.Delete(movimientoStock.Id);
            return Ok();
        }
    }
}
