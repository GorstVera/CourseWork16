using CourseWork16.ServiceDevice;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork16.Model
{
    public class AmountDevice
    {
        [Key]
        [ForeignKey("Device")]
        public int Id { get; set; }
        public int AmountBye { get; set; }
        public int AmountSale { get; set; }
        public int Unusable { get; set; }
        public int Balance { get; set; }
        public Device Device { get; set; }
    }
}
