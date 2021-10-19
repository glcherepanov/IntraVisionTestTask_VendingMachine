using EntityFramework.Repositories;
using IntraVisionTestTask_VendingMachine.Models;
using System.Collections.Generic;
using System.Linq;

namespace IntraVisionTestTask_VendingMachine.Services
{
    public class BuyingService : IBuyingService
    {
        private readonly IEntityRepository<EntityFramework.Entities.Drink> _drinkingRepository;
        private readonly IEntityRepository<EntityFramework.Entities.Coin> _moneyRepository;

        public BuyingService(IEntityRepository<EntityFramework.Entities.Drink> drinkingRepository, IEntityRepository<EntityFramework.Entities.Coin> moneyRepository)
        {
            _drinkingRepository = drinkingRepository;
            _moneyRepository = moneyRepository;
        }

        public List<Coin> Buy(Basket basket)
        {
            basket.Drinks.ForEach(d =>
            {
                EntityFramework.Entities.Drink drink = _drinkingRepository.GetItem(d.Id);
                drink.Count--;
                _drinkingRepository.Save(drink);
            });

            basket.Coins.ForEach(c =>
            {
                EntityFramework.Entities.Coin coin = _moneyRepository.GetItem(c.Id);
                coin.Count++;
                _moneyRepository.Save(coin);
            });

            IQueryable<EntityFramework.Entities.Coin> coinsDbo = from c in _moneyRepository.All
                                                                  orderby c.Denomination descending
                                                                  select c;
            List<Coin> change = new List<Coin>();

            coinsDbo.ToList().ForEach(c =>
            {
                while ( basket.Change >= c.Denomination )
                {
                    basket.Change -= c.Denomination;
                    change.Add(Convert(c));
                    c.Count--;
                    _moneyRepository.Save(c);
                }
            });

            return change;
        }

        private Coin Convert(EntityFramework.Entities.Coin drinkDbo)
        {
            return new Coin
            {
                Id = drinkDbo.Id,
                Denomination = drinkDbo.Denomination,
                Count = drinkDbo.Count,
                IsAvailable = drinkDbo.IsAvaliable
            };
        }
    }
}
