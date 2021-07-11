using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace JuniorAnalyst.Domain.Interfaces.Services
{
    public interface IServiceResponse<T>
    {
        public HttpStatusCode StatusCode { get; set; }

        public string Message { get; set; }

        public T Retorno { get; set; }
    }
}
