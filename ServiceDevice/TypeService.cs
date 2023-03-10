using CourseWork16.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork16.ServiceDevice
{
    public class TypeService 
    {
        private readonly AppDbContext _context;
        public static TypeService Instance { get => TypeServiceCreate.instance; }
        public TypeService()
        {
            _context = new AppDbContext();
        }

        private class TypeServiceCreate
        {
            static TypeServiceCreate() { }
            internal static readonly TypeService instance = new TypeService();
        }
        
        public  async Task<TypeDevice> AddItem(string name)
        {
            TypeDevice newTypeDevice = new TypeDevice();
            newTypeDevice.NameType = name;
            _context.TypeDevices.Add(newTypeDevice);
            await _context.SaveChangesAsync();
            return newTypeDevice;
        }
        public async Task<int> GetIdTypeDevice(string type)
        {
            TypeDevice resTD = await GetItem(type);
            return  resTD.Id;
        }

        public async Task<bool> DeleteTypeDevice(int id)
        {
            TypeDevice temp = await GetItem(id);
            _context.TypeDevices.Remove(temp);
            await _context.SaveChangesAsync();
            var res = await GetItem(id);
            if (res == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async  Task<List<TypeDevice>> GetAll()
        {
            return  await _context.TypeDevices.ToListAsync();
        }

        public async Task<TypeDevice> GetItem(string name)
        {
            return  await _context.TypeDevices.FirstOrDefaultAsync(tp => tp.NameType == name);
        }

        public async Task<TypeDevice> GetItem(int id)
        {
            return await _context.TypeDevices.FirstOrDefaultAsync(tp => tp.Id == id);
        }

    }
}
