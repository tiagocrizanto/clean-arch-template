using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using Upstack.Faq.Domain.Question;
using Upstack.Faq.Infrastructure.Data.SqlServer;

namespace Upstack.Faq.Api.DependencyInjection.DataAccess
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
