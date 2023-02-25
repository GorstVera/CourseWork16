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
    public partial class StartForm : Form
    {
        UserService userService;
        AdminForm adminForm;
        ManagerForm managerForm;

        public StartForm()
        {
            InitializeComponent();
            userService = new UserService();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text)== true || string.IsNullOrWhiteSpace(textBox2.Text)==true)
            {
                MessageBox.Show("Заполните данные");
                return;
            }
            
            User user = await userService.CheckUser(textBox1.Text, textBox2.Text);
            if (user == null)
            {
                MessageBox.Show("Неправильный логин или пароль");
                return;
            }
            else
            {
                if(user.Role == UserRole.Администратор)
                {
                    adminForm = new AdminForm();
                    adminForm.ShowDialog();
                    this.Close();
                }
                else
                {
                    managerForm = new ManagerForm();
                    managerForm.ShowDialog();
                    this.Close();
                }
            }
        }

    }
}
