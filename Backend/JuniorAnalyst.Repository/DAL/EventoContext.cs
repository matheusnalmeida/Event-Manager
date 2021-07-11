using JuniorAnalyst.Domain.Entitites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Text;

namespace JuniorAnalyst.Repository.DAL
{
    public class EventoContext : DbContext
    {
        public DbSet<Evento> Eventos { get; set; }

        public EventoContext(DbContextOptions<EventoContext> options) : base(options) 
        {
        }

    }
}
