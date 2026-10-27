using AutoMapper;
using Manaos.Application;
using Manaos.Application.Dtos.Bodega;
using Manaos.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Manaos.WebApi.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class BodegasController : ControllerBase
    {
        private readonly ILogger<BodegasController> _logger;
        private readonly IApplication<Bodega> _bodega;
        private readonly IMapper _mapper;
        public BodegasController(
            ILogger<BodegasController> logger
            , IApplication<Bodega> bodega
            , IMapper mapper)
        {
            _logger = logger;
            _bodega = bodega;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> All()
        {
            return Ok(_mapper.Map<IList<BodegaResponseDto>>(_bodega.GetAll()));
        }

        [HttpGet]
        [Route("ById")]
        public async Task<IActionResult> ById(int? Id)
        {
            if (!Id.HasValue)
            {
                return BadRequest();
            }
            Bodega bodega = _bodega.GetById(Id.Value);
            if (bodega is null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<BodegaResponseDto>(bodega));
        }

        [HttpPost]
        public async Task<IActionResult> Crear(BodegaRequestDto bodegaRequestDto)
        {
            if (!ModelState.IsValid)
            { return BadRequest(); }
            var bodega = _mapper.Map<Bodega>(bodegaRequestDto);
            _bodega.Save(bodega);
            if (bodega.EsPrincipal)
            { DesmarcarOtrasPrincipales(bodega.Id); }
            return Ok(bodega.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Editar(int? Id, BodegaRequestDto bodegaRequestDto)
        {
            if (!Id.HasValue)
            { return BadRequest(); }
            if (!ModelState.IsValid)
            { return BadRequest(); }
            Bodega bodegaBack = _bodega.GetById(Id.Value);
            if (bodegaBack is null)
            { return NotFound(); }
            _mapper.Map(bodegaRequestDto, bodegaBack);
            _bodega.Save(bodegaBack);
            if (bodegaBack.EsPrincipal)
            { DesmarcarOtrasPrincipales(bodegaBack.Id); }
            return Ok();
        }

        private void DesmarcarOtrasPrincipales(int idBodegaPrincipal)
        {
            foreach (var otra in _bodega.GetAll().Where(b => b.Id != idBodegaPrincipal && b.EsPrincipal))
            {
                otra.SetEsPrincipal(false);
                _bodega.Save(otra);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Borrar(int? Id)
        {
            if (!Id.HasValue)
            { return BadRequest(); }
            Bodega bodegaBack = _bodega.GetById(Id.Value);
            if (bodegaBack is null)
            { return NotFound(); }
            _bodega.Delete(bodegaBack.Id);
            return Ok();
        }
    }
}
