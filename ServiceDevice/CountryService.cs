using CourseWork16.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork16.ServiceDevice
{
    public class CountryService 
    {
        private readonly AppDbContext _context;
        public CountryService()
        {
            _context = new AppDbContext();
        }
        public async Task<Country> AddItem(string name)
        {
            Country country = new Country();
            country.NameCountry = name;
            _context.Countries.Add(country);
            await _context.SaveChangesAsync();
            return country;
        }

        public async Task<bool> DeleteCountry(int id)
        {
            Country temp = await GetItem(id);
            _context.Countries.Remove(temp);
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

        public async Task<Country> GetItem(string name)
        {
            return await _context.Countries.FirstOrDefaultAsync(c => c.NameCountry == name);
        }
        public async Task<Country> GetItem(int id)
        {
            return await _context.Countries.FirstOrDefaultAsync(c => c.Id == id);
        }
        public async Task<int> GetIdCountry(string type)
        {
            Country resC = await GetItem(type);
            return resC.Id;
        }

        public async Task<List<Country>> GetAll()
        {
            return await _context.Countries.ToListAsync();
        }
    }
}
