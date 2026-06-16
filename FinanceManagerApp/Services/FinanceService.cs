using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceManagerApp.Data;
using FinanceManagerApp.Models;

namespace FinanceManagerApp.Services
{
    public class FinanceService
    {
        private readonly TransactionRepository _transactionRepo = new TransactionRepository();
        private readonly BudgetRepository _budgetRepo = new BudgetRepository();
        private readonly CategoryRepository _categoryRepo = new CategoryRepository();

        public decimal GetBalance(int userId, DateTime? upToDate = null)
        {
            var all = _transactionRepo.GetFiltered(userId, null, upToDate ?? DateTime.MaxValue);
            decimal income = all.Where(t => t.CategoryType == "Income").Sum(t => t.Amount);
            decimal expense = all.Where(t => t.CategoryType == "Expense").Sum(t => t.Amount);
            return income - expense;
        }

        public (decimal Income, decimal Expense) GetMonthlySummary(int userId, int year, int month)
        {
            var from = new DateTime(year, month, 1);
            var to = from.AddMonths(1).AddDays(-1);
            var list = _transactionRepo.GetFiltered(userId, from, to);
            decimal income = list.Where(t => t.CategoryType == "Income").Sum(t => t.Amount);
            decimal expense = list.Where(t => t.CategoryType == "Expense").Sum(t => t.Amount);
            return (income, expense);
        }

        public Dictionary<string, decimal> GetExpenseStructure(int userId, DateTime from, DateTime to)
        {
            var list = _transactionRepo.GetFiltered(userId, from, to, type: "Expense");
            return list.GroupBy(t => t.CategoryName)
                       .ToDictionary(g => g.Key, g => g.Sum(t => t.Amount));
        }

        public List<(Budget Budget, decimal Actual, decimal Remain, double Percent)> GetBudgetStatus(
            int userId, int year, int month)
        {
            var budgets = _budgetRepo.GetByUserAndPeriod(userId, year, month);
            var result = new List<(Budget, decimal, decimal, double)>();
            var from = new DateTime(year, month, 1);
            var to = from.AddMonths(1).AddDays(-1);

            foreach (var b in budgets)
            {
                var actual = _transactionRepo.GetFiltered(userId, from, to, b.CategoryId, "Expense")
                                             .Sum(t => t.Amount);
                var remain = b.PlannedAmount - actual;
                double percent = b.PlannedAmount > 0 ? Math.Round((double)actual / (double)b.PlannedAmount * 100, 1) : 0;
                result.Add((b, actual, remain, percent));
            }
            return result;
        }
    }
}
