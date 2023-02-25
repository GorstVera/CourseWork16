using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork16.Model
{
    public class Device
    {
        public int Id { get; set; }
        //public string TypeDevice { get; set; }
        public decimal Price { get; set; }
        public DateTime Date_release { get; set; }
        public DateTime? Date_sale { get; set; }
        public float Weight { get; set; }

        public int TypeDeviceId { get; set; }
        public TypeDevice TypeDevice { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public int MakerId { get; set; }
        public Maker Maker { get; set; }

        public override string ToString()
        {
            return $" {Price} {Weight}";
        }
    }
}
