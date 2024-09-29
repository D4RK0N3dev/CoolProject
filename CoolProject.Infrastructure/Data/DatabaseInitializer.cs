// CoolProject.Infrastructure/Data/DatabaseInitializer.cs
using System.Data.SQLite;
using Microsoft.Extensions.Configuration;

namespace CoolProject.Infrastructure.Data
{
    public class DatabaseInitializer
    {
        private readonly string _connectionString;

        public DatabaseInitializer(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public void Initialize()
        {
            using var connection = new SQLiteConnection(_connectionString);
            connection.Open();

            using var commandUsers = new SQLiteCommand(connection);
            commandUsers.CommandText = @"
                CREATE TABLE IF NOT EXISTS Users (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Username TEXT NOT NULL,
                    PasswordHash TEXT NOT NULL,
                    Role TEXT NOT NULL
                )";
            commandUsers.ExecuteNonQuery();
            using var readerUsers = commandUsers.ExecuteReader();
            while (readerUsers.Read())
            {
                var url = readerUsers.GetString(0);
                Console.WriteLine(url);
            }

            using var commandProducts = new SQLiteCommand(connection);
            commandProducts.CommandText = @"
                CREATE TABLE IF NOT EXISTS Products (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL,
                    Price DECIMAL NOT NULL,
                    CategoryId INTEGER NOT NULL
                )";
            commandProducts.ExecuteNonQuery();
            using var readerProducts = commandProducts.ExecuteReader();
            while (readerProducts.Read())
            {
                var url = readerProducts.GetString(0);
                Console.WriteLine(url);
            }
        }
    }
}
