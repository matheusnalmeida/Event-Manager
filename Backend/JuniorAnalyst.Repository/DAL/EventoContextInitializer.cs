using JuniorAnalyst.Domain.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JuniorAnalyst.Repository.DAL
{
    public class EventoContextInitializer
    {
        public static void CargaInicialEventos(EventoContext context)
        {
            context.Database.Migrate();

            var existeEvento = context.Eventos.Any();
            if (existeEvento)
            {
                return;
            }

            var eventos = new Evento[]
            {
                new Evento() {
                    Timestamp = new DateTime(2015,6,3,4,32,53), Pais = "Brasil", Regiao = "Sudeste", NomeSensor = "sensor01", Valor = "123"
                },
                new Evento() {
                    Timestamp = new DateTime(2016,6,3,4,32,53), Pais = "Brasil", Regiao = "Sudeste", NomeSensor = "sensor02", Valor = "123"
                },
                new Evento() {
                    Timestamp = new DateTime(2017,6,3,4,32,53), Pais = "Brasil", Regiao = "Sudeste", NomeSensor = "sensor03", Valor = "teste"
                },
                new Evento() {
                    Timestamp = new DateTime(2019,6,3,4,32,53), Pais = "Brasil", Regiao = "Nordeste", NomeSensor = "sensor01", Valor = "200"
                },
                new Evento() {
                    Timestamp = new DateTime(2020,6,3,4,32,53), Pais = "Brasil", Regiao = "Nordeste", NomeSensor = "sensor02", Valor = "teste"
                },
                new Evento() {
                    Timestamp = new DateTime(2021,6,3,4,32,53), Pais = "Brasil", Regiao = "Nordeste", NomeSensor = "sensor03", Valor = "123"
                },
                new Evento() {
                    Timestamp = new DateTime(2015,6,3,4,32,53), Pais = "Brasil", Regiao = "Norte", NomeSensor = "sensor01", Valor = "300"
                },
                new Evento() {
                    Timestamp = new DateTime(2015,6,3,4,32,53), Pais = "Brasil", Regiao = "Norte", NomeSensor = "sensor02", Valor = "200"
                },
                new Evento() {
                    Timestamp = new DateTime(2015,6,3,4,32,53), Pais = "Brasil", Regiao = "Norte", NomeSensor = "sensor03", Valor = "teste"
                },
                new Evento() {
                    Timestamp = new DateTime(2015,6,3,4,32,53), Pais = "Brasil", Regiao = "Norte", NomeSensor = "sensor04", Valor = "400"
                },
            };

            context.Eventos.AddRange(eventos);
            context.SaveChanges();
        }
    }

}
