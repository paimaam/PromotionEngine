using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectPromotionEngine.CalculatePromotionPrice;

namespace ProjectPromotionEngine.CalculatePromotionPrice
{
    [ApiController]
    [Route("CalculateFinalPrice")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IFinalPriceCalculatorService _finalPriceCalculatorService;
        public WeatherForecastController(IFinalPriceCalculatorService finalPriceCalculatorService)
        {
            _finalPriceCalculatorService = finalPriceCalculatorService;
        }

        [HttpPost]
        public ActionResult<int> Post([Required][FromBody] GetQuantityDetails quantityDetails)
        {
            var total =  _finalPriceCalculatorService.CalculateFinalPrice(quantityDetails);
            return Ok(total);
        }
    }
}
