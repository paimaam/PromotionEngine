using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectPromotionEngine.CalculatePromotionPrice
{
    public class FinalPriceCalculator : IFinalPriceCalculatorService
    {
        private const int PriceOfA = 50;
        private const int PriceOfB = 30;
        private const int PriceOfC = 20;
        private const int PriceOfD = 20;

        public int  CalculateFinalPrice(GetQuantityDetails quantityDetails)
        {
            return 100;
        }
    }
}
