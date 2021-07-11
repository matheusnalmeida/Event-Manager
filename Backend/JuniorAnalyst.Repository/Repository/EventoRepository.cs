using JuniorAnalyst.Domain.Entitites;
using JuniorAnalyst.Domain.Interfaces.Repository;
using JuniorAnalyst.Repository.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JuniorAnalyst.Repository.Repository
{
    public class EventoRepository : IEventoRepository
    {
        private readonly EventoContext _context;

        public EventoRepository(EventoContext context)
        {
            _context = context;
        }

        public async Task<Evento> BuscarEventoPorId(long id)
        {
            var evento = await _context.Eventos.FindAsync(id);

            return evento;
        }

        public async Task<long?> InserirEvento(Evento evento)
        {
            var eventoNovo = await _context.Eventos.AddAsync(evento);

            await _context.SaveChangesAsync();

            long? idNovoEvento = eventoNovo.Entity.Id;

            return idNovoEvento;
        }

        public async Task<IEnumerable<Evento>> ListarEventos()
        {
            var eventosList = await _context.Eventos.ToListAsync();

            return eventosList;
        }
    }
}
