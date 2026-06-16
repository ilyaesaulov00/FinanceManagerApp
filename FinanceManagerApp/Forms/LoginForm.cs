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
using Microsoft.VisualBasic;

namespace FinanceManagerApp.Forms
{
    public partial class LoginForm : Form
    {
        private readonly UserRepository _userRepo = new UserRepository();

        public LoginForm()
        {
            InitializeComponent();
            LoadUsers();
        }

        private void LoadUsers()
        {
            var users = _userRepo.GetAll();
            cmbUsers.DataSource = users;
            cmbUsers.DisplayMember = "FullName";
            cmbUsers.ValueMember = "Id";
            btnEnter.Enabled = users.Count > 0;
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (cmbUsers.SelectedItem is User selectedUser)
            {
                this.Hide();
                var mainForm = new MainForm(selectedUser);
                mainForm.FormClosed += (s, args) => this.Close();
                mainForm.Show();
            }
        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            string input = Interaction.InputBox("Введите имя нового пользователя:", "Новый профиль", "");
            if (!string.IsNullOrWhiteSpace(input))
            {
                var newUser = new User { FullName = input.Trim(), Type = "Individual" };
                int userId = _userRepo.Create(newUser);

                // Добавляем стандартные категории для нового пользователя
                var defaultCategories = new List<Category>
                {
                    new Category { Name = "Зарплата", Type = "Income" },
                    new Category { Name = "Продукты", Type = "Expense" },
                    new Category { Name = "Транспорт", Type = "Expense" },
                    new Category { Name = "Развлечения", Type = "Expense" }
                };
                var catRepo = new CategoryRepository();
                foreach (var cat in defaultCategories)
                {
                    cat.UserId = userId;
                    catRepo.Create(cat);
                }

                LoadUsers();
                cmbUsers.SelectedIndex = cmbUsers.Items.Count - 1;
            }
        }
    }
}
