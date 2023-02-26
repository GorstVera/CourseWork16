using CourseWork16.ServiceEdit;
using CourseWork16.ServiceUser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork16.View
{
    public partial class EditForm : Form
    {
        EditService editService;
        EditAmountForm editAmountForm; 
        public EditForm()
        {
            InitializeComponent();
            editService = new EditService(dataGridView1);
            dataGridView1.CellDoubleClick += DataGridView1_CellDoubleClick;
        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(comboBox1.Text == "Продукция")
            {
                string id = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
                int tempId = 0;
                bool res = Int32.TryParse(id, out tempId);
                if (res == false)
                {
                    MessageBox.Show("Ошибка!");
                }
                editAmountForm = new EditAmountForm(tempId);
                if (editAmountForm.ShowDialog() == DialogResult.OK)
                {
                    editService.FillTables(3);
                }
            }
            
            
        }

        private void Choice_Button_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Выберита данные");
                return;
            }
            editService.FillTables(comboBox1.SelectedIndex);
        }

        private void SaveChange_Button_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex ==0)
            {
                editService.SaveChangeTypeDevice();
            }
            if (comboBox1.SelectedIndex == 1)
            {
                editService.SaveChangeMaker();
            }
            if (comboBox1.SelectedIndex == 2)
            {
                editService.SaveChangeCountry();
            }
            if (comboBox1.SelectedIndex == 3)
            {
                dataGridView1.Columns["NameType"].ReadOnly = true;
                dataGridView1.Columns["NameMaker"].ReadOnly = true;
                dataGridView1.Columns["NameCountry"].ReadOnly = true;
                editService.SaveChangeDevice();
            }


        }
    }
}
