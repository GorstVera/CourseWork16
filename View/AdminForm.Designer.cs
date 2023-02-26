
namespace CourseWork16.View
{
    partial class AdminForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.AddNewDevice_Button = new System.Windows.Forms.Button();
            this.ShowAll_Button = new System.Windows.Forms.Button();
            this.DeleteDevice_Button = new System.Windows.Forms.Button();
            this.Edit_Button = new System.Windows.Forms.Button();
            this.SaleDevice_Button = new System.Windows.Forms.Button();
            this.AddUser_Button = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.All_Users_Button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // AddNewDevice_Button
            // 
            this.AddNewDevice_Button.Location = new System.Drawing.Point(127, 497);
            this.AddNewDevice_Button.Name = "AddNewDevice_Button";
            this.AddNewDevice_Button.Size = new System.Drawing.Size(242, 85);
            this.AddNewDevice_Button.TabIndex = 0;
            this.AddNewDevice_Button.Text = "Поступление";
            this.AddNewDevice_Button.UseVisualStyleBackColor = true;
            this.AddNewDevice_Button.Click += new System.EventHandler(this.AddNewDevice_Button_Click);
            // 
            // ShowAll_Button
            // 
            this.ShowAll_Button.Location = new System.Drawing.Point(18, 13);
            this.ShowAll_Button.Name = "ShowAll_Button";
            this.ShowAll_Button.Size = new System.Drawing.Size(172, 98);
            this.ShowAll_Button.TabIndex = 1;
            this.ShowAll_Button.Text = "Показать все";
            this.ShowAll_Button.UseVisualStyleBackColor = true;
            this.ShowAll_Button.Click += new System.EventHandler(this.ShowAll_Button_Click);
            // 
            // DeleteDevice_Button
            // 
            this.DeleteDevice_Button.Location = new System.Drawing.Point(19, 630);
            this.DeleteDevice_Button.Name = "DeleteDevice_Button";
            this.DeleteDevice_Button.Size = new System.Drawing.Size(181, 41);
            this.DeleteDevice_Button.TabIndex = 5;
            this.DeleteDevice_Button.Text = "Удалить";
            this.DeleteDevice_Button.UseVisualStyleBackColor = true;
            this.DeleteDevice_Button.Click += new System.EventHandler(this.DeleteDevice_Button_Click);
            // 
            // Edit_Button
            // 
            this.Edit_Button.Location = new System.Drawing.Point(788, 496);
            this.Edit_Button.Name = "Edit_Button";
            this.Edit_Button.Size = new System.Drawing.Size(241, 85);
            this.Edit_Button.TabIndex = 6;
            this.Edit_Button.Text = "Редактирование";
            this.Edit_Button.UseVisualStyleBackColor = true;
            this.Edit_Button.Click += new System.EventHandler(this.Edit_Button_Click);
            // 
            // SaleDevice_Button
            // 
            this.SaleDevice_Button.Location = new System.Drawing.Point(459, 496);
            this.SaleDevice_Button.Name = "SaleDevice_Button";
            this.SaleDevice_Button.Size = new System.Drawing.Size(251, 86);
            this.SaleDevice_Button.TabIndex = 7;
            this.SaleDevice_Button.Text = "Реализация";
            this.SaleDevice_Button.UseVisualStyleBackColor = true;
            this.SaleDevice_Button.Click += new System.EventHandler(this.SaleDevice_Button_Click);
            // 
            // AddUser_Button
            // 
            this.AddUser_Button.BackColor = System.Drawing.SystemColors.Info;
            this.AddUser_Button.Location = new System.Drawing.Point(920, 25);
            this.AddUser_Button.Name = "AddUser_Button";
            this.AddUser_Button.Size = new System.Drawing.Size(179, 85);
            this.AddUser_Button.TabIndex = 8;
            this.AddUser_Button.Text = "Добавить пользователя";
            this.AddUser_Button.UseVisualStyleBackColor = false;
            this.AddUser_Button.Click += new System.EventHandler(this.AddUser_Button_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(22, 131);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1290, 313);
            this.dataGridView1.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(53, 463);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1245, 23);
            this.label1.TabIndex = 10;
            // 
            // All_Users_Button
            // 
            this.All_Users_Button.Location = new System.Drawing.Point(1128, 26);
            this.All_Users_Button.Name = "All_Users_Button";
            this.All_Users_Button.Size = new System.Drawing.Size(169, 83);
            this.All_Users_Button.TabIndex = 11;
            this.All_Users_Button.Text = "Все пользователи";
            this.All_Users_Button.UseVisualStyleBackColor = true;
            this.All_Users_Button.Click += new System.EventHandler(this.All_Users_Button_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1342, 693);
            this.Controls.Add(this.All_Users_Button);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.AddUser_Button);
            this.Controls.Add(this.SaleDevice_Button);
            this.Controls.Add(this.Edit_Button);
            this.Controls.Add(this.DeleteDevice_Button);
            this.Controls.Add(this.ShowAll_Button);
            this.Controls.Add(this.AddNewDevice_Button);
            this.Name = "AdminForm";
            this.Text = "AdminForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AddNewDevice_Button;
        private System.Windows.Forms.Button ShowAll_Button;
        private System.Windows.Forms.Button DeleteDevice_Button;
        private System.Windows.Forms.Button Edit_Button;
        private System.Windows.Forms.Button SaleDevice_Button;
        private System.Windows.Forms.Button AddUser_Button;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button All_Users_Button;
    }
}