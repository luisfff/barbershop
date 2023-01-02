using System.Data;

namespace BarberShop.Infrastructure
{
    public interface IConnectionProvider
    {
        IDbConnection GetConnection();
    }
}