using AutoMapper;
using Manaos.Application;
using Manaos.Application.Dtos.StockBodega;
using Manaos.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Manaos.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StocksBodegasController : ControllerBase
    {
        private readonly ILogger<StocksBodegasController> _logger;
        private readonly IApplication<StockBodega> _stockBodega;
        private readonly IMapper _mapper;
        public StocksBodegasController(
            ILogger<StocksBodegasController> logger
            , IApplication<StockBodega> stockBodega
            , IMapper mapper)
        {
            _logger = logger;
            _stockBodega = stockBodega;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> All()
        {
            return Ok(_mapper.Map<IList<StockBodegaResponseDto>>(_stockBodega.GetAll()));
        }

        [HttpGet]
        [Route("ById")]
        public async Task<IActionResult> ById(int? Id)
        {
            if (!Id.HasValue)
            {
                return BadRequest();
            }
            StockBodega stockBodega = _stockBodega.GetById(Id.Value);
            if (stockBodega is null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<StockBodegaResponseDto>(stockBodega));
        }

        [HttpPost]
        public async Task<IActionResult> Crear(StockBodegaRequestDto stockBodegaRequestDto)
        {
            if (!ModelState.IsValid)
            { return BadRequest(); }
            var stockBodega = _mapper.Map<StockBodega>(stockBodegaRequestDto);
            _stockBodega.Save(stockBodega);
            return Ok(stockBodega.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Editar(int? Id, StockBodegaRequestDto stockBodegaRequestDto)
        {
            if (!Id.HasValue)
            { return BadRequest(); }
            if (!ModelState.IsValid)
            { return BadRequest(); }
            var stockBodega = _stockBodega.GetById(Id.Value);
            if (stockBodega is null)
            { return NotFound(); }
            stockBodega = _mapper.Map<StockBodega>(stockBodegaRequestDto);
            _stockBodega.Save(stockBodega);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Borrar(int? Id)
        {
            if (!Id.HasValue)
            { return BadRequest(); }
            if (!ModelState.IsValid)
            { return BadRequest(); }
            var stockBodega = _stockBodega.GetById(Id.Value);
            if (stockBodega is null)
            { return NotFound(); }
            _stockBodega.Delete(stockBodega.Id);
            return Ok();
        }
    }
}
