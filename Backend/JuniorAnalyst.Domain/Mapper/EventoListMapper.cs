using JuniorAnalyst.Domain.DTO;
using JuniorAnalyst.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JuniorAnalyst.Domain.Mapper
{
    public class EventoListMapper
    {
        public static Evento DtoToEvento(EventoListDTO evento) 
        { 
            return evento == null ? null : new Evento()
            {
                Pais = evento.pais,
                Regiao = evento.regiao,
                NomeSensor = evento.nomeSensor,
                Timestamp = evento.timestampDt,
                Valor = evento.valor
            };
        }

        public static IEnumerable<Evento> DtoToEvento(IEnumerable<EventoListDTO> eventoList) => eventoList?.Select(evento => DtoToEvento(evento));

        public static EventoListDTO EventoToDTO(Evento evento)
        {
            return evento == null ? null : new EventoListDTO()
            {
                id = evento.Id,
                pais = evento.Pais,
                regiao = evento.Regiao,
                nomeSensor = evento.NomeSensor,
                timestamp = new DateTimeOffset(evento.Timestamp).ToUnixTimeSeconds(),
                valor = evento.Valor
            };
        }

        public static IEnumerable<EventoListDTO> EventoToDTO(IEnumerable<Evento> eventoList) => eventoList?.Select(evento => EventoToDTO(evento));

    }
}
