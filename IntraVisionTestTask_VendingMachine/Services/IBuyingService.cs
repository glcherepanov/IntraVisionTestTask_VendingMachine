using IntraVisionTestTask_VendingMachine.Models;
using System.Collections.Generic;

namespace IntraVisionTestTask_VendingMachine.Services
{
    public interface IBuyingService
    {
        public List<Coin> Buy(Basket basket);
    }
}
