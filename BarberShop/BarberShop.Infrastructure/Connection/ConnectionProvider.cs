﻿using System.Data;
using Microsoft.Data.Sqlite;

namespace BarberShop.Infrastructure.Connection
{
    public class ConnectionProvider : IConnectionProvider
    {
        public IDbConnection GetConnection()
        {
            var firstRun = !File.Exists("barbershop.sqlite");
            var conn = new SqliteConnection(@"Data Source=barbershop.sqlite;Pooling=true;");
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

           cmd.CommandText = @"CREATE TABLE Bookings(Id INTEGER PRIMARY KEY AUTOINCREMENT, UserId BIGINT, BookingDateTime DATETIME)";

            cmd.ExecuteNonQuery();
        }

        static void InsertData(SqliteConnection conn)
        {
            using var cmd = conn.CreateCommand();

            cmd.CommandText = @"INSERT INTO Bookings(Id, UserId,BookingDateTime) VALUES(1,1,'2022-01-01')";
            cmd.CommandText = @"INSERT INTO Bookings(Id, UserId,BookingDateTime) VALUES(2,2,'2022-06-02T11:18:25.000')";
            cmd.ExecuteNonQuery();
        }
    }
}