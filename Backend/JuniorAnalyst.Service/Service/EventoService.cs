using JuniorAnalyst.Domain.DTO;
using JuniorAnalyst.Domain.Entitites;
using JuniorAnalyst.Domain.Interfaces.Repository;
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

namespace JuniorAnalyst.Service.Service
{
    public class EventoService : IEventoService
    {
        private readonly IEventoRepository _eventoRepository;

        public EventoService(IEventoRepository eventoRepository)
        {
            _eventoRepository = eventoRepository;
        }

        public async Task<IServiceResponse<EventoListDTO>> BuscarEventoPorId(long id)
        {
            var evento = await _eventoRepository.BuscarEventoPorId(id);

            var eventoListDTO = EventoListMapper.EventoToDTO(evento);

            return new ServiceResponse<EventoListDTO>() 
                                { 
                                    StatusCode = HttpStatusCode.OK,
                                    Retorno = eventoListDTO,
                                    Message = eventoListDTO == null ? "Não foi encontrado evento com o codigo informado" : "Evento encontrado com sucess"
                                };
        }

        public async Task<IServiceResponse<long?>> InserirEvento(EventoCreateDTO eventoCreateDTO)
        {
            try
            {
                // Validator dos dados feito no construtor do model
                var eventoModel = new EventoModel(eventoCreateDTO.tag, eventoCreateDTO.valor, eventoCreateDTO.timestamp);

                var evento = EventoModelMapper.ModelToEvento(eventoModel);

                var eventoIdNovo = await _eventoRepository.InserirEvento(evento);

                return new ServiceResponse<long?>()
                {
                    StatusCode = HttpStatusCode.OK,
                    Retorno = eventoIdNovo,
                    Message = !eventoIdNovo.HasValue ? "Não foi possivel cadastrar o evento" : "Evento cadastrado com sucesso"
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
            var eventoList = await _eventoRepository.ListarEventos();

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
            var eventoList = await _eventoRepository.ListarEventos();

            //Filtrando eventos com valor numerico
            var eventoNumericList = EventoListNumericMapper.EventoToDTO(eventoList).Where(evento => evento.valor.HasValue);

            return new ServiceResponse<IEnumerable<EventoListNumericDTO>>()
            {
                StatusCode = HttpStatusCode.OK,
                Retorno = eventoNumericList,
                Message = string.Format("Foram encontrados {0} eventos com valor numerico!", eventoNumericList.Count())
            };
        }
    }
}
