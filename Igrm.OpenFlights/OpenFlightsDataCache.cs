using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Igrm.OpenFlights.Implementations;
using Igrm.OpenFlights.Interfaces;
using Igrm.OpenFlights.Models;

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
        private readonly IRepositoryBase<AirportsList, Airport> _airportRepository;
        private readonly IRepositoryBase<AircraftsList, Aircraft> _aircraftRepository;
        private readonly IRepositoryBase<RoutesList, Route> _routeRepository;
        private readonly IRepositoryBase<AirlineList, Airline> _airlineRepository;

        public OpenFlightsDataCache(HttpClient httpClient)
        {
            IDataFileLoader dataFileLoader = new DataFileLoader(httpClient);
            Task t = dataFileLoader.LoadAllFilesAsync();
            _airportRepository = new RepositoryBase<AirportsList, Airport>(dataFileLoader);
            _aircraftRepository = new RepositoryBase<AircraftsList, Aircraft>(dataFileLoader);
            _routeRepository = new RepositoryBase<RoutesList, Route>(dataFileLoader);
            _airlineRepository = new RepositoryBase<AirlineList, Airline>(dataFileLoader);
            t.Wait();
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

        public void Dispose()
        {
            _routeRepository.Dispose();
            _aircraftRepository.Dispose();
            _airportRepository.Dispose();
            _airlineRepository.Dispose();
        }
    }
}
