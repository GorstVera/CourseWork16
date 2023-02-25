using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork16.ServiceDevice
{
    public interface IServiceDevice
    {
        Task<IDevice> AddItem(string name);
        Task<IDevice> GetItem(string name);
        Task<IDevice> DeleteItem();
        Task<IDevice> UpdateItem();
    }
}
