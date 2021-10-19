using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntraVisionTestTask_VendingMachine.Models
{
    public class Coin
    {
        public int Id { get; set; }
        public int Denomination { get; set; }
        public int Count { get; set; }
        public bool IsAvailable { get; set; }
    }
}
