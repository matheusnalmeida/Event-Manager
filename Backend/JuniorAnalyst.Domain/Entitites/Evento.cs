using System;
using System.Collections.Generic;
using System.Text;

namespace JuniorAnalyst.Domain.Entitites
{
    public class Evento
    {
        public long Id { get; set; }
        public DateTime Timestamp { get; set; }
        public string Pais { get; set; }
        public string Regiao { get; set; }
        public string NomeSensor { get; set; }
        public string Valor { get; set; }
    }
}
