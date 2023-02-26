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
    public partial class AllUsersForm : Form
    {
        UserService userService = new UserService();
        public AllUsersForm()
        {
            InitializeComponent();
            this.Load += AllUsersForm_Load;
        }

        private async void AllUsersForm_Load(object sender, EventArgs e)
        {
            foreach (User item in await userService.ShowAllUsers())
            {
                listBox1.Items.Add(item);
            }
        }

        private async void RemoveUser_Button_Click(object sender, EventArgs e)
        {
            bool res = false;
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите пользователя");
                return;
            }
            else
            {
                var user = listBox1.SelectedItem as User;
                int id = user.Id;
                res = await userService.RemoveUser(id);
                if (res == true)
                {
                    label1.Text = "Удаление выполнено успешно";
                    listBox1.Items.Clear();
                    foreach (User item in await userService.ShowAllUsers())
                    {
                        listBox1.Items.Add(item);
                    }
                }
                else
                {
                    label1.Text = "Удаление невозможно"; 
                }
            }
        }
    }
}
