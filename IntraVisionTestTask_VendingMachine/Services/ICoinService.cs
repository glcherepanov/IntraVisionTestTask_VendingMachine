using IntraVisionTestTask_VendingMachine.Models;
using System.Collections.Generic;

namespace IntraVisionTestTask_VendingMachine.Services
{
    public interface ICoinService
    {
        public Coin Save(Coin money);
        public void Remove(int id);
        public List<Coin> GetCoins();
    }
}
