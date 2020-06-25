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
        private const int PriceOfD = 15;
        private const int PriceOfC_D = 30;

        public int CalculateFinalPrice(GetQuantityDetails quantityDetails)
        {
            var (quantA, quantB, quantC, quantD) = ConvertToInteger(quantityDetails);

            quantA = TotalPriceOfA(quantA);

            quantB = TotalPriceOfB(quantB);

            quantC = TotalCandD(quantC, quantD);

            return quantA + quantB + quantC;

        }

        private (int, int, int, int) ConvertToInteger(GetQuantityDetails quantityDetails)
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
            var subPrice = remainder * PriceOfA;

            return price + subPrice;
        }

        private int TotalPriceOfB(int quantityOfB)
        {
            var (quotient, remainder) = DivideAndGetQuotient(quantityOfB, 2);
            var price = quotient * 45;
            var subPrice = remainder * PriceOfB;

            return price + subPrice;
        }

        private int TotalCandD(int quantityOfC, int quantityOfD)
        {
            if (quantityOfC == quantityOfD)
            {
                return quantityOfC * PriceOfC_D;
            }

            else if (quantityOfC > quantityOfD)
            {
                var basePrice = quantityOfD * PriceOfC_D;
                var subPrice = (quantityOfC - quantityOfD) * PriceOfC;

                return basePrice + subPrice;
            }

            else
            {
                var basePrice = quantityOfC * PriceOfC_D;
                var subPrice = (quantityOfD - quantityOfC) * PriceOfD;

                return basePrice + subPrice;
            }

        }

        private (int, int) DivideAndGetQuotient(int divident, int divisor)
        {
            var remainder = divident % divisor;
            var quotient = divident / divisor;

            return (quotient, remainder);
        }
    }
}
