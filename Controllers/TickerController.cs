using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Xml.Linq;
using System;

namespace Factory54.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class TickerController : ControllerBase {
        private static Ticker[] MockDataBase;

        private readonly ILogger<TickerController> _logger;

        public TickerController(ILogger<TickerController> logger) {
            _logger = logger;
        }

        [HttpGet("GetTickers")]
        public IEnumerable<Ticker> Get() {
            Random rnd = new Random();
            MockDataBase = Enumerable.Range(1, 10).Select(index => new Ticker {
                id = "" + index,
                num = "" + (1000 + index),
                name = "stock: " + index,
                basePrice = "" + rnd.Next(1000),
                supply = "" + rnd.Next(1000),
                supplyPrice = "" + rnd.Next(1000),
                demand = "" + rnd.Next(1000),
                demandPrice = "" + rnd.Next(1000),
                lastPrice = "" + rnd.Next(1000),
                update = "" + DateTime.Now.ToString("yyyy-MM-dd hh:ss"),
            })
            .ToArray();
            return MockDataBase;
        }

        [HttpGet("GetTickersUpdates")]
        public IEnumerable<Ticker> GetUpdates(int i) {
            Random rnd = new Random();
            
            for (var amountToMod = rnd.Next(MockDataBase.Length); amountToMod > 0; amountToMod--) {
                var toMod = MockDataBase[rnd.Next(MockDataBase.Length)];
                toMod.supply = "" + rnd.Next(1000);
                toMod.supplyPrice = "" + rnd.Next(1000);
                toMod.demand = "" + rnd.Next(1000);
                toMod.demandPrice = "" + rnd.Next(1000);
                toMod.lastPrice = "" + rnd.Next(1000);
                toMod.update = "" + DateTime.Now.ToString("yyyy-MM-dd hh:ss");
            }

            return MockDataBase;
        }
    }
}