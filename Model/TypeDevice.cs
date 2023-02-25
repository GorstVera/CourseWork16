using CourseWork16.ServiceDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork16.Model
{
    public class TypeDevice
    {
        public int Id { get; set; }
        public string NameType { get; set; }
        public ICollection<Device> Devices { get; set; } = new List<Device>();

        public override string ToString()
        {
            return $"{NameType}";
        }


    }
}
