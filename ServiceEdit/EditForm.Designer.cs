
namespace CourseWork16.View
{
    partial class EditForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Choice_Button = new System.Windows.Forms.Button();
            this.SaveChange_Button = new System.Windows.Forms.Button();
            this.Delete_Button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(5, 40);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1133, 509);
            this.dataGridView1.TabIndex = 0;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Категория",
            "Производитель",
            "Страна",
            "Продукция"});
            this.comboBox1.Location = new System.Drawing.Point(1156, 66);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(196, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1153, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Выберите данные для редактирования:";
            // 
            // Choice_Button
            // 
            this.Choice_Button.Location = new System.Drawing.Point(1164, 125);
            this.Choice_Button.Name = "Choice_Button";
            this.Choice_Button.Size = new System.Drawing.Size(196, 52);
            this.Choice_Button.TabIndex = 3;
            this.Choice_Button.Text = "Выбрать";
            this.Choice_Button.UseVisualStyleBackColor = true;
            this.Choice_Button.Click += new System.EventHandler(this.Choice_Button_Click);
            // 
            // SaveChange_Button
            // 
            this.SaveChange_Button.Location = new System.Drawing.Point(1144, 555);
            this.SaveChange_Button.Name = "SaveChange_Button";
            this.SaveChange_Button.Size = new System.Drawing.Size(241, 74);
            this.SaveChange_Button.TabIndex = 4;
            this.SaveChange_Button.Text = "Сохранить изменения";
            this.SaveChange_Button.UseVisualStyleBackColor = true;
            this.SaveChange_Button.Click += new System.EventHandler(this.SaveChange_Button_Click);
            // 
            // Delete_Button
            // 
            this.Delete_Button.Location = new System.Drawing.Point(1178, 499);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(174, 40);
            this.Delete_Button.TabIndex = 5;
            this.Delete_Button.Text = "Удалить";
            this.Delete_Button.UseVisualStyleBackColor = true;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 575);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(588, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "*Для редактирования данных по количеству товара используйте двойной щелчок мышью " +
    "по необхдимому товару";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 607);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(391, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "*В этой \"Продукция\" можно изменять Price, Date_release, Date_sale, Weight";
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1397, 668);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.SaveChange_Button);
            this.Controls.Add(this.Choice_Button);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "EditForm";
            this.Text = "EditForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Choice_Button;
        private System.Windows.Forms.Button SaveChange_Button;
        private System.Windows.Forms.Button Delete_Button;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}