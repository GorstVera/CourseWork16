using CourseWork16.ServiceDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork16.Model
{
    public class Maker 
    {
        public int Id { get; set; }
        public string NameMaker { get; set; }

        public ICollection<Device> Devices { get; set; } = new List<Device>();

        public override string ToString()
        {
            return $"{NameMaker}";
        }
    }
}
