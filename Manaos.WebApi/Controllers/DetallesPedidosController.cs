using AutoMapper;
using Manaos.Application;
using Manaos.Application.Dtos.DetallePedido;
using Manaos.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Manaos.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetallesPedidosController : ControllerBase
    {
        private readonly ILogger<DetallesPedidosController> _logger;
        private readonly IApplication<DetallePedido> _detallePedido;
        private readonly IMapper _mapper;
        public DetallesPedidosController(
            ILogger<DetallesPedidosController> logger
            , IApplication<DetallePedido> detallePedido
            , IMapper mapper)
        {
            _logger = logger;
            _detallePedido = detallePedido;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> All()
        {
            return Ok(_mapper.Map<IList<DetallePedidoResponseDto>>(_detallePedido.GetAll()));
        }

        [HttpGet]
        [Route("ById")]
        public async Task<IActionResult> ById(int? Id)
        {
            if (!Id.HasValue)
            {
                return BadRequest();
            }
            DetallePedido detallePedido = _detallePedido.GetById(Id.Value);
            if (detallePedido is null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<DetallePedidoResponseDto>(detallePedido));
        }

        [HttpPost]
        public async Task<IActionResult> Crear(DetallePedidoRequestDto detallePedidoRequestDto)
        {
            if (!ModelState.IsValid)
            { return BadRequest(); }
            var detallePedido = _mapper.Map<DetallePedido>(detallePedidoRequestDto);
            _detallePedido.Save(detallePedido);
            return Ok(detallePedido.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Editar(int? Id, DetallePedidoRequestDto detallePedidoRequestDto)
        {
            if (!Id.HasValue)
            { return BadRequest(); }
            if (!ModelState.IsValid)
            { return BadRequest(); }
            var detallePedido = _detallePedido.GetById(Id.Value);
            if (detallePedido is null)
            { return NotFound(); }
            detallePedido = _mapper.Map<DetallePedido>(detallePedidoRequestDto);
            _detallePedido.Save(detallePedido);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Borrar(int? Id)
        {
            if (!Id.HasValue)
            { return BadRequest(); }
            if (!ModelState.IsValid)
            { return BadRequest(); }
            var detallePedido = _detallePedido.GetById(Id.Value);
            if (detallePedido is null)
            { return NotFound(); }
            _detallePedido.Delete(detallePedido.Id);
            return Ok();
        }
    }
}
