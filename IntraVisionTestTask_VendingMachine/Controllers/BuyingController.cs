using IntraVisionTestTask_VendingMachine.Models;
using IntraVisionTestTask_VendingMachine.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntraVisionTestTask_VendingMachine.Controllers
{
    [Route("api/[controller]")]
    public class BuyingController : Controller
    {
        private readonly IBuyingService _buyingService;

        public BuyingController(IBuyingService buyingService)
        {
            _buyingService = buyingService;
        }

        [HttpPost()]
        public List<Coin> Buy([FromBody] Basket basket)
        {
            return _buyingService.Buy(basket);
        }
    }
}
