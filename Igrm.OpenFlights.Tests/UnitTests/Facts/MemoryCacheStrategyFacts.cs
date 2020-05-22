using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using Igrm.OpenFlights.Interfaces;
using Igrm.OpenFlights.Models;
using System.Threading.Tasks;
using Igrm.OpenFlights.Implementations;
using Microsoft.Extensions.Caching.Memory;

namespace Igrm.OpenFlights.Tests.UnitTests.Facts
{
    public class MemoryCacheStrategyFacts
    {
        public class PostEvictionDelegateTests
        {
            [Fact]
            public void WhenCacheExpired_FileLoadIsCalled()
            {
                //ARRANGE
                bool fileLoaded = false;
                var dataFileLoader = new Mock<IDataFileLoader>(MockBehavior.Loose);
                dataFileLoader.Setup(x => x.LoadFileAsync<AircraftsList>(true)).Returns(Task.Run(() => { fileLoaded = true; }));
                //ACT
                ICacheStrategy<AircraftsList> cache = new MemoryCacheStrategy<AircraftsList>(1, dataFileLoader.Object, new MemoryCache(new MemoryCacheOptions()));
                cache.ExecuteSetAsyn(new AircraftsList(), "Planes").Wait();
                Task.Delay(70000).Wait();
                //ASSERT
                Assert.True(fileLoaded);
            }
        }
    }
}
