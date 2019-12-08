using AutoMapper;
using CalculaJuros.Domain.Command;
using CalculaJuros.Domain.Command.Handlers;
using CalculaJuros.Domain.Interfaces;
using CalculaJuros.Infra.Repository;
using CalculaJuros.Service.Interfaces;
using CalculaJuros.Service.Requests;
using CalculoJuros.Api.AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace CalculoJuros.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ICalculaJurosRepository, CalculaJurosRepository > ();
            services.AddScoped<ICalcularJurosService, CalculaJurosService>();
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<IMapper, Mapper>();

            services.AddScoped<IRequestHandler<CalculoJurosCommandCalcular, decimal>, CalculoJurosCommandHandler>();
            services.AddMediatR(typeof(Startup));
            IMapper mapper = AutoMapperConfiguration.RegisterMappings().CreateMapper();
            services.AddSingleton(mapper);
            services.AddAutoMapper(typeof(Startup));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new Info
                    {
                        Title = "Desafio Softplan",
                        Version = "v1",
                        Description = "API para calcular juros.",
                        Contact = new Contact
                        {
                            Name = "Julianno Garcia",
                            Url = "https://github.com/Juliannotcg/DesafioSoftplan"
                        }
                    });
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                    "Calculador de juros.");
            });
        }
    }
}
