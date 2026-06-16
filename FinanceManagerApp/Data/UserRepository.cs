using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using FinanceManagerApp.Models;

namespace FinanceManagerApp.Data
{
    public class UserRepository
    {
        public List<User> GetAll()
        {
            var list = new List<User>();
            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = new SqlCommand("SELECT Id, FullName, Type FROM [User] ORDER BY FullName", conn))
            {
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        list.Add(new User
                        {
                            Id = reader.GetInt32(0),
                            FullName = reader.GetString(1),
                            Type = reader.GetString(2)
                        });
                }
            }
            return list;
        }

        public User GetById(int id)
        {
            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = new SqlCommand("SELECT Id, FullName, Type FROM [User] WHERE Id = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                        return new User
                        {
                            Id = reader.GetInt32(0),
                            FullName = reader.GetString(1),
                            Type = reader.GetString(2)
                        };
                }
            }
            return null;
        }

        public int Create(User user)
        {
            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = new SqlCommand(
                "INSERT INTO [User] (FullName, Type) VALUES (@name, @type); SELECT SCOPE_IDENTITY();", conn))
            {
                cmd.Parameters.AddWithValue("@name", user.FullName);
                cmd.Parameters.AddWithValue("@type", user.Type);
                conn.Open();
                return System.Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public void Update(User user)
        {
            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = new SqlCommand(
                "UPDATE [User] SET FullName = @name, Type = @type WHERE Id = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", user.Id);
                cmd.Parameters.AddWithValue("@name", user.FullName);
                cmd.Parameters.AddWithValue("@type", user.Type);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = new SqlCommand("DELETE FROM [User] WHERE Id = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
