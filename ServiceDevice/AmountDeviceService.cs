using CourseWork16.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork16.ServiceDevice
{
    public class AmountDeviceService
    {
        private readonly AppDbContext _context;
        public AmountDeviceService()
        {
            _context = new AppDbContext();
        }

        public async Task<AmountDevice> AddItem(int id, int amount)
        {

            AmountDevice newAmountDevice = new AmountDevice();

            newAmountDevice.Id = id;
            newAmountDevice.AmountBye = amount;
            newAmountDevice.Balance = amount;
            _context.AmountDevices.Add(newAmountDevice);
            await _context.SaveChangesAsync();
            return newAmountDevice;
        }
        public async Task ChangeAmountSale(int id, int count)
        {
            AmountDevice temp = await _context.AmountDevices.FirstOrDefaultAsync(ad => ad.Id == id);
            temp.AmountSale += count;
            temp.Balance -= count;
            await _context.SaveChangesAsync();

        }
        public async Task ChangeAmountUnusable(int id, int count)
        {
            AmountDevice temp = await _context.AmountDevices.FirstOrDefaultAsync(ad => ad.Id == id);
            temp.Unusable += count;
            temp.Balance -= count;
            await _context.SaveChangesAsync();

        }

        public async Task ChangeAmount(int id, int b, int s, int u, int bal )
        {
            AmountDevice temp = await _context.AmountDevices.FirstOrDefaultAsync(ad => ad.Id == id);
            temp.AmountBye = b;
            temp.AmountSale = s;
            temp.Unusable = u;
            temp.Balance = bal;
            await _context.SaveChangesAsync();

        }

        public async Task<AmountDevice> GetAmountDevice(int id)
        {
            return await _context.AmountDevices.FirstOrDefaultAsync(ad=> ad.Id == id);
        }

        public async Task<bool> RemoveAmountDevice(int id)
        {
            AmountDevice res = await  _context.AmountDevices.FirstOrDefaultAsync(ad => ad.Id == id);
            _context.AmountDevices.Remove(res);
            await _context.SaveChangesAsync();
            res = await _context.AmountDevices.FirstOrDefaultAsync(ad => ad.Id == id);
            if (res == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
