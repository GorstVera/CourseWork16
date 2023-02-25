using CourseWork16.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork16.ServiceUser
{
    public class UserService : IAuth
    {
        private readonly AppDbContext _context;
        private readonly IEncrypt _encrypt = new Encrypt();
        public UserService()
        {
            _context = new AppDbContext();
            //_encrypt = encrypt;
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
    }
}
