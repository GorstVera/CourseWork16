using CourseWork16.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork16.ServiceUser
{
    public class UserService : IAuth
    {
        private readonly AppDbContext _context;
        private readonly IEncrypt _encrypt = new Encrypt();
        public UserService()
        {
            _context = new AppDbContext();
        }
        public async Task<User> AddUser(string lastName, string name, string login, string password, string role)
        {
            UserRole userRole;
            if (UserRole.Администратор.ToString() == role)
            {
                userRole = UserRole.Администратор;
            }
            else
            {
                userRole = UserRole.Менеджер;
            }
            string salt = Guid.NewGuid().ToString();
            User user = new User
            {
                Name= name,
                LastName= lastName,
                Login = login,
                Password = _encrypt.HashPassword(password, salt),
                Salt = salt,
                Role = userRole
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
            
        }

        public async Task<User> CheckUser(string login, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Login == login);
            if (user != null)
            {
                if (user.Password == _encrypt.HashPassword(password, user.Salt))
                {
                    return user;
                }
            }
            
            return null;
        }
        public async Task<User> GetUser(string login)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Login == login);
        }
        public async Task<User> GetUser(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<List<User>> ShowAllUsers()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task<bool> RemoveUser(int id)
        {
            var user = await GetUser(id);
            if (user == null)
            {
                MessageBox.Show("Удаление не возможно");
            }
            else
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
            user = await GetUser(id);
            if (user == null)
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
