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
    public partial class AdminForm : Form
    {
        AddUserForm addUserForm = new AddUserForm();
        DeviceService deviceService = new DeviceService();
        TypeService typeService =  TypeService.Instance;
        AmountDeviceService amountDeviceService = new AmountDeviceService();
        SaleDeviceForm saleDeviceForm;
        EditForm editForm = new EditForm();
        AllUsersForm allUsers = new AllUsersForm();
        AddNewDeviceForm AddNewDeviceForm = new AddNewDeviceForm();
        public AdminForm()
        {
            InitializeComponent();
            this.Load += AdminForm_Load;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.CellDoubleClick += DataGridView1_CellDoubleClick;
        }

        private async void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex == 1)
            {
                await deviceService.ShowAll(dataGridView1);
            }
            if (dataGridView1.CurrentCell.ColumnIndex == 2)
            {
                await deviceService.ShowAll(dataGridView1);
            }
            if (dataGridView1.CurrentCell.ColumnIndex == 3)
            {
                await deviceService .ShowAll(dataGridView1);
            }
        }

        private async void AdminForm_Load(object sender, EventArgs e)
        {
            await deviceService .ShowAll(dataGridView1);    
        }
        private async void ShowAll_Button_Click(object sender, EventArgs e)
        {
            await deviceService .ShowAll(dataGridView1);
        }

        private void AddNewDevice_Button_Click(object sender, EventArgs e)
        {
            AddNewDeviceForm.ShowDialog();
        }

        private void AddUser_Button_Click(object sender, EventArgs e)
        {
            addUserForm.ShowDialog();
        }
        private void All_Users_Button_Click(object sender, EventArgs e)
        {
            allUsers.ShowDialog();
        }

        private async void SaleDevice_Button_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows == null)
            {
                MessageBox.Show("Выберите предмет");
                return;
            }

            if (dataGridView1.RowCount == 0)
            {
                MessageBox.Show("Заполните таблицу");
                return;
            }
            string id = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
            int tempId = 0;
            Int32.TryParse(id, out tempId);
            saleDeviceForm = new SaleDeviceForm(tempId);
            if (saleDeviceForm.ShowDialog() == DialogResult.OK)
            {
                label1.Text = "Товар успешно реализован";
                await deviceService.ShowAll(dataGridView1);
            }

        }

        private async void DeleteDevice_Button_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows == null)
            {
                MessageBox.Show("Выберите предмет");
                return;
            }
            if (dataGridView1.RowCount == 0)
            {
                MessageBox.Show("Заполните таблицу");
                return;
            }
            string id = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
            int tempId = 0;
            bool res1, res2 = false;
            Int32.TryParse(id, out tempId);

           
            res1 = await amountDeviceService.RemoveAmountDevice(tempId);
            if(res1 == true)
            {
                res2 = await deviceService.RemoveDevice(tempId);
            }
            
            if (res1 == true && res2 == true)
            {
                label1.Text = "Удаление выполнено успешно";
                await deviceService.ShowAll(dataGridView1);
            }
            else
            {
                label1.Text = "Не удалось удалить объект";
            }          
        }

        private async void Edit_Button_Click(object sender, EventArgs e)
        {
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Редактирование выполнено успешно");
                await deviceService.ShowAll(dataGridView1);
            }
        }

       
    }
}
