using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinanceManagerApp.Data;
using FinanceManagerApp.Models;
using System.Diagnostics;

namespace FinanceManagerApp.Forms
{
    public partial class TransactionsForm : Form
    {
        private readonly int _userId;
        private readonly TransactionRepository _transactionRepo = new TransactionRepository();
        private readonly CategoryRepository _categoryRepo = new CategoryRepository();

        public TransactionsForm(int userId)
        {
            InitializeComponent();
            _userId = userId;
            SetupFilters();
            LoadData();
        }

        private void SetupFilters()
        {
            dtpFrom.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpTo.Value = DateTime.Now;

            var categories = _categoryRepo.GetAll(_userId);
            categories.Insert(0, new Category { Id = 0, Name = "Все категории" });
            cmbCategory.DataSource = categories;
            cmbCategory.DisplayMember = "Name";
            cmbCategory.ValueMember = "Id";
        }

        private void LoadData()
        {
            DateTime from = dtpFrom.Value.Date;
            DateTime to = dtpTo.Value.Date.AddDays(1).AddSeconds(-1);
            int? catId = (int)cmbCategory.SelectedValue == 0 ? (int?)null : (int)cmbCategory.SelectedValue;

            var transactions = _transactionRepo.GetFiltered(_userId, from, to, catId);


            dgvTransactions.DataSource = transactions;
        }

        private void btnFilter_Click(object sender, EventArgs e) => LoadData();

        private void btnAdd_Click(object sender, EventArgs e)
        {

            var form = new TransactionEditForm(_userId);
            if (form.ShowDialog() == DialogResult.OK)
                LoadData();

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvTransactions.SelectedRows.Count == 0) return;
            var transaction = (Transaction)dgvTransactions.SelectedRows[0].DataBoundItem;
            var form = new TransactionEditForm(_userId, transaction);
            if (form.ShowDialog() == DialogResult.OK)
                LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvTransactions.SelectedRows.Count == 0) return;
            var transaction = (Transaction)dgvTransactions.SelectedRows[0].DataBoundItem;
            if (MessageBox.Show($"Удалить операцию #{transaction.Id}?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _transactionRepo.Delete(transaction.Id);
                LoadData();
            }
        }
    }
}
