using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork16.ServiceUser
{
    public enum UserRole
    {
        Менеджер,
        Администратор
    }
    public class User
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public UserRole Role { get; set; }

        public override string ToString()
        {
            return $"Имя: {Name} Фамилия: {LastName} Доступ: {Role}";
        }
    }
}
