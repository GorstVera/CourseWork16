using CourseWork16.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork16.ServiceDevice
{
    public class DeviceService
    {
        AppDbContext _context = new AppDbContext();
        TypeService typeService = new TypeService();
        public DeviceService()
        {
            _context = new AppDbContext();

        }

        public async Task<Device> AddItem(string td, string m, string c, float weight, decimal price, DateTime date_release, int amount)
        {
            TypeDevice tempT = await _context.TypeDevices.FirstOrDefaultAsync(tt => tt.NameType == td);
            Country tempC = await _context.Countries.FirstOrDefaultAsync(tc => tc.NameCountry == c);
            Maker tempM = await _context.Makers.FirstOrDefaultAsync(tm => tm.NameMaker == m);

            Device newDevice = new Device()
            {

                Weight = weight,
                Price = price,
                Date_release = date_release,
                Country = tempC,
                TypeDevice = tempT,
                Maker = tempM
            };
            _context.Devices.Add(newDevice);
            _context.SaveChanges();

            /*
            Device newDevice = new Device();

            _context.Devices.Add(newDevice);

            //newDevice.TypeDevice = td;
            newDevice.Date_release = date_release;
            newDevice.Weight = weight;
            newDevice.Price = price;
            newDevice.TypeDevice = tempT;
            newDevice.Country = tempC;
            newDevice.Maker = TempM;

            await _context.SaveChangesAsync();
            
            var resTD = await _context.TypeDevices.Include("Devices").ToListAsync();
            (resTD.FirstOrDefault(t => t.NameType == td)).Devices.Add(newDevice);

            var resM = await _context.Makers.ToListAsync();
            (resM.FirstOrDefault(t => t.NameMaker == m)).Devices.Add(newDevice);

            var resC = await _context.Countries.ToListAsync();
            (resC.FirstOrDefault(t => t.NameCountry == c)).Devices.Add(newDevice);
            */
            AmountDevice amountDevice = new AmountDevice() { Id = newDevice.Id, AmountBye = amount, Balance = amount };
            _context.AmountDevices.Add(amountDevice);
            await _context.SaveChangesAsync();
            return newDevice;


        }

        public async Task<Device> GetDevice(int id)
        {
            Device res = await _context.Devices.FirstOrDefaultAsync(d => d.Id == id);
            return res;
        }

        public async Task<bool> RemoveDevice(int id)
        {
            //Device device = await _context.Devices.FirstOrDefaultAsync(d => d.Id == id);


            Device device = await GetDevice(id);
            _context.Devices.Remove(device);
            await _context.SaveChangesAsync();
            var res = await _context.Devices.FirstOrDefaultAsync(d => d.Id == id);
            if (res == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task SetDateSale(int id, DateTime date)
        {
            Device tempD = await _context.Devices.FirstOrDefaultAsync(d => d.Id == id); 
            tempD.Date_sale = date;
            await _context.SaveChangesAsync();
        }


        public async Task ShowAll(DataGridView gridView)
        {


            var res = from d in _context.Devices
                      join ad in _context.AmountDevices on d.Id equals ad.Id

                      select new
                      {
                          d.Id, d.TypeDevice, d.Maker, d.Country, d.Price, d.Weight, d.Date_release,
                          d.Date_sale, ad.AmountBye, ad.AmountSale, ad.Unusable, ad.Balance
                      };

            gridView.DataSource = await res.ToListAsync();

        }

        public void Show(DataGridView gridView)
        {
            SqlConnection connection = new SqlConnection();
            DataSet data = new DataSet();
            SqlDataAdapter adapter;
            DataViewManager manager;
            connection.ConnectionString = @"Data Source=1-ПК\SQLEXPRESS; Initial catalog = CourseWork16; Integrated Security = true;";
            connection.Open();
            string command;

            command = "select Devices.Id, TypeDevices.NameType, Makers.NameMaker, Countries.NameCountry, Devices.Price, Devices.Date_release, Devices.Date_sale, Devices.Weight, AmountDevices.AmountBye, AmountDevices.AmountSale,AmountDevices.Unusable, AmountDevices.Balance  from Devices inner join TypeDevices on Devices.TypeDeviceId = TypeDevices.Id inner join Makers on Devices.MakerId = Makers.Id inner join Countries on Devices.CountryId = Countries.Id inner join AmountDevices on Devices.Id = AmountDevices.Id;";
            adapter = new SqlDataAdapter(command, connection);

            data.Tables.Clear();
            adapter.Fill(data);

            gridView.DataSource = data.Tables[0];
                  
            connection.Close();
            manager = new DataViewManager(data);

        }

        public async Task ShowType(DataGridView gridView, int id)
        {

            var res = from d in _context.Devices
                      join ad in _context.AmountDevices on d.Id equals ad.Id
                      where d.TypeDeviceId == id
                      select new
                      {
                          d.Id, d.TypeDevice, d.Maker, d.Country, d.Price, d.Weight, d.Date_release,
                          d.Date_sale, ad.AmountBye, ad.AmountSale, ad.Unusable, ad.Balance
                      };

            gridView.DataSource = await res.ToListAsync();
        }
        public async Task ShowMaker(DataGridView gridView, int id)
        {
            var res = from d in _context.Devices
                      join ad in _context.AmountDevices on d.Id equals ad.Id
                      where d.MakerId == id
                      select new
                      {
                          d.Id,
                          d.TypeDevice,
                          d.Maker,
                          d.Country,
                          d.Price,
                          d.Weight,
                          d.Date_release,
                          d.Date_sale,
                          ad.AmountBye,
                          ad.AmountSale,
                          ad.Unusable,
                          ad.Balance
                      };

            gridView.DataSource = await res.ToListAsync();
        }
        public async Task ShowDate(DataGridView gridView, DateTime dateTime)
        {
            var res = from d in _context.Devices
                      join ad in _context.AmountDevices on d.Id equals ad.Id
                      where d.Date_release.Day == dateTime.Day
                      select new
                      {
                          d.Id,
                          d.TypeDevice,
                          d.Maker,
                          d.Country,
                          d.Price,
                          d.Weight,
                          d.Date_release,
                          d.Date_sale,
                          ad.AmountBye,
                          ad.AmountSale,
                          ad.Unusable,
                          ad.Balance
                      };

            gridView.DataSource = await res.ToListAsync();
        }
        public async Task PriceBetween(DataGridView gridView, decimal one, decimal two)
        {
            var res = (from d in _context.Devices
                       join ad in _context.AmountDevices on d.Id equals ad.Id

                       select new
                       {
                           d.Id,
                           d.TypeDevice,
                           d.Maker,
                           d.Country,
                           d.Price,
                           d.Weight,
                           d.Date_release,
                           d.Date_sale,
                           ad.AmountBye,
                           ad.AmountSale,
                           ad.Unusable,
                           ad.Balance
                       }).Where(temp => temp.Price > one && temp.Price < two);

            gridView.DataSource = await res.ToListAsync();
        }
        public async void WeightBetween(DataGridView gridView, int id, float one, float two)
        {
            if (id == -1)
            {
                var res = (from d in _context.Devices
                           join ad in _context.AmountDevices on d.Id equals ad.Id

                           select new
                           {
                               d.Id,
                               d.TypeDevice,
                               d.Maker,
                               d.Country,
                               d.Price,
                               d.Weight,
                               d.Date_release,
                               d.Date_sale,
                               ad.AmountBye,
                               ad.AmountSale,
                               ad.Unusable,
                               ad.Balance
                           }).Where(temp => temp.Weight > one && temp.Weight < two);

                gridView.DataSource = await res.ToListAsync();
            }
            else
            {
                var res = (from d in _context.Devices
                           join ad in _context.AmountDevices on d.Id equals ad.Id
                           where d.MakerId == id
                           select new
                           {
                               d.Id,
                               d.TypeDevice,
                               d.Maker,
                               d.Country,
                               d.Price,
                               d.Weight,
                               d.Date_release,
                               d.Date_sale,
                               ad.AmountBye,
                               ad.AmountSale,
                               ad.Unusable,
                               ad.Balance
                           }).Where(temp => (temp.Weight > one && temp.Weight < two));

                gridView.DataSource = await res.ToListAsync();

            }

        }
        public async Task<int> PartSaleDevice(DataGridView gridView, DateTime date)
        {
            int  count = (from d in _context.Devices
                       join ad in _context.AmountDevices on d.Id equals ad.Id
                       where d.Date_sale.Value.Day <= date.Day
                       select new
                       {
                           d.Id, d.TypeDevice, d.Maker, d.Country, d.Price, d.Weight, d.Date_release, d.Date_sale,
                           ad.AmountBye, ad.AmountSale, ad.Unusable, ad.Balance
                       }).Count();
            if (count > 0)
            {
                var res1 = from d in _context.Devices
                           join ad in _context.AmountDevices on d.Id equals ad.Id
                           where d.Date_sale.Value.Day <= date.Day
                           select new
                           {
                               d.Id,
                               d.TypeDevice,
                               d.Maker,
                               d.Country,
                               d.Price,
                               d.Weight,
                               d.Date_release,
                               d.Date_sale,
                               ad.AmountBye,
                               ad.AmountSale,
                               ad.Unusable,
                               ad.Balance
                           };
                gridView.DataSource = await res1.ToListAsync();

                var res = (from d in _context.Devices
                           join ad in _context.AmountDevices on d.Id equals ad.Id
                           where d.Date_sale.Value.Day <= date.Day
                           select ad.AmountSale).Sum();
                return res;
            }
            else
            {
                return 0;
            }
        }
        public async Task ExpenciveDevice(DataGridView gridView, string choice)
        {
            string temp = choice;
            decimal maxPrice;
            if (temp == "Все категории")
            {
                maxPrice = _context.Devices.Max(d => d.Price);
                var res = from d in _context.Devices
                          join ad in _context.AmountDevices on d.Id equals ad.Id
                          where d.Price == maxPrice
                          select new
                          {
                              d.Id, d.TypeDevice, d.Maker, d.Country, d.Price, d.Weight, d.Date_release,
                              d.Date_sale, ad.AmountBye, ad.AmountSale, ad.Unusable, ad.Balance
                          };
                gridView.DataSource = await res.ToListAsync();
            }
            else
            {
                int id = await typeService.GetIdTypeDevice(temp);
                maxPrice = await _context.Devices.Where(d => d.TypeDeviceId == id).MaxAsync(d => d.Price);
                var res = from d in _context.Devices
                          join ad in _context.AmountDevices on d.Id equals ad.Id
                          where (d.Price == maxPrice && d.TypeDeviceId == id)
                          select new
                          {
                              d.Id, d.TypeDevice, d.Maker, d.Country, d.Price, d.Weight, d.Date_release,
                              d.Date_sale, ad.AmountBye, ad.AmountSale, ad.Unusable, ad.Balance
                          };
                gridView.DataSource = await res.ToListAsync();
            }
        }
        public async Task CheapDevice(DataGridView gridView, string choice) 
        {
            string temp = choice;
            decimal minPrice;
            if (temp == "Все категории")
            {
                minPrice = _context.Devices.Min(d => d.Price);
                var res = from d in _context.Devices
                          join ad in _context.AmountDevices on d.Id equals ad.Id
                          where d.Price == minPrice
                          select new
                          {
                              d.Id, d.TypeDevice, d.Maker, d.Country, d.Price, d.Weight, d.Date_release,
                              d.Date_sale, ad.AmountBye, ad.AmountSale, ad.Unusable, ad.Balance
                          };
                gridView.DataSource = await res.ToListAsync();
            }
            else
            {
                int id = await typeService.GetIdTypeDevice(temp);
                minPrice = await _context.Devices.Where(d => d.TypeDeviceId == id).MinAsync(d => d.Price);
                var res = from d in _context.Devices
                          join ad in _context.AmountDevices on d.Id equals ad.Id
                          where (d.Price == minPrice && d.TypeDeviceId == id)
                          select new
                          {
                              d.Id, d.TypeDevice, d.Maker, d.Country, d.Price, d.Weight, d.Date_release,
                              d.Date_sale, ad.AmountBye, ad.AmountSale, ad.Unusable, ad.Balance
                          };
                gridView.DataSource = await res.ToListAsync();
            }
        }
        public async Task<decimal> AveragePriceDevice(int id)
        {
             
            if (id == 0)
            {
                return await _context.Devices.AverageAsync(d => d.Price);
            }
            else
            {
                
                return await _context.Devices.Where(d => d.TypeDeviceId == id).AverageAsync(d => d.Price);
            }
        }
        public async Task PopularDevice(DataGridView gridView)
        {

            int popDevice = await _context.AmountDevices.MaxAsync(ad => ad.AmountSale);
            var res = from d in _context.Devices
                      join ad in _context.AmountDevices on d.Id equals ad.Id
                      where ad.AmountSale == popDevice
                      select new
                      {
                          d.Id, d.TypeDevice, d.Maker, d.Country, d.Price, d.Weight, d.Date_release,
                          d.Date_sale, ad.AmountBye, ad.AmountSale, ad.Unusable, ad.Balance
                      };
            gridView.DataSource = await res.ToListAsync();

        }
        public async Task<float> PartPriceDevice(DataGridView gridView, int id, decimal price)
        {
            int countDevice = 0;
            int countDeviceAll = 0;
            int AllDevice = 0;
            AllDevice = (from d in _context.Devices
                         join ad in _context.AmountDevices on d.Id equals ad.Id
                         select new
                         {
                              d.Id, d.TypeDevice, d.Maker, d.Country, d.Price, d.Weight, d.Date_release,
                              d.Date_sale, ad.AmountBye, ad.AmountSale, ad.Unusable, ad.Balance
                         }).Count();
            if (AllDevice == 0) return 0;
            else
            {


                countDeviceAll = (from d in _context.Devices
                                  join ad in _context.AmountDevices on d.Id equals ad.Id
                                  select new
                                  {
                                      d.Id, d.TypeDevice, d.Maker, d.Country, d.Price, d.Weight, d.Date_release,
                                      d.Date_sale, ad.AmountBye, ad.AmountSale, ad.Unusable, ad.Balance
                                  }).Sum(ad => ad.AmountBye);

                if (id == 0)
                {

                    var res = from d in _context.Devices
                              join ad in _context.AmountDevices on d.Id equals ad.Id
                              where d.Price < price
                              select new
                              {
                                  d.Id, d.TypeDevice, d.Maker, d.Country, d.Price, d.Weight, d.Date_release,
                                  d.Date_sale, ad.AmountBye, ad.AmountSale, ad.Unusable, ad.Balance
                              };
                    countDevice = (from d in _context.Devices
                                   join ad in _context.AmountDevices on d.Id equals ad.Id
                                   where d.Price < price
                                   select new
                                   {
                                       d.Id, d.TypeDevice, d.Maker, d.Country, d.Price, d.Weight, d.Date_release,
                                       d.Date_sale, ad.AmountBye, ad.AmountSale, ad.Unusable, ad.Balance
                                   }).Sum(ad => ad.AmountBye);


                    gridView.DataSource = await res.ToListAsync();
                    float part = countDevice * 100 / countDeviceAll;
                    return part;
                }
                else
                {
                    var res = from d in _context.Devices
                              join ad in _context.AmountDevices on d.Id equals ad.Id
                              where (d.Price < price && d.MakerId == id)
                              select new
                              {
                                  d.Id, d.TypeDevice, d.Maker, d.Country, d.Price, d.Weight, d.Date_release,
                                  d.Date_sale, ad.AmountBye, ad.AmountSale, ad.Unusable, ad.Balance
                              };
                    countDevice = (from d in _context.Devices
                                   join ad in _context.AmountDevices on d.Id equals ad.Id
                                   where (d.Price < price && d.MakerId == id)
                                   select new
                                   {
                                       d.Id, d.TypeDevice, d.Maker, d.Country, d.Price, d.Weight, d.Date_release, 
                                       d.Date_sale, ad.AmountBye, ad.AmountSale, ad.Unusable, ad.Balance
                                   }).Sum(ad => ad.AmountBye);

                    gridView.DataSource = await res.ToListAsync();

                    float part = countDevice * 100 / countDeviceAll;
                    return part;
                }
            }
        }

        public async Task<int> AmountUnusableDeviceCountry (DataGridView gridView, int id)
        {

            int countDevice = (from d in _context.Devices
                               join ad in _context.AmountDevices on d.Id equals ad.Id
                               where (d.CountryId == id && ad.Unusable != 0)
                               select new
                               {
                                   d.Id, d.TypeDevice, d.Maker, d.Country, d.Price, d.Weight, d.Date_release,
                                   d.Date_sale, ad.AmountBye, ad.AmountSale, ad.Unusable, ad.Balance 
                               }).Count();

            if (countDevice != 0)
            {

                var res = from d in _context.Devices
                          join ad in _context.AmountDevices on d.Id equals ad.Id
                          where (d.CountryId == id && ad.Unusable != 0)
                          select new
                          {
                              d.Id, d.TypeDevice, d.Maker, d.Country, d.Price, d.Weight, d.Date_release,
                              d.Date_sale, ad.AmountBye, ad.AmountSale, ad.Unusable, ad.Balance
                          };
                int amountDevice = (from d in _context.Devices
                                   join ad in _context.AmountDevices on d.Id equals ad.Id
                                   where (d.CountryId == id && ad.Unusable != 0)
                                   select new
                                   {
                                       d.Id, d.TypeDevice, d.Maker, d.Country, d.Price, d.Weight, d.Date_release,
                                       d.Date_sale, ad.AmountBye, ad.AmountSale, ad.Unusable, ad.Balance
                                   }).Sum(ad => ad.Unusable);

                gridView.DataSource = await res.ToListAsync();
                return amountDevice;
            }
            else
            {
                return 0;
            }
        }

        public async Task<int> AmountUnusableDeviceMaker(DataGridView gridView, int id)
        {
            int countDevice = (from d in _context.Devices
                                join ad in _context.AmountDevices on d.Id equals ad.Id
                                where (d.MakerId == id && ad.Unusable != 0)
                                select new
                                {
                                     d.Id, d.TypeDevice, d.Maker, d.Country, d.Price, d.Weight, d.Date_release,
                                     d.Date_sale,  ad.AmountBye, ad.AmountSale, ad.Unusable, ad.Balance
                                }).Count();

            if (countDevice != 0)
            {
                var res = from d in _context.Devices
                          join ad in _context.AmountDevices on d.Id equals ad.Id
                          where (d.MakerId == id && ad.Unusable != 0)
                          select new
                          {
                              d.Id, d.TypeDevice, d.Maker, d.Country, d.Price, d.Weight, d.Date_release,
                              d.Date_sale, ad.AmountBye, ad.AmountSale, ad.Unusable, ad.Balance
                          };
                int amountDevice = (from d in _context.Devices
                                   join ad in _context.AmountDevices on d.Id equals ad.Id
                                   where (d.MakerId == id && ad.Unusable != 0)
                                   select new
                                   {
                                       d.Id, d.TypeDevice, d.Maker, d.Country, d.Price, d.Weight, d.Date_release,
                                       d.Date_sale, ad.AmountBye, ad.AmountSale, ad.Unusable, ad.Balance
                                   }).Sum(ad => ad.Unusable);

                gridView.DataSource = await res.ToListAsync();
                return countDevice;
            }
            else
            {
                return 0;
            }
        }

        public async Task<decimal> HiAverageMaker(DataGridView gridView, int id)
        {
            int count = (from d in _context.Devices
                                    join ad in _context.AmountDevices on d.Id equals ad.Id
                                    where (d.MakerId == id)
                                    select new
                                    {
                                        d.Id, d.TypeDevice, d.Maker, d.Country, d.Price, d.Weight, d.Date_release,
                                        d.Date_sale, ad.AmountBye, ad.AmountSale, ad.Unusable, ad.Balance
                                    }).Count();
            if (count != 0)
            {

                decimal averagePrice = (from d in _context.Devices
                                        join ad in _context.AmountDevices on d.Id equals ad.Id
                                        where (d.MakerId == id)
                                        select new
                                        {
                                            d.Id, d.TypeDevice, d.Maker, d.Country, d.Price, d.Weight, d.Date_release,
                                            d.Date_sale, ad.AmountBye, ad.AmountSale, ad.Unusable, ad.Balance
                                        }).Average(d => d.Price);

                var res = from d in _context.Devices
                          join ad in _context.AmountDevices on d.Id equals ad.Id
                          where (d.MakerId == id && d.Price > averagePrice)
                          select new
                          {
                              d.Id, d.TypeDevice, d.Maker, d.Country, d.Price, d.Weight, d.Date_release,
                              d.Date_sale, ad.AmountBye, ad.AmountSale, ad.Unusable, ad.Balance
                          };

                gridView.DataSource = await res.ToListAsync();
                return averagePrice;
            }
            else
            {
                return 0;
            }
        }
    }
}
