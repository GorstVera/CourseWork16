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

namespace CourseWork16.ServiceEdit
{
    public partial class EditAmountForm : Form
    {
        int id;
        AmountDeviceService amountDeviceService = new AmountDeviceService();
        public EditAmountForm(int id)
        {
            InitializeComponent();
            this.id = id;
            this.Load += EditAmountForm_Load;
            
        }

        private async void EditAmountForm_Load(object sender, EventArgs e)
        {
            AmountDevice amountDevice = await amountDeviceService.GetAmountDevice(id);
            numericUpDown1.Value = amountDevice.AmountBye;
            numericUpDown2.Value = amountDevice.AmountSale;
            numericUpDown3.Value = amountDevice.Unusable;
            numericUpDown4.Value = amountDevice.Balance;
        }

        private async  void SaveChange_Button_Click(object sender, EventArgs e)
        {
            int bye = (int)numericUpDown1.Value;
            int sale = (int)numericUpDown2.Value;
            int unuse = (int)numericUpDown3.Value;
            int balance = 0;
            if (bye <(sale+unuse))
            {
                MessageBox.Show("Недопустимые данные");
                return;
            }
            balance = bye - sale - unuse;
            await amountDeviceService.ChangeAmount(id, bye, sale, unuse, balance);
            this.DialogResult = DialogResult.OK;


        }
    }
}
