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
    public partial class AddNewDeviceForm : Form
    {
        TypeService typeService = TypeService.Instance;
        MakerService makerService;
        CountryService countryService;
        DeviceService deviceService;
        AddTypeDeviceForm AddTypeDeviceForm;

        public AddNewDeviceForm()
        {
            InitializeComponent();
            makerService = new MakerService();
            countryService = new CountryService();
            deviceService = new DeviceService();
            this.Load += AddNewDeviceForm_Load;
        }

        private async void AddNewDeviceForm_Load(object sender, EventArgs e)
        {
            foreach (var item in  await typeService.GetAll())
            {
                comboBox1.Items.Add(item);
            }
            foreach (var item in await makerService.GetAll())
            {
                
                comboBox2.Items.Add(item);
            }
            foreach (var item in await countryService.GetAll())
            {
                comboBox3.Items.Add(item);
            }
        }

        private async void AddNewDevice_Button_Click(object sender, EventArgs e)
        {
            

            //TypeDevice tempType =  await typeService.GetItem(comboBox1.Text);
            //if(tempType == null)
            //{
            //    tempType = (TypeDevice) await typeService.AddItem(comboBox1.Text);  
            //}
            Maker tempMaker = await makerService.GetItem(comboBox2.Text);
            if (tempMaker == null)
            {
                tempMaker = (Maker) await makerService.AddItem(comboBox2.Text);
                comboBox2.Items.Clear();
                foreach (var item in await makerService.GetAll())
                {

                    comboBox2.Items.Add(item);
                }

            }
            Country tempCountry = await countryService.GetItem(comboBox3.Text);
            if (tempCountry == null)
            {
                tempCountry = (Country)await countryService.AddItem(comboBox3.Text);
                comboBox3.Items.Clear();
                foreach (var item in await countryService.GetAll())
                {
                    comboBox3.Items.Add(item);
                }
            }

            if (comboBox1.SelectedIndex == -1 || string.IsNullOrWhiteSpace(comboBox2.Text) == true || string.IsNullOrWhiteSpace(comboBox3.Text) == true ||
                numericUpDown1.Value == 0 || numericUpDown2.Value == 0 || numericUpDown3.Value == 0)
            {
                MessageBox.Show("Заполните данные");
                return;
            }
            var res = deviceService.AddItem(comboBox1.Text,  comboBox2.Text, comboBox3.Text, (float)numericUpDown1.Value, numericUpDown2.Value, dateTimePicker1.Value, (int)numericUpDown3.Value);
            
            if (res != null)
            {
                label7.Text = "Новый товар успешно добавлен";
            }
            else
            {
                label7.Text = "Товар не удалось добавить";
            }
            //this.DialogResult = DialogResult.OK;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            AddTypeDeviceForm = new AddTypeDeviceForm();
            
            if (AddTypeDeviceForm.ShowDialog() == DialogResult.OK)
            {
                label7.Text = "Новая категория успешно добавлена";
                comboBox1.Items.Clear();
                foreach (TypeDevice item in await typeService.GetAll())
                {
                    comboBox1.Items.Add(item);
                }
            }
            
        }
    }
}
