using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using FinanceManagerApp.Models;

namespace FinanceManagerApp.Data
{
    public class BudgetRepository
    {
        public List<Budget> GetByUserAndPeriod(int userId, int year, int month)
        {
            var list = new List<Budget>();
            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = new SqlCommand(
                @"SELECT b.Id, b.UserId, b.CategoryId, c.Name, b.Year, b.Month, b.PlannedAmount
                  FROM Budget b JOIN Category c ON b.CategoryId = c.Id
                  WHERE b.UserId = @uid AND b.Year = @year AND b.Month = @month
                  ORDER BY c.Name", conn))
            {
                cmd.Parameters.AddWithValue("@uid", userId);
                cmd.Parameters.AddWithValue("@year", year);
                cmd.Parameters.AddWithValue("@month", month);
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        list.Add(new Budget
                        {
                            Id = reader.GetInt32(0),
                            UserId = reader.GetInt32(1),
                            CategoryId = reader.GetInt32(2),
                            CategoryName = reader.GetString(3),
                            Year = reader.GetInt32(4),
                            Month = reader.GetByte(5),
                            PlannedAmount = reader.GetDecimal(6)
                        });
                }
            }
            return list;
        }

        public void DeleteByUserCategoryPeriod(int userId, int categoryId, int year, int month)
        {
            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = new SqlCommand(
                @"DELETE FROM Budget 
          WHERE UserId = @uid AND CategoryId = @cid AND [Year] = @year AND [Month] = @month", conn))
            {
                cmd.Parameters.AddWithValue("@uid", userId);
                cmd.Parameters.AddWithValue("@cid", categoryId);
                cmd.Parameters.AddWithValue("@year", year);
                cmd.Parameters.AddWithValue("@month", month);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void SaveOrUpdate(Budget budget)
        {
            // Если плановая сумма равна нулю – удаляем запись бюджета (если она была) и выходим
            if (budget.PlannedAmount == 0)
            {
                DeleteByUserCategoryPeriod(budget.UserId, budget.CategoryId, budget.Year, budget.Month);
                return;
            }

            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = new SqlCommand(
                @"MERGE Budget AS target
          USING (SELECT @uid, @cid, @year, @month) AS source (UserId, CategoryId, [Year], [Month])
          ON target.UserId = source.UserId AND target.CategoryId = source.CategoryId
             AND target.[Year] = source.[Year] AND target.[Month] = source.[Month]
          WHEN MATCHED THEN UPDATE SET PlannedAmount = @amount
          WHEN NOT MATCHED THEN
             INSERT (UserId, CategoryId, [Year], [Month], PlannedAmount)
             VALUES (@uid, @cid, @year, @month, @amount);", conn))
            {
                cmd.Parameters.AddWithValue("@uid", budget.UserId);
                cmd.Parameters.AddWithValue("@cid", budget.CategoryId);
                cmd.Parameters.AddWithValue("@year", budget.Year);
                cmd.Parameters.AddWithValue("@month", budget.Month);
                cmd.Parameters.AddWithValue("@amount", budget.PlannedAmount);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = new SqlCommand("DELETE FROM Budget WHERE Id = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
