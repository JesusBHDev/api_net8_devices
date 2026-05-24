using Dapper;
using DivicesSesorApi.Data;
using DivicesSesorApi.Models;

namespace DivicesSesorApi.Repositories
{
    public class TemperatureSensorRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;

        public TemperatureSensorRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<IEnumerable<TemperatureSensorModel>>
            GetLastSensorsAsync()
        {
            const string sql = """
                SELECT *
                FROM temperature_sensors
                ORDER BY id DESC
                LIMIT 5;
                """;
            using var connection = _dbConnectionFactory.CreateConnection();

            return await connection.QueryAsync<
                TemperatureSensorModel>(sql);
        }
    }
}
