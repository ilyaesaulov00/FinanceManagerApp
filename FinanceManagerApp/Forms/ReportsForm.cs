using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using FinanceManagerApp.Data;
using FinanceManagerApp.Services;
using System.Windows.Forms.DataVisualization.Charting;
using ClosedXML.Excel;
using System.Collections.Generic;
using FinanceManagerApp.Models;

namespace FinanceManagerApp.Forms
{
    public partial class ReportsForm : Form
    {
        private readonly int _userId;
        private readonly FinanceService _financeService = new FinanceService();

        private decimal _balance, _income, _expense;
        private DateTime _from, _to;
        private Dictionary<string, decimal> _expenseStructure;
        private List<(Budget Budget, decimal Actual, decimal Remain, double Percent)> _budgetStatus;

        public ReportsForm(int userId)
        {
            InitializeComponent();
            _userId = userId;
            dtpFrom.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpTo.Value = DateTime.Now;
        }

        private void btnBuild_Click(object sender, EventArgs e)
        {
            _from = dtpFrom.Value.Date;
            _to = dtpTo.Value.Date.AddDays(1).AddSeconds(-1);

            _balance = _financeService.GetBalance(_userId, _to);
            var allTransactions = new TransactionRepository().GetFiltered(_userId, _from, _to);
            _income = allTransactions.Where(t => t.CategoryType == "Income").Sum(t => t.Amount);
            _expense = allTransactions.Where(t => t.CategoryType == "Expense").Sum(t => t.Amount);

            lblBalance.Text = $"Баланс за период: {_balance:C2}";
            lblIncome.Text = $"Доходы: {_income:C2}";
            lblExpense.Text = $"Расходы: {_expense:C2}";

            _expenseStructure = _financeService.GetExpenseStructure(_userId, _from, _to);
            chartStructure.Series.Clear();
            var pieSeries = new Series("Расходы")
            {
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = true
            };
            foreach (var kvp in _expenseStructure)
                pieSeries.Points.AddXY(kvp.Key, (double)kvp.Value);
            chartStructure.Series.Add(pieSeries);

            BuildPlanFactChart(_from);
        }

        private void BuildPlanFactChart(DateTime periodStart)
        {
            int year = periodStart.Year;
            int month = periodStart.Month;

            _budgetStatus = _financeService.GetBudgetStatus(_userId, year, month);
            var data = _budgetStatus
                .Where(b => b.Actual > 0 || b.Budget.PlannedAmount > 0)
                .ToDictionary(
                    b => b.Budget.CategoryName,
                    b => (Plan: b.Budget.PlannedAmount, Fact: b.Actual)
                );

            chartPlanFact.Series.Clear();
            chartPlanFact.ChartAreas[0].AxisX.Title = "Категория";
            chartPlanFact.ChartAreas[0].AxisY.Title = "Сумма, ₽";

            var seriesPlan = new Series("План")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.SteelBlue
            };
            var seriesFact = new Series("Факт")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.OrangeRed
            };

            foreach (var kvp in data)
            {
                seriesPlan.Points.AddXY(kvp.Key, (double)kvp.Value.Plan);
                seriesFact.Points.AddXY(kvp.Key, (double)kvp.Value.Fact);
            }

            chartPlanFact.Series.Add(seriesPlan);
            chartPlanFact.Series.Add(seriesFact);
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (_expenseStructure == null)
            {
                MessageBox.Show("Сначала сформируйте отчёт, нажав «Сформировать».",
                    "Экспорт", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel files (*.xlsx)|*.xlsx";
                sfd.FileName = $"Отчёт_{DateTime.Now:yyyy-MM-dd_HH-mm}.xlsx";
                if (sfd.ShowDialog() != DialogResult.OK) return;

                try
                {
                    using (var workbook = new XLWorkbook())
                    {
                        var wsSummary = workbook.Worksheets.Add("Статистика");
                        wsSummary.Cell(1, 1).Value = "Показатель";
                        wsSummary.Cell(1, 2).Value = "Значение";
                        wsSummary.Cell(2, 1).Value = "Период с";
                        wsSummary.Cell(2, 2).Value = _from.ToShortDateString();
                        wsSummary.Cell(3, 1).Value = "Период по";
                        wsSummary.Cell(3, 2).Value = _to.ToShortDateString();
                        wsSummary.Cell(4, 1).Value = "Баланс";
                        wsSummary.Cell(4, 2).Value = _balance;
                        wsSummary.Cell(5, 1).Value = "Доходы";
                        wsSummary.Cell(5, 2).Value = _income;
                        wsSummary.Cell(6, 1).Value = "Расходы";
                        wsSummary.Cell(6, 2).Value = _expense;

                        var range = wsSummary.Range("A1:B6");
                        range.Style.Font.SetBold(true);
                        wsSummary.Columns().AdjustToContents();

                        if (_expenseStructure.Any())
                        {
                            var wsExp = workbook.Worksheets.Add("Расходы по категориям");
                            wsExp.Cell(1, 1).Value = "Категория";
                            wsExp.Cell(1, 2).Value = "Сумма";
                            int row = 2;
                            foreach (var kvp in _expenseStructure)
                            {
                                wsExp.Cell(row, 1).Value = kvp.Key;
                                wsExp.Cell(row, 2).Value = kvp.Value;
                                row++;
                            }
                            wsExp.Columns().AdjustToContents();
                        }

                        if (_budgetStatus != null && _budgetStatus.Any())
                        {
                            var wsBud = workbook.Worksheets.Add("Бюджет (план-факт)");
                            wsBud.Cell(1, 1).Value = "Категория";
                            wsBud.Cell(1, 2).Value = "План";
                            wsBud.Cell(1, 3).Value = "Факт";
                            wsBud.Cell(1, 4).Value = "Остаток";
                            wsBud.Cell(1, 5).Value = "% выполнения";
                            int row = 2;
                            foreach (var item in _budgetStatus)
                            {
                                wsBud.Cell(row, 1).Value = item.Budget.CategoryName;
                                wsBud.Cell(row, 2).Value = item.Budget.PlannedAmount;
                                wsBud.Cell(row, 3).Value = item.Actual;
                                wsBud.Cell(row, 4).Value = item.Remain;
                                wsBud.Cell(row, 5).Value = item.Percent + "%";
                                row++;
                            }
                            wsBud.Columns().AdjustToContents();
                        }

                        workbook.SaveAs(sfd.FileName);
                    }
                    MessageBox.Show("Отчёт успешно экспортирован в Excel.",
                        "Экспорт", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при экспорте: {ex.Message}",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ReportsForm_Load(object sender, EventArgs e)
        {

        }
    }
}