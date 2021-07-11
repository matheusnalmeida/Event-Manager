using JuniorAnalyst.Domain.Interfaces.Services;
using JuniorAnalyst.Repository.DAL;
using JuniorAnalyst.Service.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using JuniorAnalyst.Repository.Repository;
using JuniorAnalyst.Domain.Interfaces.Repository;
using System;

namespace junior_analyst
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod()
                    .AllowAnyHeader());
            });

            ConfigureDatabase(services);

            InjetarServices(services);

            services.AddControllersWithViews();
        }

        private void ConfigureDatabase(IServiceCollection services)
        {
            var server = Configuration["ConnectionStrings:DBServer"] ?? "localhost";
            var port = Configuration["ConnectionStrings:DBPort"] ?? "1443";
            var user = Configuration["ConnectionStrings:DBUser"] ?? "SA";
            var password = Configuration["ConnectionStrings:DBPassword"] ?? "senha";
            var database = Configuration["ConnectionStrings:Database"] ?? "JuniorAnalyst";

            var connectionString = $"Server={server};Database={database};User Id={user};Password={password};";

            services.AddDbContext<EventoContext>(options =>
                options.UseSqlServer(connectionString, b => b.MigrationsAssembly("JuniorAnalyst.Application")));
        }

        private static void InjetarServices(IServiceCollection services)
        {
            services.AddTransient<IEventoRepository, EventoRepository>();
            services.AddTransient<IEventoService, EventoService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, EventoContext context)
        {
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Evento}/{id?}");
            });

            EventoContextInitializer.CargaInicialEventos(context);
        }
    }
}
