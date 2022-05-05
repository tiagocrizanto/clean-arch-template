using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using Upstack.Faq.Api.DependencyInjection.DataAccess;
using Upstack.Faq.Application.UseCases.LoadQuestions;
using Upstack.Faq.Application.UseCases.NewQuestion;
using Upstack.Faq.Infrastructure.Data.Configuration;

namespace Upstack.Fab.Apu
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
            IEnumerable<DatabasesConnections> databaseConnections = new List<DatabasesConnections>
            {
                new DatabasesConnections
                {
                    Name = DatabaseConnectionName.SqlServerUpstackFaq,
                    Type = DatabaseConnectionType.SqlServer,
                    ConnectionString = Configuration.GetConnectionString("SqlServerUpstackFaq")
                }
            };

            services.AddDbConnectionFactory(databaseConnections);
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Upstack.Faq.Api", Version = "v1" });
                c.EnableAnnotations();
            });
            AddVersion(services);

            services.AddMediatR(typeof(LoadQuestions));
            services.AddMediatR(typeof(NewQuestion));
            services.AddRepositories();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Upstack.Fab.Apu v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static void AddVersion(IServiceCollection services)
        {
            services.AddApiVersioning(p =>
            {
                p.DefaultApiVersion = new ApiVersion(1, 0);
                p.ReportApiVersions = true;
                p.AssumeDefaultVersionWhenUnspecified = true;
            });

            services.AddVersionedApiExplorer(p =>
            {
                p.GroupNameFormat = "'v'VVV";
                p.SubstituteApiVersionInUrl = true;
            });
        }
    }
}
