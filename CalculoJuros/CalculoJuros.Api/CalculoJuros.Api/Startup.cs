using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using CalculaJuros.Domain.Command.Handlers;
using CalculaJuros.Domain.Interfaces;
using CalculaJuros.Infra.Repository;
using CalculaJuros.Service.Interfaces;
using CalculaJuros.Service.Requests;
using CalculoJuros.Api.Configurations;
using MediatR.Extensions.Autofac.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace CalculoJuros.Api
{
    public class Startup
    {
        public IContainer Container { get; private set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ICalculaJurosRepository, CalculaJurosRepository > ();
            services.AddScoped<ICalcularJurosService, CalculaJurosService>();
            services.AddScoped<IMediatorHandler, MediatorHandler>();

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

            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(Assembly.GetAssembly(this.GetType())).AsImplementedInterfaces();
            builder.AddAutoMapper(typeof(Startup));
            builder.Populate(services);
            builder.AddMediatR(Assembly.GetAssembly(this.GetType()));

            Container = builder.Build();
            return new AutofacServiceProvider(Container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
