using System.Reflection;
using Application.Common.Behaviours;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using RestApi;

namespace WebUI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            Assembly applicationAssembly = Assembly.Load("Application");
            
            services.AddMediatR(applicationAssembly);
            
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            services.AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssembly(applicationAssembly));
            
            services.AddControllers().AddApplicationPart(typeof(HttpApiControllerBase).Assembly);
            services.AddSwaggerGen(configuration =>
            {
                configuration.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "My API", Version = "v1"
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

            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("v1/swagger.json", "My API V1"); });

            app.UseRouting();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}