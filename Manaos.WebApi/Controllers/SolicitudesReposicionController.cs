using AutoMapper;
using Manaos.Application;
using Manaos.Application.Dtos.SolicitudReposicion;
using Manaos.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Manaos.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitudesReposicionController : ControllerBase
    {
        private readonly ILogger<SolicitudesReposicionController> _logger;
        private readonly IApplication<SolicitudReposicion> _solicitudReposicion;
        private readonly IMapper _mapper;
        public SolicitudesReposicionController(
            ILogger<SolicitudesReposicionController> logger
            , IApplication<SolicitudReposicion> solicitudReposicion
            , IMapper mapper)
        {
            _logger = logger;
            _solicitudReposicion = solicitudReposicion;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> All()
        {
            return Ok(_mapper.Map<IList<SolicitudReposicionResponseDto>>(_solicitudReposicion.GetAll()));
        }

        [HttpGet]
        [Route("ById")]
        public async Task<IActionResult> ById(int? Id)
        {
            if (!Id.HasValue)
            {
                return BadRequest();
            }
            SolicitudReposicion solicitudReposicion = _solicitudReposicion.GetById(Id.Value);
            if (solicitudReposicion is null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<SolicitudReposicionResponseDto>(solicitudReposicion));
        }

        [HttpPost]
        public async Task<IActionResult> Crear(SolicitudReposicionRequestDto solicitudReposicionRequestDto)
        {
            if (!ModelState.IsValid)
            { return BadRequest(); }
            var solicitudReposicion = _mapper.Map<SolicitudReposicion>(solicitudReposicionRequestDto);
            _solicitudReposicion.Save(solicitudReposicion);
            return Ok(solicitudReposicion.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Editar(int? Id, SolicitudReposicionRequestDto solicitudReposicionRequestDto)
        {
            if (!Id.HasValue)
            { return BadRequest(); }
            if (!ModelState.IsValid)
            { return BadRequest(); }
            var solicitudReposicion = _solicitudReposicion.GetById(Id.Value);
            if (solicitudReposicion is null)
            { return NotFound(); }
            solicitudReposicion = _mapper.Map<SolicitudReposicion>(solicitudReposicionRequestDto);
            _solicitudReposicion.Save(solicitudReposicion);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Borrar(int? Id)
        {
            if (!Id.HasValue)
            { return BadRequest(); }
            if (!ModelState.IsValid)
            { return BadRequest(); }
            var solicitudReposicion = _solicitudReposicion.GetById(Id.Value);
            if (solicitudReposicion is null)
            { return NotFound(); }
            _solicitudReposicion.Delete(solicitudReposicion.Id);
            return Ok();
        }
    }
}
