using JuniorAnalyst.Domain.DTO;
using JuniorAnalyst.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JuniorAnalyst.Domain.Interfaces.Services
{
    public interface IEventoService
    {
        public Task<IServiceResponse<long?>> InserirEvento(EventoCreateDTO evento);
        public Task<IServiceResponse<IEnumerable<EventoListDTO>>> ListarEventos();
        public Task<IServiceResponse<IEnumerable<EventoListNumericDTO>>> ListarEventosNumericos();
        public Task<IServiceResponse<EventoListDTO>> BuscarEventoPorId(long id);
    }
}
