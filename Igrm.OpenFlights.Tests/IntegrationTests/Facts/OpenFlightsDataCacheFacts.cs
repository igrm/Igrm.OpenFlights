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
            using (IOpenFlightsDataCache cache = new OpenFlightsDataCache(_httpClientFixture.HttpClient))
            {
                Assert.True(cache.GetAircraftsAsync().Result.Count > 0);
            }
                
        }

        [Fact]
        public void GetAllRoutes()
        {
            using (IOpenFlightsDataCache cache = new OpenFlightsDataCache(_httpClientFixture.HttpClient))
            {
                Assert.True(cache.GetRoutesAsync().Result.Count > 0);
            }
        }

        [Fact]
        public void GetAllAirports()
        {
            using (IOpenFlightsDataCache cache = new OpenFlightsDataCache(_httpClientFixture.HttpClient))
            {
                Assert.True(cache.GetAirportsAsync().Result.Count > 0);
            }
        }

        [Fact]
        public void GetAllAirlines()
        {
            using (IOpenFlightsDataCache cache = new OpenFlightsDataCache(_httpClientFixture.HttpClient))
            {
                Assert.True(cache.GetAirlinesAsync().Result.Count > 0);
            }
        }
    }
}
