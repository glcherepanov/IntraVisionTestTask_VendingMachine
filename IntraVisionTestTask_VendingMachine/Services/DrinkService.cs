using EntityFramework.Repositories;
using IntraVisionTestTask_VendingMachine.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace IntraVisionTestTask_VendingMachine.Services
{
    public class DrinkService : IDrinkService
    {
        private readonly IEntityRepository<EntityFramework.Entities.Drink> _entityRepository;
        private readonly IEntityRepository<EntityFramework.Entities.Coin> _moneyRepository;

        public DrinkService(IEntityRepository<EntityFramework.Entities.Drink> entityRepository, IEntityRepository<EntityFramework.Entities.Coin> moneyRepository)
        {
            _entityRepository = entityRepository;
            _moneyRepository = moneyRepository;
        }

        public List<Drink> GetDrinks()
        {
            return _entityRepository.All.ToList().ConvertAll(Convert);
        }

        public Drink Save(Drink drink)
        {
            if (drink.ImageSrc != null && drink.ImageSrc.StartsWith("http"))
            {
                using (var httpClient = new HttpClient())
                {
                    var ui = new Uri(drink.ImageSrc);
                    byte[] file = httpClient.GetByteArrayAsync(ui).Result;
                    string src = Environment.CurrentDirectory + @"\ClientApp\src\assets\" + drink.Id + ".png";
                    File.WriteAllBytes(src, file);
                    drink.ImageSrc = src;
                }
            }
            return Convert(_entityRepository.Save(Convert(drink)));
        }

        public void Remove(int id)
        {
            _entityRepository.Delete(id);
        }

        private Drink Convert(EntityFramework.Entities.Drink drinkDbo)
        {
            return new Drink
            {
                Id = drinkDbo.Id,
                Price = drinkDbo.Price,
                Count = drinkDbo.Count,
                ImageSrc = drinkDbo.ImageSrc
            };
        }
        private EntityFramework.Entities.Drink Convert(Drink drink)
        {
            return new EntityFramework.Entities.Drink
            {
                Id = drink.Id,
                Price = drink.Price,
                Count = drink.Count,
                ImageSrc = drink.ImageSrc
            };
        }
    }
}
