using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Company.Project.Infrastructure.Data.Configuration
{
    public class DapperDbConnectionFactory : IDbConnectionFactory
    {
        private readonly IEnumerable<DatabasesConnections> _databasesConnections;
        public DapperDbConnectionFactory(IEnumerable<DatabasesConnections> databasesConnections)
        {
            _databasesConnections = databasesConnections;
        }

        public IDbConnection CreateDbConnection(DatabaseConnectionName databaseConnectionName)
        {
            var connection = _databasesConnections.First(x => x.Name == databaseConnectionName);

            if (connection is null)
                throw new System.Exception($"Error on finding connection {databaseConnectionName}");

            IDbConnection dbConnection;

            switch (connection.Type)
            {
                case DatabaseConnectionType.SqlServer:
                    dbConnection = new SqlConnection(connection.ConnectionString);
                    break;
                default:
                    throw new System.Exception($"Error on create connection {databaseConnectionName}");
            }

            return dbConnection;
        }
    }
}
