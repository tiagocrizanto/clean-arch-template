using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Upstack.Faq.Infrastructure.Data.Configuration;

namespace Upstack.Faq.Api.DependencyInjection.DataAccess
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
