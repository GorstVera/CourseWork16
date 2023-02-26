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
    public partial class SaleDeviceForm : Form
    {
        int id;
        DeviceService deviceService = new DeviceService();
        AmountDeviceService amountDeviceService = new AmountDeviceService();
        public SaleDeviceForm(int id)
        {
            InitializeComponent();
            this.id = id;
            this.Load += SaleDeviceForm_Load;
            
        }

        private async void SaleDeviceForm_Load(object sender, EventArgs e)
        {
            AmountDevice ad = await amountDeviceService.GetAmountDevice(id);
            Device device = await deviceService.GetDevice(id);
            label3.Text += "Дата поступления: " + device.Date_release.ToShortDateString() + Environment.NewLine;
            label3.Text += "Поступление: " + ad.AmountBye + Environment.NewLine;
            label3.Text += "Продажи: " + ad.AmountSale + Environment.NewLine;
            label3.Text += "Брак: " + ad.Unusable + Environment.NewLine;
            label3.Text += "Остаток: " + ad.Balance + Environment.NewLine;
        }

        private async void SaleDevice_Button_Click(object sender, EventArgs e)
        {
            AmountDevice ad = await amountDeviceService.GetAmountDevice(id);
            Device device = await deviceService.GetDevice(id);
            if (numericUpDown1.Value<=0)
            {
                MessageBox.Show("Выберите количество");
                return;
            }

            if(!radioButton1.Checked && !radioButton2.Checked)
            {
                MessageBox.Show("Выберите вариант выбытия");
                return;
            }
            if (ad.Balance < (int)numericUpDown1.Value)
            {
                MessageBox.Show("Выбрано большое количество");
                return;
            }
            if (device.Date_release> dateTimePicker1.Value)
            {
                MessageBox.Show("Неверно выбрана дата");
                return;
            }
            
            
             if(radioButton1.Checked)
             {

                 await amountDeviceService.ChangeAmountSale(id, (int)numericUpDown1.Value);
                 await deviceService.SetDateSale(id, dateTimePicker1.Value);
             }
             else
             {
                 await amountDeviceService.ChangeAmountUnusable(id, (int)numericUpDown1.Value);
                 await deviceService.SetDateSale(id, dateTimePicker1.Value);
             }

            this.DialogResult = DialogResult.OK;
        }
    }
}
