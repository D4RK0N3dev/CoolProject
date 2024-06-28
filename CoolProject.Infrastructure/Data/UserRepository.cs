// CoolProject.Infrastructure/Data/UserRepository.cs
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using CoolProject.Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace CoolProject.Infrastructure.Data
{
    public class UserRepository
    {
        private readonly string _connectionString;

        public UserRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public void AddUser(User user)
        {
            using var connection = new SQLiteConnection(_connectionString);
            connection.Open();
            using var command = new SQLiteCommand(connection);
            command.CommandText = "INSERT INTO Users (Username, PasswordHash, Role) VALUES (@Username, @PasswordHash, @Role)";
            command.Parameters.AddWithValue("@Username", user.Username);
            command.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
            command.Parameters.AddWithValue("@Role", user.Role);
            command.ExecuteNonQuery();
        }

        public User GetUser(string username)
        {
            using var connection = new SQLiteConnection(_connectionString);
            connection.Open();
            using var command = new SQLiteCommand(connection);
            command.CommandText = "SELECT * FROM Users WHERE Username = @Username";
            command.Parameters.AddWithValue("@Username", username);
            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new User
                {
                    Id = reader.GetInt32(0),
                    Username = reader.GetString(1),
                    PasswordHash = reader.GetString(2),
                    Role = reader.GetString(3)
                };
            }
            return null;
        }

        // Add other methods as needed (e.g., GetUsers, UpdateUser, DeleteUser)
    }
}
