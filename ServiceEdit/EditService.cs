using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork16.ServiceUser
{
    public class EditService
    {
        SqlConnection connection = new SqlConnection();
        DataSet data1 = new DataSet();
        DataSet data2 = new DataSet();
        SqlDataAdapter adapter1;
        SqlDataAdapter adapter2;
        DataGridView dataGridView;
        DataViewManager manager;

        public EditService(DataGridView dataGridView)
        {
            this.dataGridView = dataGridView;
            connection.ConnectionString = @"Data Source=1-ПК\SQLEXPRESS; Initial catalog = CourseWork16; Integrated Security = true;";
            connection.Open();
        }

        public void FillTables(int number)
        {
            string command1;
            string command2;
            //command1 = "select Id, TypeName from TypeDevices; select Id, NameMaker from Makers; select Id, NameCountry from Countries;";
            command1 = "select * from TypeDevices; select * from Makers; select * from Countries;";
            adapter1 = new SqlDataAdapter(command1, connection);
            

            command2 = "select Devices.Id, TypeDevices.NameType, Makers.NameMaker, Countries.NameCountry, Devices.Price, Devices.Date_release, Devices.Date_sale, Devices.Weight, AmountDevices.AmountBye, AmountDevices.AmountSale,AmountDevices.Unusable, AmountDevices.Balance  from Devices inner join TypeDevices on Devices.TypeDeviceId = TypeDevices.Id inner join Makers on Devices.MakerId = Makers.Id inner join Countries on Devices.CountryId = Countries.Id inner join AmountDevices on Devices.Id = AmountDevices.Id;";
            adapter2 = new SqlDataAdapter(command2, connection);

            data1.Tables.Clear();
            data2.Tables.Clear();
            adapter1.Fill(data1);
            adapter2.Fill(data2);

            switch (number)
            {
                case 0:
                    dataGridView.DataSource = data1.Tables[0];
                    break;
                case 1:
                    dataGridView.DataSource = data1.Tables[1];
                    break;
                case 2:
                    dataGridView.DataSource = data1.Tables[2];
                    break;
                case 3:
                    dataGridView.DataSource = data2.Tables[0];
                    break;
            }
            manager = new DataViewManager(data1);
        }

        public void SaveChangeTypeDevice()
        {
            string temp = "";
            SqlCommand update;
            temp = "Update TypeDevices set NameType=@pNameType where Id=@pId";
            update = new SqlCommand(temp, connection);

            update.Parameters.Add(new SqlParameter("@pNameType", SqlDbType.NVarChar, 50));
            update.Parameters.Add(new SqlParameter("@pId", SqlDbType.Int));

            update.Parameters["@pNameType"].SourceVersion = DataRowVersion.Current;
            update.Parameters["@pId"].SourceVersion = DataRowVersion.Original;

            update.Parameters["@pNameType"].SourceColumn = "NameType";
            update.Parameters["@pId"].SourceColumn = "Id";

            adapter1.UpdateCommand = update;
            adapter1.Update(data1.Tables[0]);
        }
        public void SaveChangeMaker()
        {
            string temp = "";
            SqlCommand update;
            temp = "Update Makers set NameMaker=@pNameMaker where Id=@pId";
            update = new SqlCommand(temp, connection);

            update.Parameters.Add(new SqlParameter("@pNameMaker", SqlDbType.NVarChar, 50));
            update.Parameters.Add(new SqlParameter("@pId", SqlDbType.Int));

            update.Parameters["@pNameMaker"].SourceVersion = DataRowVersion.Current;
            update.Parameters["@pId"].SourceVersion = DataRowVersion.Original;

            update.Parameters["@pNameMaker"].SourceColumn = "NameMaker";
            update.Parameters["@pId"].SourceColumn = "Id";

            adapter1.UpdateCommand = update;
            adapter1.Update(data1.Tables[1]);
        }
        public void SaveChangeCountry()
        {
            string temp = "";
            SqlCommand update;
            temp = "Update Countries set NameCountry=@pNameCountry where Id=@pId";
            update = new SqlCommand(temp, connection);

            update.Parameters.Add(new SqlParameter("@pNameCountry", SqlDbType.NVarChar, 50));
            update.Parameters.Add(new SqlParameter("@pId", SqlDbType.Int));

            update.Parameters["@pNameCountry"].SourceVersion = DataRowVersion.Current;
            update.Parameters["@pId"].SourceVersion = DataRowVersion.Original;

            update.Parameters["@pNameCountry"].SourceColumn = "NameCountry";
            update.Parameters["@pId"].SourceColumn = "Id";

            adapter1.UpdateCommand = update;
            adapter1.Update(data1.Tables[2]);
        }
        public void SaveChangeDevice()
        {
            string temp = "";
            SqlCommand update;
            temp = "Update Devices set Price=@pPrice, Date_release=@pDate_release, Date_sale=@pDate_sale, Weight=@pWeight where Id=@pId";
            update = new SqlCommand(temp, connection);

            update.Parameters.Add(new SqlParameter("@pPrice", SqlDbType.Decimal));
            update.Parameters.Add(new SqlParameter("@pDate_Release", SqlDbType.DateTime));
            update.Parameters.Add(new SqlParameter("@pDate_sale", SqlDbType.DateTime));
            update.Parameters.Add(new SqlParameter("@pWeight", SqlDbType.Real));
            update.Parameters.Add(new SqlParameter("@pId", SqlDbType.Int));

            update.Parameters["@pPrice"].SourceVersion = DataRowVersion.Current;
            update.Parameters["@pDate_Release"].SourceVersion = DataRowVersion.Current;
            update.Parameters["@pDate_sale"].SourceVersion = DataRowVersion.Current;
            update.Parameters["@pWeight"].SourceVersion = DataRowVersion.Current;
            update.Parameters["@pId"].SourceVersion = DataRowVersion.Original;

            update.Parameters["@pPrice"].SourceColumn = "Price";
            update.Parameters["@pDate_Release"].SourceColumn = "Date_Release";
            update.Parameters["@pDate_sale"].SourceColumn = "Date_sale";
            update.Parameters["@pWeight"].SourceColumn = "Weight";
            update.Parameters["@pId"].SourceColumn = "Id";
            adapter2.UpdateCommand = update;
            /*
            temp = "Update AmountDevices set AmountBye=@pAmountBye, AmountSale=@pAmountSale, Unusable=@pUnusable, Balance=@pBalance where Id=@pId";
            update = new SqlCommand(temp, connection);

            update.Parameters.Add(new SqlParameter("@pAmountBye", SqlDbType.Int));
            update.Parameters.Add(new SqlParameter("@pAmountSale", SqlDbType.Int));
            update.Parameters.Add(new SqlParameter("@pUnusable", SqlDbType.Int));
            update.Parameters.Add(new SqlParameter("@pBalance", SqlDbType.Int));
            update.Parameters.Add(new SqlParameter("@pId", SqlDbType.Int));

            update.Parameters["@@pAmountBye"].SourceVersion = DataRowVersion.Current;
            update.Parameters["@pAmountSale"].SourceVersion = DataRowVersion.Current;
            update.Parameters["@Unusable"].SourceVersion = DataRowVersion.Current;
            update.Parameters["@pBalance"].SourceVersion = DataRowVersion.Current;
            update.Parameters["@pId"].SourceVersion = DataRowVersion.Original;

            update.Parameters["@p@pAmountBye"].SourceColumn = "AmountBye";
            update.Parameters["@pAmountSale"].SourceColumn = "AmountSale";
            update.Parameters["@pUnusable"].SourceColumn = "Unusable";
            update.Parameters["@pBalance"].SourceColumn = "Balance";
            update.Parameters["@pId"].SourceColumn = "Id";
            adapter2.UpdateCommand = update;
            */
            adapter2.Update(data2.Tables[0]);
        }


    }
}
