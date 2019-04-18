using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using VS2019.API.Models;
using VS2019.API.Services.Interfaces;

namespace VS2019.API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/v1/eventos")]
    public class EventoController : ControllerBase
    {
        private readonly IEventoService _eventoService;

        public EventoController(IEventoService eventoService)
        {
            _eventoService = eventoService;
        }

        [HttpGet("limit/{limit}")]
        public async Task<ActionResult<IEnumerable<Evento>>> List(int limit)
        {
            return Ok(await _eventoService.GetAllByLimit(limit));
        }

        [HttpPost]
        public ActionResult Post([FromBody]Evento evento)
        {
            if (evento == null)
            {
                return BadRequest();
            }

            _eventoService.Add(evento);

            return Ok();
        }
    }
}
