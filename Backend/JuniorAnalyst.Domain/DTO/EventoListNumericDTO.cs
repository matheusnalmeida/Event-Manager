using System;
using System.Collections.Generic;
using System.Text;

namespace JuniorAnalyst.Domain.DTO
{
    public class EventoListNumericDTO
    {
        public long id { get; set; }
        public long timestamp { get; set; }
        public string pais { get; set; }
        public string regiao { get; set; }
        public string nomeSensor { get; set; }
        public decimal? valor { get; set; }
        public DateTime timestampDt
        {
            get
            {
                DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                dtDateTime = dtDateTime.AddSeconds(timestamp).ToLocalTime();
                return dtDateTime;
            }
        }
    }
}
