using Npgsql;
using System.Data;

namespace DivicesSesorApi.Data
{
    public class DataBaseConnection : IDbConnectionFactory
    {
        private readonly string _connectionString;
        public DataBaseConnection(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("PostgreSQL");
        }

        public IDbConnection CreateConnection()
        {
            return new NpgsqlConnection(_connectionString);
        }
    }
}
