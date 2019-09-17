using Igrm.OpenFlights.Tests.IntegrationTests.Fixtures;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;

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
                Assert.True(cache.GetAircraftsAsync().Result.Where(x=>!String.IsNullOrEmpty(x.Name)).Count() > 0);
            }
                
        }

        [Fact]
        public void GetAllRoutes()
        {
            using (IOpenFlightsDataCache cache = new OpenFlightsDataCache(_httpClientFixture.HttpClient))
            {
                Assert.True(cache.GetRoutesAsync().Result.Where(x => !String.IsNullOrEmpty(x.SourceAirport)).Count() > 0);
            }
        }

        [Fact]
        public void GetAllAirports()
        {
            using (IOpenFlightsDataCache cache = new OpenFlightsDataCache(_httpClientFixture.HttpClient))
            {
                Assert.True(cache.GetAirportsAsync().Result.Where(x => !String.IsNullOrEmpty(x.Name)).Count() > 0);
            }
        }

        [Fact]
        public void GetAllAirlines()
        {
            using (IOpenFlightsDataCache cache = new OpenFlightsDataCache(_httpClientFixture.HttpClient))
            {
                Assert.True(cache.GetAirlinesAsync().Result.Where(x => !String.IsNullOrEmpty(x.Name)).Count() > 0);
            }
        }
    }
}
