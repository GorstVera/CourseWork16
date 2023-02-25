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
        AddNewDeviceForm AddNewDeviceForm;
        AddUserForm addUserForm;
        DeviceService deviceService = new DeviceService();
        TypeService typeService = new TypeService();
        AmountDeviceService amountDeviceService = new AmountDeviceService();
        SaleDeviceForm saleDeviceForm;
        EditForm editForm = new EditForm();
        public AdminForm()
        {
            InitializeComponent();
            this.Load += AdminForm_Load;
            this.dataGridView1.CellDoubleClick += DataGridView1_CellDoubleClick;

            
            

        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex == 1)
            {
                deviceService.Show(dataGridView1);
            }
            if (dataGridView1.CurrentCell.ColumnIndex == 2)
            {
                deviceService.Show(dataGridView1);
            }
            if (dataGridView1.CurrentCell.ColumnIndex == 3)
            {
                deviceService.Show(dataGridView1);
            }
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            deviceService.ShowAll(dataGridView1);
            
        }

        private void AddNewDevice_Button_Click(object sender, EventArgs e)
        {
            AddNewDeviceForm = new AddNewDeviceForm();
            if(AddNewDeviceForm.ShowDialog() == DialogResult.OK)
            {
               // dataGridView1.Update();
               // dataGridView1.Refresh();
                deviceService.ShowAll(dataGridView1);
            }
        }

        private void AddUser_Button_Click(object sender, EventArgs e)
        {
            addUserForm = new AddUserForm();
            
            if(addUserForm.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void ShowAll_Button_Click(object sender, EventArgs e)
        {
            deviceService.Show(dataGridView1);

        }

        private void SaleDevice_Button_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows == null)
            {
                MessageBox.Show("Выберите предмет");
                return;
            }

            var res = dataGridView1.SelectedCells[0].Value;
            int tempId = Convert.ToInt32(res);
            saleDeviceForm = new SaleDeviceForm(tempId);
            if (saleDeviceForm.ShowDialog() == DialogResult.OK)
            {
                deviceService.ShowAll(dataGridView1);
            }

        }

        private async void DeleteDevice_Button_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows == null)
            {
                MessageBox.Show("Выберите предмет");
                return;
            }

            var res = dataGridView1.SelectedCells[0].Value;
            int tempId = Convert.ToInt32(res);
            bool res1 = await amountDeviceService.RemoveAmountDevice(tempId);
            if(res1 == true)
            {
                bool res2 = await deviceService.RemoveDevice(tempId);
            }
            /*
            if (res1 == true && res2 == true)
            {
                MessageBox.Show("Удаление выполнено");
            }
            else
            {
                MessageBox.Show("Не удалось удалить объект");
            }
            */
            
        }

        private void Edit_Button_Click(object sender, EventArgs e)
        {
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("редактирование выполнено успешно");
            }
        }
    }
}
