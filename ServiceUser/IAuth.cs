using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork16.ServiceUser
{
    public interface IAuth
    {
        Task<User> AddUser(string lastName, string name, string login, string password, string role);
        Task<User> CheckUser(string login, string password);
    }
}
