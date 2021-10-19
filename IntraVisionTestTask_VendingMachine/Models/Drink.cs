using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntraVisionTestTask_VendingMachine.Models
{
    public class Drink
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
        public string ImageSrc { get; set; }
    }
}
