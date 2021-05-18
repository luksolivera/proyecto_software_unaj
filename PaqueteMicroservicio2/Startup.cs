using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microservicio_Paquete.Application.Services;
using Microservicio_Paquete.Domain.Commands;
using Microservicio_Paquete.Domain.Queries;
using Microservicio_Paquete.AccessData.Commands;
using Microservicio_Paquete.AccessData.Queries;
using Microservicio_Paquete.AccessData;
using Microsoft.OpenApi.Models;

namespace Microservicio_Paquete.API
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
            services.AddControllers();
            //var connectionString = Configuration.GetSection(@"Server=localhost;Database=master;Trusted_Connection=True;").Value; //busca las configuraciones del sistema
            services.AddDbContext<TemplateDbContext>(options => options.UseSqlServer(@"Server=localhost;Database=mspaquetes;Trusted_Connection=True;"));

            services.AddTransient<IRepositoryGenericCommands, GenericsRepositoryCommands>();
            services.AddTransient<IRepositoryGenericQueries, GenericsRepositoryQueries>();

            services.AddTransient<IPaqueteCommandService, PaqueteCommandService>();
            services.AddTransient<IPaqueteQueryService, PaqueteQueryService>();

            services.AddTransient<IHotelCommandService, HotelCommandService>();
            services.AddTransient<IHotelQueryService, HotelQueryService>();

            services.AddTransient<IDestinoCommandService, DestinoCommandService>();
            services.AddTransient<IDestinoQueryService, DestinoQueryService>();

            services.AddTransient<IDestinoExcursionCommandService, DestinoExcursionCommandService>();
            services.AddTransient<IDestinoExcursionQueryService, DestinoExcursionQueryService>();

            services.AddTransient<IDestinoHotelCommandService, DestinoHotelCommandService>();
            services.AddTransient<IDestinoHotelQueryService, DestinoHotelQueryService>();

            services.AddTransient<IExcursionCommandService, ExcursionCommandService>();
            services.AddTransient<IExcursionQueryService, ExcursionQueryService>();

            services.AddTransient<IHabitacionHotelCommandService, HabitacionHotelCommandService>();
            services.AddTransient<IHabitacionHotelQueryService, HabitacionHotelQueryService>();

            services.AddTransient<IHotelPensionCommandService, HotelPensionCommandService>();
            services.AddTransient<IHotelPensionQueryService, HotelPensionQueryService>();

            services.AddTransient<IPaqueteDestinoCommandService, PaqueteDestinoCommandService>();
            services.AddTransient<IPaqueteDestinoQueryService, PaqueteDestinoQueryService>();

            services.AddTransient<IPaqueteEstadoCommandService, PaqueteEstadoCommandService>();
            services.AddTransient<IPaqueteEstadoQueryService, PaqueteEstadoQueryService>();

            services.AddTransient<IPaqueteHotelCommandService, PaqueteHotelCommandService>();
            services.AddTransient<IPaqueteHotelQueryService, PaqueteHotelQueryService>();

            services.AddTransient<ITipoHabitacionCommandService, TipoHabitacionCommandService>();
            services.AddTransient<ITipoHabitacionQueryService, TipoHabitacionQueryService>();

            AddSwagger(services);
        }

        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                var groupName = "v1";

                options.SwaggerDoc(groupName, new OpenApiInfo
                {
                    Title = $"Microservicio de paquetes {groupName}",
                    Version = groupName,
                    Description = "Paquetes turísticos - Microservicio de paquetes API",
                    Contact = new OpenApiContact
                    {
                        Name = "Paquetes turísticos",
                        Email = string.Empty,
                        Url = new Uri("https://foo.com/"),
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Microservicio Paquete V1");
            });
        }
    }
}
