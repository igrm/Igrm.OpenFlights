using Igrm.OpenFlights.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System.Net.Http;

namespace Igrm.OpenFlights.Implementations
{
    public class DataAccessFactory : IDataAccessFactory
    {
        private readonly IDataFileLoader _dataFileLoader;
        private readonly IMemoryCache _memoryCache;

        public DataAccessFactory(HttpClient httpClient, IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
            _dataFileLoader = new DataFileLoader(httpClient);
            _dataFileLoader.LoadAllFilesAsync().Wait();

        }
        public IAircraftRepository CreateAircraftRepository()
        {
            return new AircraftRepository(_dataFileLoader, _memoryCache);
        }

        public IAirlineRepository CreateAirlineRepository()
        {
            return new AirlineRepository(_dataFileLoader, _memoryCache);
        }

        public IAirportRepository CreateAirportRepository()
        {
            return new AirportRepository(_dataFileLoader, _memoryCache);
        }

        public IRouteRepository CreateRouteRepository()
        {
            return new RouteRepository(_dataFileLoader, _memoryCache);
        }
    }
}
