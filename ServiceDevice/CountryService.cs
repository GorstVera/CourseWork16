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

        public Task<IDevice> DeleteItem()
        {
            throw new NotImplementedException();
        }

        public async Task<Country> GetItem(string name)
        {
            return await _context.Countries.FirstOrDefaultAsync(c => c.NameCountry == name);
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

        public Task<IDevice> UpdateItem()
        {
            throw new NotImplementedException();
        }
    }
}
