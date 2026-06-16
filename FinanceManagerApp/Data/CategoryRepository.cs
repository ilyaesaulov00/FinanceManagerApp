using System.Collections.Generic;
using System.Data.SqlClient;
using FinanceManagerApp.Models;

namespace FinanceManagerApp.Data
{
    public class CategoryRepository
    {
        public List<Category> GetAll(int userId)
        {
            var list = new List<Category>();
            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = new SqlCommand(
                "SELECT Id, Name, Type, UserId FROM Category WHERE UserId = @userId ORDER BY Type, Name", conn))
            {
                cmd.Parameters.AddWithValue("@userId", userId);
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        list.Add(new Category
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Type = reader.GetString(2),
                            UserId = reader.GetInt32(3)
                        });
                }
            }
            return list;
        }

        public Category GetById(int id)
        {
            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = new SqlCommand(
                "SELECT Id, Name, Type, UserId FROM Category WHERE Id = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                        return new Category
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Type = reader.GetString(2),
                            UserId = reader.GetInt32(3)
                        };
                }
            }
            return null;
        }

        public List<Category> GetByType(int userId, string type)
        {
            var list = new List<Category>();
            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = new SqlCommand(
                "SELECT Id, Name, Type, UserId FROM Category WHERE UserId = @userId AND Type = @type ORDER BY Name", conn))
            {
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@type", type);
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        list.Add(new Category
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Type = reader.GetString(2),
                            UserId = reader.GetInt32(3)
                        });
                }
            }
            return list;
        }

        public int Create(Category category)
        {
            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = new SqlCommand(
                "INSERT INTO Category (Name, Type, UserId) VALUES (@name, @type, @userId); SELECT SCOPE_IDENTITY();", conn))
            {
                cmd.Parameters.AddWithValue("@name", category.Name);
                cmd.Parameters.AddWithValue("@type", category.Type);
                cmd.Parameters.AddWithValue("@userId", category.UserId);
                conn.Open();
                return System.Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public void Update(Category category)
        {
            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = new SqlCommand(
                "UPDATE Category SET Name = @name, Type = @type WHERE Id = @id AND UserId = @userId", conn))
            {
                cmd.Parameters.AddWithValue("@id", category.Id);
                cmd.Parameters.AddWithValue("@name", category.Name);
                cmd.Parameters.AddWithValue("@type", category.Type);
                cmd.Parameters.AddWithValue("@userId", category.UserId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = new SqlCommand("DELETE FROM Category WHERE Id = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}