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

namespace FinanceManagerApp.Forms
{
    public partial class TransactionEditForm : Form
    {
        private readonly int _userId;
        private readonly Transaction _existingTransaction;
        private readonly CategoryRepository _categoryRepo = new CategoryRepository();
        private readonly TransactionRepository _transactionRepo = new TransactionRepository();

        public TransactionEditForm(int userId, Transaction transaction = null)
        {
            InitializeComponent();
            _userId = userId;
            _existingTransaction = transaction;

            LoadCategories();

            if (_existingTransaction != null)
            {
                cmbCategory.SelectedValue = _existingTransaction.CategoryId;
                nudAmount.Value = _existingTransaction.Amount;
                dtpDate.Value = _existingTransaction.Date;
                txtNote.Text = _existingTransaction.Note ?? "";
                this.Text = "Редактирование операции";
            }
            else
            {
                dtpDate.Value = DateTime.Now;
                this.Text = "Новая операция";
            }
        }

        private void LoadCategories()
        {
            var categories = _categoryRepo.GetAll(_userId);
            cmbCategory.DataSource = categories;
            cmbCategory.DisplayMember = "Name";
            cmbCategory.ValueMember = "Id";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbCategory.SelectedItem == null)
            {
                MessageBox.Show("Выберите категорию.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var transaction = _existingTransaction ?? new Transaction();
            transaction.UserId = _userId;
            transaction.CategoryId = (int)cmbCategory.SelectedValue;
            transaction.Amount = nudAmount.Value;
            transaction.Date = dtpDate.Value;
            transaction.Note = string.IsNullOrWhiteSpace(txtNote.Text) ? null : txtNote.Text.Trim();

            try
            {
                if (transaction.Id == 0)
                    _transactionRepo.Create(transaction);
                else
                    _transactionRepo.Update(transaction);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void lblNote_Click(object sender, EventArgs e)
        {

        }
    }
}
