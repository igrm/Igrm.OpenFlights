using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Igrm.OpenFlights.Tests.IntegrationTests.Fixtures
{
    public class HttpClientFixture
    {
        public HttpClient HttpClient { get; private set; }
        public HttpClientFixture()
        {
            HttpClient = new HttpClient();
        }
    }
}
