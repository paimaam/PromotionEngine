using FluentAssertions;
using ProjectPromotionEngine.CalculatePromotionPrice;
using System;
using System.Collections.Generic;
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

        public static IEnumerable<object[]> SetValuesAndGetResponse => new List<object[]>
        {
            new object[] { new GetQuantityDetails("1", "1", "1", "0"), 100},
            new object[] { new GetQuantityDetails("5", "5", "1", "0"), 370},
            new object[] { new GetQuantityDetails("3", "5", "1", "1"), 280},

        };

        [Theory]
        [MemberData(nameof(SetValuesAndGetResponse))]
        public void ActivePromotionScenariosAllScenarios(GetQuantityDetails getQuantityDetails, int expected)
        {
            var test = new FinalPriceCalculator();
            var obtainedTotal = test.CalculateFinalPrice(getQuantityDetails);

            obtainedTotal.Should().Be(expected);

        }
    }
}
