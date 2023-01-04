using System.Data;

namespace BarberShop.Infrastructure.Connection
{
    public interface IConnectionProvider
    {
        IDbConnection GetConnection();
    }
}