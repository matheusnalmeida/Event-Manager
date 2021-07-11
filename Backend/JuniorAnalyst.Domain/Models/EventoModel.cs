using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JuniorAnalyst.Domain.Models
{
    public class EventoModel
    {
        public DateTime Timestamp { get; private set; }
        public string Pais { get; private set; }
        public string Regiao { get; private set; }
        public string NomeSensor { get; private set; }
        public string Valor { get; private set; }

        public EventoModel(string tag, string valor, long timestamp)
        {
            if (string.IsNullOrEmpty(tag))
            {
                throw new ArgumentException("È necessário que seja informado valor para a tag do evento!");
            }

            if (timestamp < 1)
            {
                throw new ArgumentException("É necessário que o tempo em milisegundos do evento seja um valor maior que 0!");
            }

            // A tag enviada deverá ser constituida de pais, região e nome_sensor separados por ponto
            var tagData = tag.Split('.').ToList().Select(it => it.Trim());

            if (tagData.Count() < 3)
            {
                throw new ArgumentException("Para tag do evento é necessário que sejam informados o pais região e nome do sensor no seguinte formato: pais.região.nome_sensor!");
            }

            Pais = tagData.ElementAt(0);
            Regiao = tagData.ElementAt(1);
            NomeSensor = tagData.ElementAt(2);
            Valor = valor.Trim();
            Timestamp = GerarTimeStampDateTime(timestamp);
        }

        private static DateTime GerarTimeStampDateTime(long timestamp)
        {
            var dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            dtDateTime = dtDateTime.AddMilliseconds(timestamp);
            return dtDateTime;
        }
    }
}
