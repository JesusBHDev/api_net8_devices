using Dapper;
using DivicesSesorApi.Data;
using DivicesSesorApi.Models;

namespace DivicesSesorApi.Repositories
{
    //aqui esta SQL,dapper conexion ala bd
    public class TemperatureSensorRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;


        public TemperatureSensorRepository(IDbConnectionFactory dbConnectionFactory)
        {
            //Entonces .NET pregunta: "¿Quién implementa IDbConnectionFactory?" 
            // y recibe DataBaseConnection  porque se registro AddSingleton<IDbConnectionFactory, DataBaseConnection>()
            _dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<IEnumerable<TemperatureSensorModel>> GetLastSensorsAsync()
        {
            //query
            const string sql = """
                SELECT * 
                FROM
                temperature_sensors
                ORDER BY id DESC
                LIMIT 5;
                """;

            //abre y cierra automaticamente la conexion using "Cuando termines, cierra/libera la conexión"
            using var connection = _dbConnectionFactory.CreateConnection();

            //Aquí entra Dapper.
            //1 Aquí entra Dapper.
            // 2 PostgreSQL devuelve filas. ejemplo id | sensor_name | last_temperature
            //Dapper convierte filas → objetos C#. por esto <TemperatureSensorModel>
            return await connection.QueryAsync<TemperatureSensorModel>(sql);
            //await Porque PostgreSQL tarda un poco. y pues devuelve los datos
        }

        public async Task<IEnumerable<InformationSensor>> GetInformationSesorBasic()
        {
            const string sql = """
                Select id, sensor_name, description
                from temperature_sensors order by id desc limit 5
                """;

            using var connetion = _dbConnectionFactory.CreateConnection();

            return await connetion.QueryAsync<InformationSensor>(sql);
        }
    
        public async Task<TemperatureSensorModel?> GetByAsync(int id)
        {
            const string sql = """
                Select * from 
                temperature_sensors 
                where id = @id;
                """;

            using var connection = _dbConnectionFactory.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<TemperatureSensorModel>(sql, new { Id = id });

        }

        public async Task<int> InsertSensor(SensorRegister sensor)
        {
            const string sql = """
        INSERT INTO temperature_sensors
        (
            sensor_name,
            description,
            ip_address,
            is_online,
            last_temperature,
            last_report_at,
            created_at
        )
        VALUES
        (
            @SensorName,
            @Description,
            '0.0.0.0',
            @IsOnline,
            NULL,
            NULL,
            CURRENT_TIMESTAMP
        )
        RETURNING id;
        """;

            using var connection = _dbConnectionFactory.CreateConnection();

            return await connection.QuerySingleAsync<int>(sql, sensor);
        }



    }
}
