using System.Data;
using Microsoft.Data.Sqlite;

namespace BarberShop.Infrastructure.Connection
{
    public class ConnectionProvider : IConnectionProvider
    {
        public IDbConnection GetConnection()
        {
            var conn = new SqliteConnection(@"Data Source=barbershop.sqlite;Pooling=true;");
            conn.Open();

            return conn;
        }
    }
}