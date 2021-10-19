using IntraVisionTestTask_VendingMachine.Models;
using IntraVisionTestTask_VendingMachine.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecuringWebApiUsingApiKey.Attributes;
using System.Collections.Generic;

namespace IntraVisionTestTask_VendingMachine.Controllers
{
    [Route("api/[controller]")]
    public class CoinController : Controller
    {
        private readonly ICoinService _coinService;

        public CoinController(ICoinService coinService)
        {
            _coinService = coinService;
        }

        [AllowAnonymous]
        [HttpGet()]
        public List<Coin> Get()
        {
            return _coinService.GetCoins();
        }

        [ApiKey]
        [HttpPost("save")]
        public Coin Save([FromBody] Coin money)
        {
            return _coinService.Save(money);
        }

        [ApiKey]
        [HttpPost("remove")]
        public void Remove(int id)
        {
            _coinService.Remove(id);
        }
    }
}
