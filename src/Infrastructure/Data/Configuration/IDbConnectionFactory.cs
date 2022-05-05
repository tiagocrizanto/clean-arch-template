using System.Data;

namespace Upstack.Faq.Infrastructure.Data.Configuration
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateDbConnection(DatabaseConnectionName databaseConnectionName);
    }
}
