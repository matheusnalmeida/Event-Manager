using JuniorAnalyst.Domain.DTO;
using JuniorAnalyst.Domain.Interfaces.Services;
using JuniorAnalyst.Domain.Mapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace junior_analyst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {

        private readonly IEventoService _eventoService;

        public EventoController(IEventoService eventoService)
        {
            _eventoService = eventoService;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var response = await _eventoService.ListarEventos();

            return StatusCode((int)response.StatusCode, new
            {
                Retorno = response.Retorno,
                Mensagem = response.Message
            });
        }

        [HttpGet("GetNumeric")]
        public async Task<ActionResult> GetNumeric()
        {
            var response = await _eventoService.ListarEventosNumericos();

            return StatusCode((int)response.StatusCode, new
            {
                Retorno = response.Retorno,
                Mensagem = response.Message
            });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(long id)
        {
            var response = await _eventoService.BuscarEventoPorId(id);

            return StatusCode((int)response.StatusCode, new
            {
                Retorno = response.Retorno,
                Mensagem = response.Message
            });
        }

        // POST api/<EventoController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] EventoCreateDTO eventoDTO)
        {
            var response = await _eventoService.InserirEvento(eventoDTO);

            return StatusCode((int)response.StatusCode, new
            {
                Retorno = response.Retorno,
                Mensagem = response.Message
            });
        }
    }
}
