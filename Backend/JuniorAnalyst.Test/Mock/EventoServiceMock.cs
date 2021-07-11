using JuniorAnalyst.Domain.DTO;
using JuniorAnalyst.Domain.Entitites;
using JuniorAnalyst.Domain.Interfaces.Services;
using JuniorAnalyst.Domain.Mapper;
using JuniorAnalyst.Domain.Models;
using JuniorAnalyst.Service.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JuniorAnalyst.Test.Mock
{
    class EventoServiceMock : IEventoService
    {
        private readonly List<Evento> _eventosList;
        public EventoServiceMock()
        {
            _eventosList = new List<Evento>()
            {
                new Evento() {
                    Id = 1, Timestamp = new DateTime(2015,6,3,4,32,53), Pais = "Brasil", Regiao = "Sudeste", NomeSensor = "sensor01", Valor = "123"
                },
                new Evento() {
                    Id = 2, Timestamp = new DateTime(2016,6,3,4,32,53), Pais = "Brasil", Regiao = "Sudeste", NomeSensor = "sensor02", Valor = "123"
                },
                new Evento() {
                    Id = 3, Timestamp = new DateTime(2017,6,3,4,32,53), Pais = "Brasil", Regiao = "Sudeste", NomeSensor = "sensor03", Valor = "teste"
                },
                new Evento() {
                    Id = 4, Timestamp = new DateTime(2019,6,3,4,32,53), Pais = "Brasil", Regiao = "Nordeste", NomeSensor = "sensor01", Valor = "200"
                },
                new Evento() {
                    Id = 5, Timestamp = new DateTime(2020,6,3,4,32,53), Pais = "Brasil", Regiao = "Nordeste", NomeSensor = "sensor02", Valor = "teste"
                },
                new Evento() {
                    Id = 6, Timestamp = new DateTime(2021,6,3,4,32,53), Pais = "Brasil", Regiao = "Nordeste", NomeSensor = "sensor03", Valor = "123"
                },
                new Evento() {
                    Id = 7, Timestamp = new DateTime(2015,6,3,4,32,53), Pais = "Brasil", Regiao = "Norte", NomeSensor = "sensor01", Valor = "300"
                },
                new Evento() {
                    Id = 8, Timestamp = new DateTime(2015,6,3,4,32,53), Pais = "Brasil", Regiao = "Norte", NomeSensor = "sensor02", Valor = "200"
                },
                new Evento() {
                    Id = 9, Timestamp = new DateTime(2015,6,3,4,32,53), Pais = "Brasil", Regiao = "Norte", NomeSensor = "sensor03", Valor = "teste"
                },
                new Evento() {
                    Id = 10, Timestamp = new DateTime(2015,6,3,4,32,53), Pais = "Brasil", Regiao = "Norte", NomeSensor = "sensor04", Valor = "400"
                },
            };
        }

        public async Task<IServiceResponse<EventoListDTO>> BuscarEventoPorId(long id)
        {
            var evento = _eventosList.FirstOrDefault(it => it.Id == id);

            var eventoListDTO = EventoListMapper.EventoToDTO(evento);

            return new ServiceResponse<EventoListDTO>()
            {
                StatusCode = HttpStatusCode.OK,
                Retorno = eventoListDTO,
                Message = eventoListDTO == null ? "Não foi encontrado evento com o codigo informado" : "Evento encontrado com sucess"
            };
        }

        public async Task<IServiceResponse<long?>> InserirEvento(EventoCreateDTO evento)
        {
            try
            {
                // Validator dos dados feito no construtor do model
                var eventoModel = new EventoModel(evento.tag, evento.valor, evento.timestamp);

                var eventoNovo = EventoModelMapper.ModelToEvento(eventoModel);
                eventoNovo.Id = _eventosList.Select(it => it.Id).Max();

                _eventosList.Add(eventoNovo);

                return new ServiceResponse<long?>()
                {
                    StatusCode = HttpStatusCode.OK,
                    Retorno = eventoNovo.Id,
                    Message = "Evento cadastrado com sucesso"
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<long?>()
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Retorno = null,
                    Message = ex.Message
                };
            }
        }

        public async Task<IServiceResponse<IEnumerable<EventoListDTO>>> ListarEventos()
        {
            var eventoList = _eventosList;

            var eventoListDTO = EventoListMapper.EventoToDTO(eventoList);

            return new ServiceResponse<IEnumerable<EventoListDTO>>()
            {
                StatusCode = HttpStatusCode.OK,
                Retorno = eventoListDTO,
                Message = string.Format("Foram encontrados {0} eventos!", eventoListDTO.Count())
            };
        }

        public async Task<IServiceResponse<IEnumerable<EventoListNumericDTO>>> ListarEventosNumericos()
        {
            //Filtrando eventos com valor numerico
            var eventoNumericList = EventoListNumericMapper.EventoToDTO(_eventosList).Where(evento => evento.valor.HasValue);

            return new ServiceResponse<IEnumerable<EventoListNumericDTO>>()
            {
                StatusCode = HttpStatusCode.OK,
                Retorno = eventoNumericList,
                Message = string.Format("Foram encontrados {0} eventos com valor numerico!", eventoNumericList.Count())
            };
        }
    }
}
