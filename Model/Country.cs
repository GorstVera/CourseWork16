using CourseWork16.ServiceDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork16.Model
{
    public class Country
    {
        public int Id { get; set; }
        public string NameCountry { get; set; }
        public ICollection<Device> Devices { get; set; } = new List<Device>();

        public static explicit operator Country(Task<IDevice> v)
        {
            throw new NotImplementedException();
        }
        public override string ToString()
        {
            return $"{NameCountry}";
        }
    }
}
