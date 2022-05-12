using System.Data;

namespace Company.Project.Infrastructure.Data.Configuration
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateDbConnection(DatabaseConnectionName databaseConnectionName);
    }
}
