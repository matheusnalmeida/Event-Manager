using JuniorAnalyst.Domain.Interfaces.Services;
using System.Net;

namespace JuniorAnalyst.Service.Util
{
    public class ServiceResponse<T> : IServiceResponse<T>
    {
        public HttpStatusCode StatusCode { get; set; }

        public string Message { get; set; }

        public T Retorno { get; set; }
    }
}
