using JuniorAnalyst.Domain.DTO;
using JuniorAnalyst.Test.Mock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Xunit;

namespace JuniorAnalyst.Test.EventoControllerTest
{
    public class EventoServiceTest
    {
        EventoServiceMock _service;

        public EventoServiceTest()
        {
            _service = new EventoServiceMock();
        }

        [Fact]
        public async void ObterTodosEventos()
        {
            var responseService = await _service.ListarEventos();

            var eventos = responseService.Retorno;

            Assert.Equal(10, eventos.Count());
        }

        [Fact]
        public async void ObterTodosEventosNumericos()
        {
            var responseService = await _service.ListarEventosNumericos();

            var eventos = responseService.Retorno;

            Assert.Equal(7, eventos.Count());
        }

        [Fact]
        public async void InserirEventoValido()
        {
            var novoEvento = new EventoCreateDTO()
            {
                tag = "brasil.sudeste.sensor01",
                timestamp = 1539112021301,
                valor = "teste"
            };

            var responseService = await _service.InserirEvento(novoEvento);

            Assert.Equal(HttpStatusCode.OK, responseService.StatusCode);
        }

        [Fact]
        public async void InserirEventoSemTag()
        {
            var novoEvento = new EventoCreateDTO() 
            {
                tag = "",
                timestamp = 1539112021301,
                valor = "teste"
            };

            var responseService = await _service.InserirEvento(novoEvento);

            Assert.Equal(HttpStatusCode.BadRequest, responseService.StatusCode);
        }

        [Fact]
        public async void InserirEventoTagInvalida()
        {
            var novoEvento = new EventoCreateDTO()
            {
                tag = "brasil.sensor01",
                timestamp = 1539112021301,
                valor = "teste"
            };

            var responseService = await _service.InserirEvento(novoEvento);

            Assert.Equal(HttpStatusCode.BadRequest, responseService.StatusCode);
        }

        [Fact]
        public async void InserirEventoTimestampInvalido()
        {
            var novoEvento = new EventoCreateDTO()
            {
                tag = "brasil.sudeste.sensor01",
                timestamp = -1,
                valor = "teste"
            };

            var responseService = await _service.InserirEvento(novoEvento);

            Assert.Equal(HttpStatusCode.BadRequest, responseService.StatusCode);
        }

        [Fact]
        public async void BuscarEventoPorIdExistente()
        {
            var responseService = await _service.BuscarEventoPorId(1);

            Assert.NotNull(responseService.Retorno);
        }

        [Fact]
        public async void BuscarEventoPorIdNaoExistente()
        {
            var responseService = await _service.BuscarEventoPorId(55555555555);

            Assert.Null(responseService.Retorno);
        }
    }
}
