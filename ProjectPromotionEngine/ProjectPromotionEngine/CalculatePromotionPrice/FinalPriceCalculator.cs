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
            var (asku, bsku, csku, dsku) = ConvertToInteger(quantityDetails);

            asku = TotalPriceOfA(asku);
            return asku;

        }

        private (int, int, int, int ) ConvertToInteger(GetQuantityDetails quantityDetails)
        {
            int a, b, c, d;
            try
            {
                 a = Int32.Parse(quantityDetails.AQty);
                 b = Int32.Parse(quantityDetails.BQty);
                 c = Int32.Parse(quantityDetails.CQty);
                 d = Int32.Parse(quantityDetails.DQty);


            }
            catch (FormatException e)
            {
                return (0, 0, 0, 0);
            }

            return (a, b, c, d);
        }

        private int TotalPriceOfA(int quantityOfA)
        {
            var (quotient, remainder) = DivideAndGetQuotient(quantityOfA, 3);
            var price = quotient * 130;
            var subPrice = remainder * 50;

            return price + subPrice;
        }

        private (int, int) DivideAndGetQuotient(int divident, int divisor)
        {
            var remainder = divident % divisor;
            var quotient = divident / divisor;

            return (quotient, remainder);
        }
    }
}
