using CourseWork16.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork16.ServiceDevice
{
    class MakerService 
    {
        private readonly AppDbContext _context;
        public MakerService()
        {
            _context = new AppDbContext();
        }
        public  async Task<Maker> AddItem(string name)
        {
            Maker maker = new Maker();
            maker.NameMaker = name;
            _context.Makers.Add(maker);
            await _context.SaveChangesAsync();
            return maker;
        }

        public async Task<int> GetIdMaker(string maker)
        {
            Maker resM = await GetItem(maker);
            return resM.Id;
        }

        public async Task<bool> DeleteMaker(int id)
        {
            Maker temp = await GetItem(id);
            _context.Makers.Remove(temp);
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

        public async Task<Maker> GetItem(string name)
        {
            return  await _context.Makers.FirstOrDefaultAsync(m => m.NameMaker == name);
        }
        public async Task<Maker> GetItem(int id)
        {
            return await _context.Makers.FirstOrDefaultAsync(tp => tp.Id == id);
        }
        public async Task<List<Maker>> GetAll()
        {
            return  await _context.Makers.ToListAsync();
        }
    }
}
