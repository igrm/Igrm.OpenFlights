using Igrm.OpenFlights.Tests.IntegrationTests.Fixtures;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Igrm.OpenFlights.Tests.IntegrationTests.Facts
{
    public class OpenFlightsDataCacheFacts : IClassFixture<HttpClientFixture>
    {
        private readonly HttpClientFixture _httpClientFixture;
        public OpenFlightsDataCacheFacts(HttpClientFixture httpClientFixture)
        {
            _httpClientFixture = httpClientFixture;
        }

        [Fact]
        public void GetAllAircrafts()
        {
            IOpenFlightsDataCache cache = new OpenFlightsDataCache(_httpClientFixture.HttpClient);
            Assert.True(cache.GetAircraftsAsync().Result.Count > 0);
        }
    }
}
