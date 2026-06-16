using AutoMapper;
using Manaos.Application;
using Manaos.Application.Dtos.DetalleSolicitudReposicion;
using Manaos.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Manaos.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetallesSolicitudesReposicionController : ControllerBase
    {
        private readonly ILogger<DetallesSolicitudesReposicionController> _logger;
        private readonly IApplication<DetalleSolicitudReposicion> _detalleSolicitudReposicion;
        private readonly IMapper _mapper;
        public DetallesSolicitudesReposicionController(
            ILogger<DetallesSolicitudesReposicionController> logger
            , IApplication<DetalleSolicitudReposicion> detalleSolicitudReposicion
            , IMapper mapper)
        {
            _logger = logger;
            _detalleSolicitudReposicion = detalleSolicitudReposicion;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> All()
        {
            return Ok(_mapper.Map<IList<DetalleSolicitudReposicionResponseDto>>(_detalleSolicitudReposicion.GetAll()));
        }

        [HttpGet]
        [Route("ById")]
        public async Task<IActionResult> ById(int? Id)
        {
            if (!Id.HasValue)
            {
                return BadRequest();
            }
            DetalleSolicitudReposicion detalleSolicitudReposicion = _detalleSolicitudReposicion.GetById(Id.Value);
            if (detalleSolicitudReposicion is null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<DetalleSolicitudReposicionResponseDto>(detalleSolicitudReposicion));
        }

        [HttpPost]
        public async Task<IActionResult> Crear(DetalleSolicitudReposicionRequestDto detalleSolicitudReposicionRequestDto)
        {
            if (!ModelState.IsValid)
            { return BadRequest(); }
            var detalleSolicitudReposicion = _mapper.Map<DetalleSolicitudReposicion>(detalleSolicitudReposicionRequestDto);
            _detalleSolicitudReposicion.Save(detalleSolicitudReposicion);
            return Ok(detalleSolicitudReposicion.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Editar(int? Id, DetalleSolicitudReposicionRequestDto detalleSolicitudReposicionRequestDto)
        {
            if (!Id.HasValue)
            { return BadRequest(); }
            if (!ModelState.IsValid)
            { return BadRequest(); }
            var detalleSolicitudReposicion = _detalleSolicitudReposicion.GetById(Id.Value);
            if (detalleSolicitudReposicion is null)
            { return NotFound(); }
            detalleSolicitudReposicion = _mapper.Map<DetalleSolicitudReposicion>(detalleSolicitudReposicionRequestDto);
            _detalleSolicitudReposicion.Save(detalleSolicitudReposicion);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Borrar(int? Id)
        {
            if (!Id.HasValue)
            { return BadRequest(); }
            if (!ModelState.IsValid)
            { return BadRequest(); }
            var detalleSolicitudReposicion = _detalleSolicitudReposicion.GetById(Id.Value);
            if (detalleSolicitudReposicion is null)
            { return NotFound(); }
            _detalleSolicitudReposicion.Delete(detalleSolicitudReposicion.Id);
            return Ok();
        }
    }
}
