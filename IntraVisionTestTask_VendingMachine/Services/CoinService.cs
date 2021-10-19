using EntityFramework.Repositories;
using IntraVisionTestTask_VendingMachine.Models;
using System.Collections.Generic;
using System.Linq;

namespace IntraVisionTestTask_VendingMachine.Services
{
    public class CoinService : ICoinService
    {
        private readonly IEntityRepository<EntityFramework.Entities.Coin> _entityRepository;

        public CoinService(IEntityRepository<EntityFramework.Entities.Coin> entityRepository)
        {
            _entityRepository = entityRepository;
        }

        public List<Coin> GetCoins()
        {
            return _entityRepository.All.ToList().ConvertAll(Convert);
        }

        public Coin Save(Coin money)
        {
            return Convert(_entityRepository.Save(Convert(money)));
        }

        public void Remove(int id)
        {
            _entityRepository.Delete(id);
        }

        private Coin Convert(EntityFramework.Entities.Coin coin)
        {
            return new Coin
            {
                Id = coin.Id,
                Denomination = coin.Denomination,
                Count = coin.Count,
                IsAvailable = coin.IsAvaliable
            };
        }
        private EntityFramework.Entities.Coin Convert(Coin coin)
        {
            return new EntityFramework.Entities.Coin
            {
                Id = coin.Id,
                Denomination = coin.Denomination,
                Count = coin.Count,
                IsAvaliable = coin.IsAvailable
            };
        }
    }
}
