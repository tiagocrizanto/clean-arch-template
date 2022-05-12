using System.Diagnostics.CodeAnalysis;

namespace Company.Project.Infrastructure.Data.Configuration
{
    [ExcludeFromCodeCoverage]
    public class DatabasesConnections
    {
        public DatabaseConnectionName Name { get; set; }
        public DatabaseConnectionType Type { get; set; }
        public string ConnectionString { get; set; }
    }
}
