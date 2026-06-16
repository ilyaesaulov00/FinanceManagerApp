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
using Microsoft.VisualBasic.ApplicationServices;

namespace FinanceManagerApp.Forms
{
    public partial class CategoriesForm : Form
    {
        private readonly int _userId;
        private readonly CategoryRepository _categoryRepo = new CategoryRepository();

        public CategoriesForm(int userId)
        {
            InitializeComponent();
            _userId = userId;
            LoadData();
        }

        private void LoadData()
        {
            dgvCategories.DataSource = null;
            dgvCategories.DataSource = _categoryRepo.GetAll(_userId);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var form = new CategoryEditForm(_userId);
            if (form.ShowDialog() == DialogResult.OK)
                LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvCategories.SelectedRows.Count == 0) return;
            var category = (Category)dgvCategories.SelectedRows[0].DataBoundItem;
            var form = new CategoryEditForm(_userId, category);
            if (form.ShowDialog() == DialogResult.OK)
                LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCategories.SelectedRows.Count == 0) return;
            var category = (Category)dgvCategories.SelectedRows[0].DataBoundItem;
            if (MessageBox.Show($"Удалить категорию «{category.Name}»?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    _categoryRepo.Delete(category.Id);
                    LoadData();
                }
                catch (System.Data.SqlClient.SqlException ex) when (ex.Number == 547) // FK constraint
                {
                    MessageBox.Show("Нельзя удалить категорию, на которую есть ссылки в операциях или бюджете.",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
