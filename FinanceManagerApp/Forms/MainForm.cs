using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinanceManagerApp.Models;
using FinanceManagerApp.Services;
using System.Windows.Forms.DataVisualization.Charting;

namespace FinanceManagerApp.Forms
{
    public partial class MainForm : Form
    {
        private readonly User _currentUser;
        private readonly FinanceService _financeService = new FinanceService();

        public MainForm(User user)
        {
            InitializeComponent();
            _currentUser = user;
            lblWelcome.Text = $"Добро пожаловать, {user.FullName}!";
            RefreshDashboard();
        }

        public void RefreshDashboard()
        {
            var now = DateTime.Now;
            decimal balance = _financeService.GetBalance(_currentUser.Id);
            var (income, expense) = _financeService.GetMonthlySummary(
                _currentUser.Id, now.Year, now.Month);

            lblBalance.Text = balance.ToString("C2");
            lblIncome.Text = income.ToString("C2");
            lblExpense.Text = expense.ToString("C2");

            var from = new DateTime(now.Year, now.Month, 1);
            var to = now;
            var expenses = _financeService.GetExpenseStructure(_currentUser.Id, from, to);

            chartExpenses.Series.Clear();
            var series = new Series("Расходы")
            {
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = true,
                Font = new Font("Microsoft Sans Serif", 8)
            };
            foreach (var kvp in expenses)
                series.Points.AddXY(kvp.Key, (double)kvp.Value);
            chartExpenses.Series.Add(series);
            chartExpenses.Legends[0].Enabled = true;
        }

        private void btnTransactions_Click(object sender, EventArgs e)
        {
            var form = new TransactionsForm(_currentUser.Id);
            form.ShowDialog();
            RefreshDashboard();
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            var form = new CategoriesForm(_currentUser.Id);
            form.ShowDialog();
            RefreshDashboard();
        }

        private void btnBudget_Click(object sender, EventArgs e)
        {
            var form = new BudgetForm(_currentUser.Id);
            form.ShowDialog();
            RefreshDashboard();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            var form = new ReportsForm(_currentUser.Id);
            form.ShowDialog();
        }

        private void btnSwitchUser_Click(object sender, EventArgs e)
        {
            this.Hide();
            var login = new LoginForm();
            login.FormClosed += (s, args) => this.Close();
            login.Show();
        }

        private void chartExpenses_Click(object sender, EventArgs e)
        {

        }

        private void lblExpenseCaption_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
