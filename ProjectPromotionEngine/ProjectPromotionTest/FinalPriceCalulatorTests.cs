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

        public static IEnumerable<object[]> SomeSetEspeciallyForCandD => new List<object[]>
        {
            new object[] { new GetQuantityDetails("0", "0", "3", "4"), 105},
            new object[] { new GetQuantityDetails("0", "0", "1", "0"), 20},
            new object[] { new GetQuantityDetails("0", "0", "0", "1"), 15},
            new object[] { new GetQuantityDetails("0", "0", "1", "1"), 30},
            new object[] { new GetQuantityDetails("0", "0", "6", "5"), 170},
            new object[] { new GetQuantityDetails("0", "0", "3", "3"), 90},
        };

        [Theory]
        [MemberData(nameof(SetValuesAndGetResponse))]
        public void ActivePromotionScenariosAllScenarios(GetQuantityDetails getQuantityDetails, int expected)
        {
            //Arrange
            var test = new FinalPriceCalculator();
            
            //Act
            var obtainedTotal = test.CalculateFinalPrice(getQuantityDetails);

            //Assert
            obtainedTotal.Should().Be(expected);

        }


        [Theory]
        [MemberData(nameof(SomeSetEspeciallyForCandD))]
        public void GetTotalPriceOnCAndD(GetQuantityDetails getQuantityDetails, int expected)
        {
            //Arrange
            var test = new FinalPriceCalculator();

            //Act
            var obtainedTotal = test.CalculateFinalPrice(getQuantityDetails);

            //Assert
            obtainedTotal.Should().Be(expected);
        }


        [Fact]
        public void ShouldReturnZeroIfNonIntegerIsPassedInReuqest()
        {
            //Arrange
            var test = new FinalPriceCalculator();
            var expected = 0;

            //Act
            var obtainedTotal = test.CalculateFinalPrice(new GetQuantityDetails("a","b", "c", "d"));

            //Assert
            obtainedTotal.Should().Be(expected);
        }
    }
}
