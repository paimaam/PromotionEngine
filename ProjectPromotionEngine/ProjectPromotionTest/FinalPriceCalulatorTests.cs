using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using ProjectPromotionEngine;
using ProjectPromotionEngine.CalculatePromotionPrice;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProjectPromotionTest
{
    public class FinalPriceCalulatorTests
    {
        private readonly HttpClient _client;
        public FinalPriceCalulatorTests()
        {
            var factory = new WebApplicationFactory<Startup>();
            _client = factory.CreateClient();
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

        [Fact]
        public async Task HitTheEndPoint()
        {

            string json = JsonConvert.SerializeObject(new GetQuantityDetails("0", "0", "3", "4"), Formatting.Indented);
            var httpContent = new StringContent(json,Encoding.UTF8,"application/json");

            var response = await _client.PostAsync("/CalculateFinalPrice", httpContent);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
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
