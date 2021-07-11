using JuniorAnalyst.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JuniorAnalyst.Domain.Interfaces.Repository
{
    public interface IEventoRepository
    {
        public Task<long?> InserirEvento(Evento evento);
        public Task<IEnumerable<Evento>> ListarEventos();
        public Task<Evento> BuscarEventoPorId(long id);
    }
}
