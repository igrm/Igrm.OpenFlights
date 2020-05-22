using Igrm.OpenFlights.Helpers;
using Igrm.OpenFlights.Implementations;
using Igrm.OpenFlights.Interfaces;
using Igrm.OpenFlights.Models;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Igrm.OpenFlights
{
    /// <summary>
    /// OpenFlights data provider.
    /// Serves lists of airports, aircraft, airlines and routes.
    /// CSV files are automatically downloaded to the temporal folder, loaded into .NET models and cached in MemoryCache.
    /// Please refer to https://openflights.org/data.html for more details.
    /// </summary>
    public class OpenFlightsDataCache : IOpenFlightsDataCache
    {
        private readonly IAirportRepository _airportRepository;
        private readonly IAircraftRepository _aircraftRepository;
        private readonly IRouteRepository _routeRepository;
        private readonly IAirlineRepository _airlineRepository;

        private IMemoryCache _memoryCache;
        private HttpClient _httpClient;

        private readonly DisposeModeEnum _disposeMode;
        private bool disposedValue;

        public OpenFlightsDataCache(HttpClient httpClient, IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
            _httpClient = httpClient;
            _disposeMode = DisposeModeEnum.DoNothing;

            IDataAccessFactory factory = new DataAccessFactory(_httpClient, _memoryCache);
            _airportRepository = factory.CreateAirportRepository();
            _aircraftRepository = factory.CreateAircraftRepository();
            _routeRepository = factory.CreateRouteRepository();
            _airlineRepository = factory.CreateAirlineRepository();
        }

        public OpenFlightsDataCache(HttpClient httpClient): this(httpClient, new MemoryCache(new MemoryCacheOptions()))
        {
            _disposeMode = DisposeModeEnum.DisposeMemoryCache;    
        }

        public OpenFlightsDataCache(): this(new HttpClient(), new MemoryCache(new MemoryCacheOptions()))
        {
            _disposeMode = DisposeModeEnum.DisposeHttpClientAndMemoryCache;
        }

        /// <summary>
        /// Get list of aircrafts from https://openflights.org/data.html.
        /// </summary>
        public async Task<AircraftsList>  GetAircraftsAsync()
        {
            return await _aircraftRepository.FindAllAsync();
        }

        /// <summary>
        /// Get list of aircraft from https://openflights.org/data.html.
        /// </summary>
        /// <param name="expression">Used to filter the list.</param>
        public async Task<AircraftsList> GetAircraftsAsync(Func<Aircraft, bool> expression)
        {
            return await _aircraftRepository.FindByConditionAsync(expression);
        }

        /// <summary>
        /// Get list of airlines from https://openflights.org/data.html.
        /// </summary>
        public async Task<AirlineList> GetAirlinesAsync()
        {
            return await _airlineRepository.FindAllAsync();
        }

        /// <summary>
        /// Get list of airlines from https://openflights.org/data.html.
        /// </summary>
        /// <param name="expression">Used to filter the list.</param>
        public async Task<AirlineList> GetAirlinesAsync(Func<Airline, bool> expression)
        {
            return await _airlineRepository.FindByConditionAsync(expression);
        }

        /// <summary>
        /// Get list of airports from https://openflights.org/data.html.
        /// </summary>
        public async Task<AirportsList> GetAirportsAsync()
        {
            return await _airportRepository.FindAllAsync();
        }

        /// <summary>
        /// Get list of airports from https://openflights.org/data.html.
        /// </summary>
        /// <param name="expression">Used to filter the list.</param>
        public async Task<AirportsList> GetAirportsAsync(Func<Airport, bool> expression)
        {
            return await _airportRepository.FindByConditionAsync(expression);
        }

        /// <summary>
        /// Get list of routes from https://openflights.org/data.html.
        /// </summary>
        public async Task<RoutesList> GetRoutesAsync()
        {
            return await _routeRepository.FindAllAsync();
        }

        /// <summary>
        /// Get list of routes from https://openflights.org/data.html.
        /// </summary>
        /// <param name="expression">Used to filter the list.</param>
        public async Task<RoutesList> GetRoutesAsync(Func<Route, bool> expression)
        {
            return await _routeRepository.FindByConditionAsync(expression);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {

                }
                
                _httpClient = null;
                _memoryCache = null;

                disposedValue = true;
            }
        }

       public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
