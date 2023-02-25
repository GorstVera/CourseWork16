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
    public partial class Form1 : Form
    {
        AppDbContext _context = new AppDbContext();
        public Form1()
        {
            InitializeComponent();
        }

        private  void button1_Click(object sender, EventArgs e)
        {

            BindingSource bs = new BindingSource();
            bs.DataSource = _context.TypeDevices.Select(d => d.NameType).ToList();
                     
                      

            dataGridView1.DataSource = bs;

            
        }
    }
}
