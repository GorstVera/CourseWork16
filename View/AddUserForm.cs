using CourseWork16.ServiceUser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork16.View
{
    public partial class AddUserForm : Form
    {
        UserService userService = new UserService(); 
        public AddUserForm()
        {
            InitializeComponent();
        }

        private async void AddNewUser_Button_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text)|| string.IsNullOrWhiteSpace(textBox2.Text)|| string.IsNullOrWhiteSpace(textBox3.Text)|| string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Заполните данные");
                return;
            }
            if (radioButton1.Checked== false && radioButton2.Checked==false )
            {
                MessageBox.Show("Выберите вариант доступа");
                return;
            }

            string role =  RadioCheck();
            var user = await userService.AddUser(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, role);

            if (user != null)
            {
                label5.Text = "Пользователь успешно добавлен";
            }
            else
            {
                label5.Text = "Пользователь не добавлен";
            }  
        }
        private  string RadioCheck()
        {
            if (radioButton1.Checked)
            {
                return "Администратор";
            }
            else
            {
                return "Менеджер";
            }
        }
    }
}
