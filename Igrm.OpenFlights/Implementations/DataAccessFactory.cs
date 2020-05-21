using Igrm.OpenFlights.Interfaces;
using System.Net.Http;

namespace Igrm.OpenFlights.Implementations
{
    public class DataAccessFactory : IDataAccessFactory
    {
        private IDataFileLoader _dataFileLoader;

        public DataAccessFactory(HttpClient httpClient)
        {
            _dataFileLoader = new DataFileLoader(httpClient);
            _dataFileLoader.LoadAllFilesAsync().Wait();

        }
        public IAircraftRepository CreateAircraftRepository()
        {
            return new AircraftRepository(_dataFileLoader);
        }

        public IAirlineRepository CreateAirlineRepository()
        {
            return new AirlineRepository(_dataFileLoader);
        }

        public IAirportRepository CreateAirportRepository()
        {
            return new AirportRepository(_dataFileLoader);
        }

        public IRouteRepository CreateRouteRepository()
        {
            return new RouteRepository(_dataFileLoader);
        }
    }
}
