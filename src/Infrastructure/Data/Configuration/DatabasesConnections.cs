using System.Diagnostics.CodeAnalysis;

namespace Upstack.Faq.Infrastructure.Data.Configuration
{
    [ExcludeFromCodeCoverage]
    public class DatabasesConnections
    {
        public DatabaseConnectionName Name { get; set; }
        public DatabaseConnectionType Type { get; set; }
        public string ConnectionString { get; set; }
    }
}
