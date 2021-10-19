using IntraVisionTestTask_VendingMachine.Models;
using System.Collections.Generic;

namespace IntraVisionTestTask_VendingMachine.Services
{
    public interface IDrinkService
    {
        public Drink Save(Drink drink);
        public void Remove(int id);
        public List<Drink> GetDrinks();
    }
}
