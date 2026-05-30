using Npgsql;
using System.Data;

namespace DivicesSesorApi.Data
{
    //"DataBaseConnection implementa el contrato IDbConnectionFactory"
    //Entonces OBLIGATORIAMENTE debe tener: CreateConnection()
    public class DataBaseConnection : IDbConnectionFactory
    {
        // para guardar la cadena 
        private readonly string _connectionString;

        //IConfiguration Es un objeto de ASP.NET que sabe leer:
        //appsettings.json,  variables de entorno, configuracion
        public DataBaseConnection(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("PostgreSQL"); // le dices busca ConnectionStrings
        }

        public IDbConnection CreateConnection()
        {
            //aqui retonas una conexion creada con la cadena de conexion
            //Aquí entra el desacoplamiento. 
            return new NpgsqlConnection(_connectionString);

            //Podría devolver directamente:NpgsqlConnection pero 
            //devuelvo IDbConnection Repository NO depende específicamente de PostgreSQL.
            //Depende de una abstracción.
            //no sabe si es postgres, sql server, mysql, oracle
        }
    }
}
