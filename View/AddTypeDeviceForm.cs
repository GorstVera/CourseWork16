using CourseWork16.Model;
using CourseWork16.ServiceDevice;
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
    public partial class AddTypeDeviceForm : Form
    {
        TypeService typeService = TypeService.Instance;
        public AddTypeDeviceForm()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text)== true)
            {
                MessageBox.Show("Заполните данные");
                return;
            }
            else
            {
                TypeDevice type =  await typeService.GetItem(textBox1.Text);
                if (type == null)
                {
                    var res = await typeService.AddItem(textBox1.Text);
                }
            }
            this.DialogResult=DialogResult.OK;
        }
    }
}
