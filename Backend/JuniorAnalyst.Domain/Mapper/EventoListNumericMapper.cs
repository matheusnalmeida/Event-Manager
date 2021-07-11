using JuniorAnalyst.Domain.DTO;
using JuniorAnalyst.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JuniorAnalyst.Domain.Mapper
{
    public class EventoListNumericMapper
    {
        public static Evento DtoToEvento(EventoListNumericDTO evento)
        {
            return evento == null ? null : new Evento()
            {
                Pais = evento.pais,
                Regiao = evento.regiao,
                NomeSensor = evento.nomeSensor,
                Timestamp = evento.timestampDt,
                Valor = evento.valor.HasValue ? evento.valor.ToString() : string.Empty
            };
        }

        public static IEnumerable<Evento> DtoToEvento(IEnumerable<EventoListNumericDTO> eventoList) => eventoList?.Select(evento => DtoToEvento(evento));

        public static EventoListNumericDTO EventoToDTO(Evento evento)
        {
            decimal valueConvert;

            return evento == null ? null : new EventoListNumericDTO()
            {
                id = evento.Id,
                pais = evento.Pais,
                regiao = evento.Regiao,
                nomeSensor = evento.NomeSensor,
                timestamp = new DateTimeOffset(evento.Timestamp).ToUnixTimeSeconds(),
                valor = decimal.TryParse(evento.Valor, out valueConvert) ? valueConvert : (decimal?)null
            };
        }

        public static IEnumerable<EventoListNumericDTO> EventoToDTO(IEnumerable<Evento> eventoList) => eventoList?.Select(evento => EventoToDTO(evento));

    }
}
