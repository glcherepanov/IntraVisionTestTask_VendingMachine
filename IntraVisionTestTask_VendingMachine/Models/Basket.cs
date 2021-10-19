using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntraVisionTestTask_VendingMachine.Models
{
    public class Basket
    {
        public List<Drink> Drinks { get; set; }
        public List<Coin> Coins { get; set; }
        public int Change { get; set; }
    }
}
