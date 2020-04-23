using System;
using System.Threading.Tasks;
using Application.WheaterForecasts.Queries.GetWheaterForecasts;
using FluentAssertions;
using Xunit;
using static Application.IntegrationTests.IntegrationTestFixture;

namespace Application.IntegrationTests.WheaterForecasts.Queries
{
    public class GetWheaterForecastsTests : IClassFixture<IntegrationTestFixture>
    {
        [Fact]
        public async Task ShouldGetWheaterForecasts()
        {
             var query = new GetWheaterForecastsQuery();

            var result = await SendAsync(query);

            result.Should().HaveCount(5);
        }
    }
}
