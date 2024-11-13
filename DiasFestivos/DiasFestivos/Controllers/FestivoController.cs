using DiasFestivos.Core.Interfaces.Servicios;
using DiasFestivos.Dominio.Entidades;
using DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DiasFestivos.Controllers
{
    [ApiController]
    [Route("api/festivos")]
    public class FestivoController : ControllerBase
    {
        private readonly IFestivoServicio servicio;
        public FestivoController(IFestivoServicio servicio)
        {
            this.servicio = servicio;
        }

        [HttpGet("listar")]
        public async Task<ActionResult<IEnumerable<TBFestivos>>> ObtenerTodos()
        {
            return Ok(await servicio.ObtenerTodos());
        }

        [HttpGet("obtener/{Id}")]
        public async Task<ActionResult<TBFestivos>> Obtener(int Id)
        {
            return Ok(await servicio.Obtener(Id));
        }

        [HttpGet("fecha/{Year}")]
        public async Task<ActionResult<IEnumerable<DTOsFestivos>>> ObtenerPorYear(int Year)
        {
            var festivos = await servicio.ObtenerPorYear(Year);
            return Ok(festivos);
        }
    }
}
