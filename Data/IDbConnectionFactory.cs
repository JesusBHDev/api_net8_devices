using System.Data;

namespace DivicesSesorApi.Data
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}
