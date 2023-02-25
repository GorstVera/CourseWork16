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
    public partial class ManagerForm : Form
    {
        DeviceService deviceService = new DeviceService();
        TypeService typeService = new TypeService();
        MakerService makerService = new MakerService();
        CountryService countryService = new CountryService();

        public ManagerForm()
        {
            InitializeComponent();
            this.Load += ManagerForm_Load;
            
        }

        private async void ManagerForm_Load(object sender, EventArgs e)
        {
            comboBox3.Items.Add("Все производители");
            comboBox4.Items.Add("Все производители");
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            comboBox1.Items.Add("Все категории");
            comboBox1.SelectedIndex = 0;
            foreach (TypeDevice item in await typeService.GetAll())
            {
                comboBox8.Items.Add(item);
                comboBox1.Items.Add(item);
            }
            foreach (Maker item in await makerService.GetAll())
            {
                comboBox2.Items.Add(item);
                comboBox3.Items.Add(item);
                comboBox4.Items.Add(item);
                comboBox6.Items.Add(item);
                comboBox7.Items.Add(item);
            }
            comboBox3.SelectedIndex = 0;
            foreach (Country item in await countryService.GetAll())
            {
                comboBox5.Items.Add(item);
            }
            //deviceService.ShowAll(dataGridView1);
            //dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Ascending);
        }

        private void AllDevices_Button_Click(object sender, EventArgs e)
        {
            deviceService.ShowAll(dataGridView1);
        }

        private async void ShowType_Button_Click(object sender, EventArgs e)
        {
            int res = await typeService.GetIdTypeDevice(comboBox8.Text);
            deviceService.ShowType(dataGridView1, res);
        }

        private async void FindMaker_Button_Click(object sender, EventArgs e)
        {
            int resM = await makerService.GetIdMaker(comboBox2.Text);
            deviceService.ShowMaker(dataGridView1, resM);
        }

        private void FindRelease_Button_Click(object sender, EventArgs e)
        {
            deviceService.ShowDate(dataGridView1, dateTimePicker1.Value);
        }

        private void FindPrice_Button_Click(object sender, EventArgs e)
        {
            deviceService.PriceBetween(dataGridView1, numericUpDown1.Value, numericUpDown2.Value);
        }

        private async void FindWeight_Button_Click(object sender, EventArgs e)
        {
            int tempM = 0;
            if (comboBox3.SelectedIndex==0)
            {
                tempM = -1;
            }
            else
            {
                tempM = await makerService.GetIdMaker(comboBox3.Text);
            }
            deviceService.WeightBetween(dataGridView1, tempM, (float)numericUpDown3.Value, (float)numericUpDown4.Value);
        }

        private void FindPeriod_Button_Click(object sender, EventArgs e)
        {
            float res = 0;
            int part = deviceService.PartSaleDevice(dateTimePicker2.Value);
            int all = deviceService.PartSaleDevice(DateTime.Now);
            res = part *100/ all;

            label9.Text = $"Доля проданных товаров на дату: {dateTimePicker2.Value} составляет {res}%";
        }
        private void Expensive_Button_Click(object sender, EventArgs e)
        {
            deviceService.ExpenciveDevice(dataGridView1, comboBox1.Text);
        }

        private void Cheapest_Button_Click(object sender, EventArgs e)
        {
            deviceService.CheapDevice(dataGridView1, comboBox1.Text);
        }

        private async void Average_Button_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                decimal res = await deviceService.AveragePriceDevice(0);
                label9.Text = $"Средняя стоимость товаров в категории {comboBox1.Text} составляет {res} рублей.";
            }
            else
            {
                int id = await typeService.GetIdTypeDevice(comboBox1.Text);
                decimal res = await deviceService.AveragePriceDevice(id);
                label9.Text = $"Средняя стоимость товаров в категории {comboBox1.Text} составляет {res} рублей.";
            }
            
        }

        private async void Popular_Button_Click(object sender, EventArgs e)
        {
            await deviceService.PopularDevice(dataGridView1);
        }

        private async void PriceLessThan_Button_Click(object sender, EventArgs e)
        {
            float res = await deviceService.PartPriceDevice(dataGridView1, comboBox4.SelectedIndex, numericUpDown5.Value);
            label9.Text = $"Доля товаров со стоимостью меньше {numericUpDown5.Value} в категории {comboBox4.Text} составляет {res} % ";
        }

        private async void FindOperable_Button_Click(object sender, EventArgs e)
        {
            int id = 0;
            if (radioButton1.Checked)
            {
                id = await countryService.GetIdCountry(comboBox5.Text);
                int res = await deviceService.AmountUnusableDeviceCountry(dataGridView1, id);
                label9.Text = $"Количество бракованных изделий из {comboBox5.Text} составляет {res} штук";
            }
            else
            {
                id = await makerService.GetIdMaker(comboBox5.Text);
                int res = await deviceService.AmountUnusableDeviceMaker(dataGridView1, id);
                label9.Text = $"Количество бракованных изделий от {comboBox5.Text} составляет {res} штук";
            }
            
        }

        private async void FindAvarageThen_Button_Click(object sender, EventArgs e)
        {
            int id = await makerService.GetIdMaker(comboBox7.Text);
            decimal res = await deviceService.HiAverageMaker(dataGridView1, id);
            label9.Text = $"Средняя стоимость товаров производителя: {comboBox7.Text} составляет {res} рублей.";
        }
    }
}
