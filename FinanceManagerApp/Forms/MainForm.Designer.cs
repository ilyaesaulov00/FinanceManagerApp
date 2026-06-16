namespace FinanceManagerApp.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.gbSummary = new System.Windows.Forms.GroupBox();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnBudget = new System.Windows.Forms.Button();
            this.btnCategories = new System.Windows.Forms.Button();
            this.btnTransactions = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblExpenseCaption = new System.Windows.Forms.Label();
            this.lblExpense = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblIncomeCaption = new System.Windows.Forms.Label();
            this.lblIncome = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblBalanceCaption = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSwitchUser = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.chartExpenses = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.gbSummary.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartExpenses)).BeginInit();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.lblWelcome.Location = new System.Drawing.Point(280, 20);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(221, 30);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Добро пожаловать,";
            // 
            // gbSummary
            // 
            this.gbSummary.BackColor = System.Drawing.Color.White;
            this.gbSummary.Controls.Add(this.btnReports);
            this.gbSummary.Controls.Add(this.btnBudget);
            this.gbSummary.Controls.Add(this.btnCategories);
            this.gbSummary.Controls.Add(this.btnTransactions);
            this.gbSummary.Controls.Add(this.panel3);
            this.gbSummary.Controls.Add(this.panel2);
            this.gbSummary.Controls.Add(this.panel1);
            this.gbSummary.Controls.Add(this.label1);
            this.gbSummary.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbSummary.Location = new System.Drawing.Point(0, 0);
            this.gbSummary.Name = "gbSummary";
            this.gbSummary.Size = new System.Drawing.Size(250, 581);
            this.gbSummary.TabIndex = 1;
            this.gbSummary.TabStop = false;
            // 
            // btnReports
            // 
            this.btnReports.BackColor = System.Drawing.Color.White;
            this.btnReports.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReports.FlatAppearance.BorderSize = 0;
            this.btnReports.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReports.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnReports.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnReports.Location = new System.Drawing.Point(0, 480);
            this.btnReports.Name = "btnReports";
            this.btnReports.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnReports.Size = new System.Drawing.Size(250, 50);
            this.btnReports.TabIndex = 6;
            this.btnReports.Text = "Отчёты";
            this.btnReports.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReports.UseVisualStyleBackColor = false;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // btnBudget
            // 
            this.btnBudget.BackColor = System.Drawing.Color.White;
            this.btnBudget.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBudget.FlatAppearance.BorderSize = 0;
            this.btnBudget.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.btnBudget.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBudget.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnBudget.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnBudget.Location = new System.Drawing.Point(0, 430);
            this.btnBudget.Name = "btnBudget";
            this.btnBudget.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnBudget.Size = new System.Drawing.Size(250, 50);
            this.btnBudget.TabIndex = 5;
            this.btnBudget.Text = "Бюджет";
            this.btnBudget.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBudget.UseVisualStyleBackColor = false;
            this.btnBudget.Click += new System.EventHandler(this.btnBudget_Click);
            // 
            // btnCategories
            // 
            this.btnCategories.BackColor = System.Drawing.Color.White;
            this.btnCategories.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCategories.FlatAppearance.BorderSize = 0;
            this.btnCategories.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.btnCategories.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategories.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCategories.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCategories.Location = new System.Drawing.Point(0, 380);
            this.btnCategories.Name = "btnCategories";
            this.btnCategories.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnCategories.Size = new System.Drawing.Size(250, 50);
            this.btnCategories.TabIndex = 4;
            this.btnCategories.Text = "Категории";
            this.btnCategories.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCategories.UseVisualStyleBackColor = false;
            this.btnCategories.Click += new System.EventHandler(this.btnCategories_Click);
            // 
            // btnTransactions
            // 
            this.btnTransactions.BackColor = System.Drawing.Color.White;
            this.btnTransactions.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTransactions.FlatAppearance.BorderSize = 0;
            this.btnTransactions.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.btnTransactions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransactions.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnTransactions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnTransactions.Location = new System.Drawing.Point(0, 330);
            this.btnTransactions.Name = "btnTransactions";
            this.btnTransactions.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnTransactions.Size = new System.Drawing.Size(250, 50);
            this.btnTransactions.TabIndex = 3;
            this.btnTransactions.Text = "Операции";
            this.btnTransactions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTransactions.UseVisualStyleBackColor = false;
            this.btnTransactions.Click += new System.EventHandler(this.btnTransactions_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblExpenseCaption);
            this.panel3.Controls.Add(this.lblExpense);
            this.panel3.Location = new System.Drawing.Point(15, 230);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(220, 60);
            this.panel3.TabIndex = 9;
            // 
            // lblExpenseCaption
            // 
            this.lblExpenseCaption.AutoSize = true;
            this.lblExpenseCaption.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblExpenseCaption.ForeColor = System.Drawing.Color.DimGray;
            this.lblExpenseCaption.Location = new System.Drawing.Point(3, 10);
            this.lblExpenseCaption.Name = "lblExpenseCaption";
            this.lblExpenseCaption.Size = new System.Drawing.Size(117, 17);
            this.lblExpenseCaption.TabIndex = 4;
            this.lblExpenseCaption.Text = "Расходы за месяц";
            this.lblExpenseCaption.Click += new System.EventHandler(this.lblExpenseCaption_Click);
            // 
            // lblExpense
            // 
            this.lblExpense.AutoSize = true;
            this.lblExpense.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblExpense.ForeColor = System.Drawing.Color.IndianRed;
            this.lblExpense.Location = new System.Drawing.Point(1, 27);
            this.lblExpense.Name = "lblExpense";
            this.lblExpense.Size = new System.Drawing.Size(69, 25);
            this.lblExpense.TabIndex = 5;
            this.lblExpense.Text = "0,00 ₽";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblIncomeCaption);
            this.panel2.Controls.Add(this.lblIncome);
            this.panel2.Location = new System.Drawing.Point(15, 160);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(220, 60);
            this.panel2.TabIndex = 7;
            // 
            // lblIncomeCaption
            // 
            this.lblIncomeCaption.AutoSize = true;
            this.lblIncomeCaption.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblIncomeCaption.ForeColor = System.Drawing.Color.DimGray;
            this.lblIncomeCaption.Location = new System.Drawing.Point(3, 10);
            this.lblIncomeCaption.Name = "lblIncomeCaption";
            this.lblIncomeCaption.Size = new System.Drawing.Size(112, 17);
            this.lblIncomeCaption.TabIndex = 2;
            this.lblIncomeCaption.Text = "Доходы за месяц";
            // 
            // lblIncome
            // 
            this.lblIncome.AutoSize = true;
            this.lblIncome.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblIncome.ForeColor = System.Drawing.Color.SeaGreen;
            this.lblIncome.Location = new System.Drawing.Point(1, 27);
            this.lblIncome.Name = "lblIncome";
            this.lblIncome.Size = new System.Drawing.Size(69, 25);
            this.lblIncome.TabIndex = 3;
            this.lblIncome.Text = "0,00 ₽";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblBalanceCaption);
            this.panel1.Controls.Add(this.lblBalance);
            this.panel1.Location = new System.Drawing.Point(15, 90);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(220, 60);
            this.panel1.TabIndex = 8;
            // 
            // lblBalanceCaption
            // 
            this.lblBalanceCaption.AutoSize = true;
            this.lblBalanceCaption.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBalanceCaption.ForeColor = System.Drawing.Color.DimGray;
            this.lblBalanceCaption.Location = new System.Drawing.Point(3, 10);
            this.lblBalanceCaption.Name = "lblBalanceCaption";
            this.lblBalanceCaption.Size = new System.Drawing.Size(107, 17);
            this.lblBalanceCaption.TabIndex = 0;
            this.lblBalanceCaption.Text = "Текущий баланс";
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBalance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.lblBalance.Location = new System.Drawing.Point(1, 27);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(76, 30);
            this.lblBalance.TabIndex = 1;
            this.lblBalance.Text = "0,00 ₽";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 60);
            this.label1.TabIndex = 7;
            this.label1.Text = "Финансовый\r\nМенеджер";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnSwitchUser
            // 
            this.btnSwitchUser.BackColor = System.Drawing.Color.White;
            this.btnSwitchUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSwitchUser.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnSwitchUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSwitchUser.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSwitchUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnSwitchUser.Location = new System.Drawing.Point(685, 20);
            this.btnSwitchUser.Name = "btnSwitchUser";
            this.btnSwitchUser.Size = new System.Drawing.Size(180, 35);
            this.btnSwitchUser.TabIndex = 7;
            this.btnSwitchUser.Text = "Сменить пользователя";
            this.btnSwitchUser.UseVisualStyleBackColor = false;
            this.btnSwitchUser.Click += new System.EventHandler(this.btnSwitchUser_Click);
            // 
            // chartExpenses
            // 
            this.chartExpenses.BackColor = System.Drawing.Color.White;
            this.chartExpenses.BorderlineColor = System.Drawing.Color.Transparent;
            chartArea1.BackColor = System.Drawing.Color.White;
            chartArea1.Name = "ChartArea1";
            this.chartExpenses.ChartAreas.Add(chartArea1);
            legend1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            this.chartExpenses.Legends.Add(legend1);
            this.chartExpenses.Location = new System.Drawing.Point(280, 80);
            this.chartExpenses.Name = "chartExpenses";
            series1.ChartArea = "ChartArea1";
            series1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartExpenses.Series.Add(series1);
            this.chartExpenses.Size = new System.Drawing.Size(585, 480);
            this.chartExpenses.TabIndex = 2;
            this.chartExpenses.Text = "chart1";
            this.chartExpenses.Click += new System.EventHandler(this.chartExpenses_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(894, 581);
            this.Controls.Add(this.chartExpenses);
            this.Controls.Add(this.gbSummary);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.btnSwitchUser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Мой финансовый менеджер";
            this.gbSummary.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartExpenses)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.GroupBox gbSummary;
        private System.Windows.Forms.Label lblBalanceCaption;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label lblExpense;
        private System.Windows.Forms.Label lblExpenseCaption;
        private System.Windows.Forms.Label lblIncome;
        private System.Windows.Forms.Label lblIncomeCaption;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartExpenses;
        private System.Windows.Forms.Button btnTransactions;
        private System.Windows.Forms.Button btnCategories;
        private System.Windows.Forms.Button btnBudget;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnSwitchUser;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
    }
}