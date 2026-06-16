// Forms/CategoryEditForm.cs
using System;
using System.Windows.Forms;
using FinanceManagerApp.Data;
using FinanceManagerApp.Models;
using Microsoft.VisualBasic.ApplicationServices;

namespace FinanceManagerApp.Forms
{
    public partial class CategoryEditForm : Form
    {
        private readonly int _userId;
        private readonly Category _existingCategory;
        private readonly CategoryRepository _categoryRepo = new CategoryRepository();

        public CategoryEditForm(int userId, Category category = null)
        {
            InitializeComponent();
            _userId = userId;
            cmbType.Items.AddRange(new[] { "Income", "Expense" });
            _existingCategory = category;

            if (_existingCategory != null)
            {
                txtName.Text = _existingCategory.Name;
                cmbType.SelectedItem = _existingCategory.Type;
                this.Text = "Редактирование категории";
            }
            else
            {
                cmbType.SelectedIndex = 0;
                this.Text = "Новая категория";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Введите название.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var category = _existingCategory ?? new Category();
            category.Name = txtName.Text.Trim();
            category.Type = cmbType.SelectedItem.ToString();
            category.UserId = _userId;

            try
            {
                if (category.Id == 0)
                    _categoryRepo.Create(category);
                else
                    _categoryRepo.Update(category);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}