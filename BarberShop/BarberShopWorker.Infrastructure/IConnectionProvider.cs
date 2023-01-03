using System.Data;

namespace BarberShopWorker.Infrastructure
{
    public interface IConnectionProvider
    {
        IDbConnection GetConnection();
    }
}