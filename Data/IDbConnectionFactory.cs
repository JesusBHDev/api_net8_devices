using System.Data;

namespace DivicesSesorApi.Data
{
    //interfaze es un contrato cuanquier clase que implmente esto debe tener este metodo
    public interface IDbConnectionFactory
    {
        IDbConnection CreateConnection();
    }
    //sin logica no sabe nada solo mandar a llamar un metodo 

}
