using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectPromotionEngine.CalculatePromotionPrice
{
    public interface IFinalPriceCalculatorService
    {
        public int CalculateFinalPrice(GetQuantityDetails quantityDetails);
    }
}
