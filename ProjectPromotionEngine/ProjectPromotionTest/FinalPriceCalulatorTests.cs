using FluentAssertions;
using ProjectPromotionEngine.CalculatePromotionPrice;
using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace ProjectPromotionTest
{
    public class FinalPriceCalulatorTests
    {
   
        public FinalPriceCalulatorTests()
        {
  
        }
        [Fact]
        public  void InitialTest()
        {

            var test = new FinalPriceCalculator();
           var c =  test.CalculateFinalPrice(new GetQuantityDetails("1", "2", "3", "4"));
           
        }
    }
}
