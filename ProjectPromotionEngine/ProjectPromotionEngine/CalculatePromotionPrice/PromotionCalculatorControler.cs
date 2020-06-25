using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

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
