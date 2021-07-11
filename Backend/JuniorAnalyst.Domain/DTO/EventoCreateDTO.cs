using System;
using System.Collections.Generic;
using System.Text;

namespace JuniorAnalyst.Domain.DTO
{
    public class EventoCreateDTO
    {
        public long timestamp { get; set; }
        public string tag { get; set; }
        public string valor { get; set; }
    }
}