using Manaos.Services.Reposicion;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Manaos.WebApi.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class ReposicionController : ControllerBase
    {
        private readonly ILogger<ReposicionController> _logger;
        private readonly IReposicionService _reposicion;
        public ReposicionController(
            ILogger<ReposicionController> logger
            , IReposicionService reposicion)
        {
            _logger = logger;
            _reposicion = reposicion;
        }

        [HttpGet]
        [Route("Faltantes")]
        public async Task<IActionResult> Faltantes()
        {
            var faltantes = _reposicion.ObtenerFaltantes();
            if (faltantes is null)
            {
                return BadRequest();
            }
            return Ok(faltantes);
        }
    }
}
