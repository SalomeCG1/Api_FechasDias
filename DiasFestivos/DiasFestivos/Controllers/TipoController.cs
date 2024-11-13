using DiasFestivos.Core.Interfaces.Servicios;
using DiasFestivos.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace DiasFestivos.Controllers
{
    [ApiController]
    [Route("api/Tipo")]
    public class TipoController : ControllerBase
    {
        private readonly ITipoServicio servicio;
        public TipoController(ITipoServicio servicio)
        {
            this.servicio = servicio;
        }

        [HttpGet("listar")]
        public async Task<ActionResult<IEnumerable<TBTipo>>> ObtenerTodos()
        {
            return Ok(await servicio.ObtenerTodos());
        }

        
    }
}
