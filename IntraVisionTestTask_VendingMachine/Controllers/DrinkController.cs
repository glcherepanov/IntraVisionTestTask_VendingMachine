using IntraVisionTestTask_VendingMachine.Models;
using IntraVisionTestTask_VendingMachine.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecuringWebApiUsingApiKey.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntraVisionTestTask_VendingMachine.Controllers
{
    [Route("api/[controller]")]
    public class DrinkController : Controller
    {
        private readonly IDrinkService _drinkService;

        public DrinkController(IDrinkService drinkService)
        {
            _drinkService = drinkService;
        }

        [AllowAnonymous]
        [HttpGet()]
        public List<Drink> GetDrinks()
        {
            return _drinkService.GetDrinks();
        }

        [ApiKey]
        [HttpPost("save")]
        public Drink SaveDrink([FromBody] Drink drink)
        {
            return _drinkService.Save(drink);
        }

        [ApiKey]
        [HttpPost("remove")]
        public void Remove(int id)
        {
            _drinkService.Remove(id);
        }
    }
}
