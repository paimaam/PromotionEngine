using ProjectPromotionEngine.CalculatePromotionPrice.PriceCaluclatorforSku;
using System;

namespace ProjectPromotionEngine.CalculatePromotionPrice
{
    public class FinalPriceCalculator : IFinalPriceCalculatorService
    {

        private readonly IModulePriceCalculator _modulePriceCalculator;
        public FinalPriceCalculator(IModulePriceCalculator modulePriceCalculator)
        {
            _modulePriceCalculator = modulePriceCalculator;
        }

        public int CalculateFinalPrice(GetQuantityDetails quantityDetails)
        {
            var quantA = _modulePriceCalculator.TotalPriceOfA(int.Parse(quantityDetails.AQty));

            var quantB = _modulePriceCalculator.TotalPriceOfB(int.Parse(quantityDetails.BQty));

            var quantC = _modulePriceCalculator.TotalPriceOfCAndD(int.Parse(quantityDetails.CQty), int.Parse(quantityDetails.DQty));

            return quantA + quantB + quantC;

        }
    }
}
