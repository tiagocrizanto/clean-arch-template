using Company.Project.Api.DependencyInjection.DataAccess;
using Company.Project.Application.UseCases.LoadQuestions;
using Company.Project.Application.UseCases.NewQuestion;
using Company.Project.Infrastructure.Data.Configuration;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;

namespace Company.Project.Api
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
                    Name = DatabaseConnectionName.SqlServerDatabaseName,
                    Type = DatabaseConnectionType.SqlServer,
                    ConnectionString = Configuration.GetConnectionString("SqlServerDatabaseName")
                }
            };

            services.AddDbConnectionFactory(databaseConnections);
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Company.Project.Api", Version = "v1" });
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
