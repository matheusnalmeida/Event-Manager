using JuniorAnalyst.Domain.Entitites;
using JuniorAnalyst.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JuniorAnalyst.Domain.Mapper
{
    public class EventoModelMapper
    {
        public static Evento ModelToEvento(EventoModel evento)
        {
            return evento == null ? null : new Evento()
            {
                Pais = evento.Pais,
                Regiao = evento.Regiao,
                NomeSensor = evento.NomeSensor,
                Timestamp = evento.Timestamp,
                Valor = evento.Valor
            };
        }

        public static IEnumerable<Evento> ModelToEvento(IEnumerable<EventoModel> eventoList) => eventoList?.Select(evento => ModelToEvento(evento));
    }
}
