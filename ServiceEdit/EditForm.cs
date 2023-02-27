using CourseWork16.ServiceDevice;
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
        TypeService typeService = TypeService.Instance;
        DeviceService deviceService = new DeviceService();
        CountryService countryService = new CountryService();
        MakerService makerService = new MakerService();
        public EditForm()
        {
            InitializeComponent();
            editService = new EditService(dataGridView1);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.CellDoubleClick += DataGridView1_CellDoubleClick;
            Delete_Button.Visible = false;
            
        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(comboBox1.Text == "Продукция")
            {
                if (dataGridView1.RowCount == 0)
                {
                    MessageBox.Show("Заполните таблицу");
                    return;
                }
                string id = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
                int tempId = 0;
                bool res = Int32.TryParse(id, out tempId);
                if (res == false)
                {
                    MessageBox.Show("Ошибка!");
                    return;
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
            if (comboBox1.SelectedIndex == 0 || comboBox1.SelectedIndex == 1 || comboBox1.SelectedIndex == 2)
            {
                Delete_Button.Visible = true;
            }
            if (comboBox1.SelectedIndex ==3)
            {
                Delete_Button.Visible = false;
            }
        }

        private void SaveChange_Button_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex ==0)
            {
                editService.SaveChangeTypeDevice();
                editService.FillTables(comboBox1.SelectedIndex);
            }
            if (comboBox1.SelectedIndex == 1)
            {
                editService.SaveChangeMaker();
                editService.FillTables(comboBox1.SelectedIndex);
            }
            if (comboBox1.SelectedIndex == 2)
            {
                editService.SaveChangeCountry();
                editService.FillTables(comboBox1.SelectedIndex);
            }
            if (comboBox1.SelectedIndex == 3)
            {
                dataGridView1.Columns["NameType"].ReadOnly = true;
                dataGridView1.Columns["NameMaker"].ReadOnly = true;
                dataGridView1.Columns["NameCountry"].ReadOnly = true;
                editService.SaveChangeDevice();
            }


        }

        private async void Delete_Button_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex ==0)
            {
                if (dataGridView1.RowCount == 0)
                {
                    MessageBox.Show("Заполните таблицу");
                    return;
                }
                string id = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
                int tempId = 0;
                bool res = Int32.TryParse(id, out tempId);
                if (res == false)
                {
                    MessageBox.Show("Ошибка!");
                    return;
                }
                else
                {
                    int count  = await deviceService.SelectType(tempId);
                    if (count == 0)
                    {
                        bool del = await typeService.DeleteTypeDevice(tempId);
                        if (del == true)
                        {
                            MessageBox.Show("Удаление выполнено успешно");
                            editService.FillTables(comboBox1.SelectedIndex);
                        }
                        else
                        {
                            MessageBox.Show("Невозможно удалить выбранный объект");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Невозможно удалить выбранный объект");
                    }
                    
                }
            }
            if (comboBox1.SelectedIndex == 1)
            {
                if (dataGridView1.RowCount == 0)
                {
                    MessageBox.Show("Заполните таблицу");
                    return;
                }
                string id = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
                int tempId = 0;
                bool res = Int32.TryParse(id, out tempId);
                if (res == false)
                {
                    MessageBox.Show("Ошибка!");
                    return;
                }
                else
                {
                    int count = await deviceService.SelectMaker(tempId);
                    if (count == 0)
                    {
                        bool del = await makerService.DeleteMaker(tempId);
                        if (del == true)
                        {
                            MessageBox.Show("Удаление выполнено успешно");
                            editService.FillTables(comboBox1.SelectedIndex);
                        }
                        else
                        {
                            MessageBox.Show("Невозможно удалить выбранный объект");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Невозможно удалить выбранный объект");
                    }
                }
            }
            if (comboBox1.SelectedIndex ==2)
            {
                if (dataGridView1.RowCount == 0)
                {
                    MessageBox.Show("Заполните таблицу");
                    return;
                }
                string id = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
                int tempId = 0;
                bool res = Int32.TryParse(id, out tempId);
                if (res == false)
                {
                    MessageBox.Show("Ошибка!");
                    return;
                }
                else
                {
                    int count = await deviceService.SelectCountry(tempId);
                    if (count == 0)
                    {
                        bool del = await countryService.DeleteCountry(tempId);
                        if (del == true)
                        {
                            MessageBox.Show("Удаление выполнено успешно");
                            editService.FillTables(comboBox1.SelectedIndex);
                        }
                        else
                        {
                            MessageBox.Show("Невозможно удалить выбранный объект");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Невозможно удалить выбранный объект");
                    }

                }

            }
        }
    }
}
