using System.Data;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;

namespace BarberShop.Infrastructure.Connection
{
    public class ConnectionProvider : IConnectionProvider
    {
        private readonly IConfiguration _configuration;

        public ConnectionProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection GetConnection()
        {
            var firstRun = !File.Exists("barbershop.sqlite");
            var connectionString = _configuration.GetConnectionString("DbConnectionString");

            var conn = new SqliteConnection(connectionString);
            conn.Open();
            if (firstRun)
            {
                CreateMissingTables(conn);
                InsertData(conn);
            }
            return conn;
        }

        private static void CreateMissingTables(SqliteConnection conn)
        {
            using var cmd = conn.CreateCommand();

           cmd.CommandText = @"CREATE TABLE Bookings(Id INTEGER PRIMARY KEY AUTOINCREMENT, 
UserId BIGINT,
BookingDateTime DATETIME,
CreatedAt DATETIME)";

            cmd.ExecuteNonQuery();
        }

        static void InsertData(SqliteConnection conn)
        {
            using var cmd = conn.CreateCommand();

            cmd.CommandText = @"INSERT INTO Bookings(Id, UserId,BookingDateTime) VALUES(1,1,'2022-01-01','2022-01-01')";
            cmd.CommandText = @"INSERT INTO Bookings(Id, UserId,BookingDateTime) VALUES(2,2,'2022-06-02T11:18:25.000','2022-06-02T11:18:25.000')";
            cmd.ExecuteNonQuery();
        }
    }
}