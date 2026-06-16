// Forms/BudgetForm.cs
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using FinanceManagerApp.Data;
using FinanceManagerApp.Models;
using FinanceManagerApp.Services;

namespace FinanceManagerApp.Forms
{
    public partial class BudgetForm : Form
    {
        private readonly int _userId;
        private readonly BudgetRepository _budgetRepo = new BudgetRepository();
        private readonly CategoryRepository _categoryRepo = new CategoryRepository();

        public BudgetForm(int userId)
        {
            InitializeComponent();
            dgvBudget.AutoGenerateColumns = false;
            _userId = userId;

            for (int y = 2023; y <= 2030; y++) cmbYear.Items.Add(y);
            cmbYear.SelectedItem = DateTime.Now.Year;
            for (int m = 1; m <= 12; m++) cmbMonth.Items.Add(m);
            cmbMonth.SelectedItem = DateTime.Now.Month;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            int year = (int)cmbYear.SelectedItem;
            int month = (int)cmbMonth.SelectedItem;

            var expenseCategories = _categoryRepo.GetByType(_userId, "Expense");
            var budgets = _budgetRepo.GetByUserAndPeriod(_userId, year, month);

            var table = new DataTable();
            table.Columns.Add("CategoryId", typeof(int));
            table.Columns.Add("CategoryName", typeof(string));
            table.Columns.Add("PlannedAmount", typeof(decimal));
            table.Columns.Add("Actual", typeof(decimal));
            table.Columns.Add("Remain", typeof(decimal));
            table.Columns.Add("Percent", typeof(string));

            foreach (var cat in expenseCategories)
            {
                var budget = budgets.FirstOrDefault(b => b.CategoryId == cat.Id);
                decimal planned = budget?.PlannedAmount ?? 0;
                decimal actual = SumTransactionForCategory(cat.Id, year, month);
                decimal remain = planned - actual;
                string percent = planned > 0 ? $"{(actual / planned * 100):F1}%" : "—";
                table.Rows.Add(cat.Id, cat.Name, planned, actual, remain, percent);
            }

            dgvBudget.DataSource = table;
            if (dgvBudget.Columns["CategoryId"] != null)
                dgvBudget.Columns["CategoryId"].Visible = false;
        }

        private decimal SumTransactionForCategory(int categoryId, int year, int month)
        {
            var from = new DateTime(year, month, 1);
            var to = from.AddMonths(1).AddDays(-1);
            var transactionRepo = new TransactionRepository();
            return transactionRepo.GetFiltered(_userId, from, to, categoryId, "Expense")
                                  .Sum(t => t.Amount);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dgvBudget.DataSource is DataTable table)
            {
                int year = (int)cmbYear.SelectedItem;
                int month = (int)cmbMonth.SelectedItem;
                foreach (DataRow row in table.Rows)
                {
                    int catId = (int)row["CategoryId"];
                    decimal planned = Convert.ToDecimal(row["PlannedAmount"]);
                    if (planned < 0) planned = 0;
                    _budgetRepo.SaveOrUpdate(new Budget
                    {
                        UserId = _userId,
                        CategoryId = catId,
                        Year = year,
                        Month = month,
                        PlannedAmount = planned
                    });
                }
                MessageBox.Show("Бюджет сохранён.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnLoad.PerformClick();
            }
        }
    }
}