
namespace CourseWork16.View
{
    partial class AllUsersForm
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.RemoveUser_Button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(54, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(313, 381);
            this.listBox1.TabIndex = 0;
            // 
            // RemoveUser_Button
            // 
            this.RemoveUser_Button.Location = new System.Drawing.Point(121, 455);
            this.RemoveUser_Button.Name = "RemoveUser_Button";
            this.RemoveUser_Button.Size = new System.Drawing.Size(180, 49);
            this.RemoveUser_Button.TabIndex = 1;
            this.RemoveUser_Button.Text = "Удалить";
            this.RemoveUser_Button.UseVisualStyleBackColor = true;
            this.RemoveUser_Button.Click += new System.EventHandler(this.RemoveUser_Button_Click);
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(55, 417);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(311, 26);
            this.label1.TabIndex = 2;
            // 
            // AllUsersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 528);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RemoveUser_Button);
            this.Controls.Add(this.listBox1);
            this.Name = "AllUsersForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AllUsersForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button RemoveUser_Button;
        private System.Windows.Forms.Label label1;
    }
}