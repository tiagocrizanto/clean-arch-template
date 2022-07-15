using Company.Project.Domain.Question;
using Company.Project.Infrastructure.Data.SqlServer;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Company.Project.Api.DependencyInjection.DataAccess
{
    [ExcludeFromCodeCoverage]
    public static class RepositoryExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IQuestionRepository, QuestionsRepository>();

            return services;
        }
    }
}
