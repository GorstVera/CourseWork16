using CourseWork16.Model;
using CourseWork16.ServiceDevice;
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

//этот вариант наверно лучше и здесь можно делать сортировку нажатием на наименование столбца.

namespace CourseWork16.View
{
    public partial class Form1 : Form
    {
        SqlConnection connection = new SqlConnection();
        DataSet data1 = new DataSet();        
        SqlDataAdapter adapter2;
        DataViewManager manager;
        DataView dataView;

        public Form1()
        {
            InitializeComponent();
            connection.ConnectionString = @"Data Source=1-ПК\SQLEXPRESS; Initial catalog = CourseWork16; Integrated Security = true;";
            connection.Open();
            string command2 = "";
            command2 = "select Devices.Id, TypeDevices.NameType, Makers.NameMaker, Countries.NameCountry, Devices.Price, Devices.Date_release, Devices.Date_sale, Devices.Weight, AmountDevices.AmountBye, AmountDevices.AmountSale,AmountDevices.Unusable, AmountDevices.Balance  from Devices inner join TypeDevices on Devices.TypeDeviceId = TypeDevices.Id inner join Makers on Devices.MakerId = Makers.Id inner join Countries on Devices.CountryId = Countries.Id inner join AmountDevices on Devices.Id = AmountDevices.Id;";
            adapter2 = new SqlDataAdapter(command2, connection);

            data1.Tables.Clear();

            adapter2.Fill(data1);

            connection.Close();
            manager = new DataViewManager(data1);
            dataView = new DataView(data1.Tables[0]);
        }

        private  void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = getAll();

        }
        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = getMaker();
        }
        public DataView getAll()
        {
            return dataView;
        }
        public DataView getType()
        {
            string temp = "Tefal";
            dataView.RowFilter = $"NameType = '{temp}' ";
            return dataView;
        }

        //здесь тренеровочная модель, а так передавать temp в метод
        public DataView getMaker()
        {
            string temp = "Tefal";
            dataView.RowFilter = $"NameMaker = '{temp}' ";
            return dataView;
        }

    }
}
