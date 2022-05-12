using Company.Project.Infrastructure.Data.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Company.Project.Api.DependencyInjection.DataAccess
{
    [ExcludeFromCodeCoverage]
    public static class DatabaseExtentions
    {
        public static IServiceCollection AddDbConnectionFactory(this IServiceCollection services, IEnumerable<DatabasesConnections> databasesConnections)
        {
            services.AddSingleton(databasesConnections);
            services.AddTransient<IDbConnectionFactory, DapperDbConnectionFactory>();

            return services;
        }
    }
}
