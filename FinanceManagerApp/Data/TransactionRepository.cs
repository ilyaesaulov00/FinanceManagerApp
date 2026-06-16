using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceManagerApp.Models;
using System.Data.SqlClient;

namespace FinanceManagerApp.Data
{
    public class TransactionRepository
    {
        public List<Transaction> GetFiltered(int userId, DateTime? from = null, DateTime? to = null,
            int? categoryId = null, string type = null)
        {
            var list = new List<Transaction>();
            var sql = new StringBuilder(
                @"SELECT t.Id, t.UserId, t.CategoryId, c.Name, c.Type, t.Amount, t.[Date], t.Note
                  FROM [Transaction] t
                  JOIN Category c ON t.CategoryId = c.Id
                  WHERE t.UserId = @userId");

            var parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@userId", userId));

            if (from.HasValue)
            {
                sql.Append(" AND t.[Date] >= @from");
                parameters.Add(new SqlParameter("@from", from.Value));
            }
            if (to.HasValue)
            {
                sql.Append(" AND t.[Date] <= @to");
                parameters.Add(new SqlParameter("@to", to.Value));
            }
            if (categoryId.HasValue)
            {
                sql.Append(" AND t.CategoryId = @catId");
                parameters.Add(new SqlParameter("@catId", categoryId.Value));
            }
            if (!string.IsNullOrEmpty(type))
            {
                sql.Append(" AND c.Type = @type");
                parameters.Add(new SqlParameter("@type", type));
            }

            sql.Append(" ORDER BY t.[Date] DESC");

            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = new SqlCommand(sql.ToString(), conn))
            {
                cmd.Parameters.AddRange(parameters.ToArray());
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        list.Add(new Transaction
                        {
                            Id = reader.GetInt32(0),
                            UserId = reader.GetInt32(1),
                            CategoryId = reader.GetInt32(2),
                            CategoryName = reader.GetString(3),
                            CategoryType = reader.GetString(4),
                            Amount = reader.GetDecimal(5),
                            Date = reader.GetDateTime(6),
                            Note = reader.IsDBNull(7) ? null : reader.GetString(7)
                        });
                }
            }
            return list;
        }

        public Transaction GetById(int id)
        {
            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = new SqlCommand(
                @"SELECT t.Id, t.UserId, t.CategoryId, c.Name, c.Type, t.Amount, t.[Date], t.Note
                  FROM [Transaction] t JOIN Category c ON t.CategoryId = c.Id
                  WHERE t.Id = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                        return new Transaction
                        {
                            Id = reader.GetInt32(0),
                            UserId = reader.GetInt32(1),
                            CategoryId = reader.GetInt32(2),
                            CategoryName = reader.GetString(3),
                            CategoryType = reader.GetString(4),
                            Amount = reader.GetDecimal(5),
                            Date = reader.GetDateTime(6),
                            Note = reader.IsDBNull(7) ? null : reader.GetString(7)
                        };
                }
            }
            return null;
        }

        public int Create(Transaction transaction)
        {
            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = new SqlCommand(
                @"INSERT INTO [Transaction] (UserId, CategoryId, Amount, [Date], Note)
                  VALUES (@uid, @cid, @amount, @date, @note); SELECT SCOPE_IDENTITY();", conn))
            {
                cmd.Parameters.AddWithValue("@uid", transaction.UserId);
                cmd.Parameters.AddWithValue("@cid", transaction.CategoryId);
                cmd.Parameters.AddWithValue("@amount", transaction.Amount);
                cmd.Parameters.AddWithValue("@date", transaction.Date);
                cmd.Parameters.AddWithValue("@note", (object)transaction.Note ?? DBNull.Value);
                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public void Update(Transaction transaction)
        {
            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = new SqlCommand(
                @"UPDATE [Transaction]
                  SET CategoryId = @cid, Amount = @amount, [Date] = @date, Note = @note
                  WHERE Id = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", transaction.Id);
                cmd.Parameters.AddWithValue("@cid", transaction.CategoryId);
                cmd.Parameters.AddWithValue("@amount", transaction.Amount);
                cmd.Parameters.AddWithValue("@date", transaction.Date);
                cmd.Parameters.AddWithValue("@note", (object)transaction.Note ?? DBNull.Value);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = new SqlCommand("DELETE FROM [Transaction] WHERE Id = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
