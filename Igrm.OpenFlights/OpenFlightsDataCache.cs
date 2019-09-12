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
    public class OpenFlightsDataCache : IOpenFlightsDataCache
    {
        private readonly IRepositoryBase<AirportsList, Airport> _airportRepository;
        private readonly IRepositoryBase<AircraftsList, Aircraft> _aircraftRepository;
        private readonly IRepositoryBase<RoutesList, Route> _routeRepository;
        private readonly IRepositoryBase<AirlineList, Airline> _airlineRepository;

        public OpenFlightsDataCache(HttpClient httpClient)
        {
            IDataFileLoader dataFileLoader = new DataFileLoader(httpClient);

            _airportRepository = new RepositoryBase<AirportsList, Airport>(dataFileLoader);
            _aircraftRepository = new RepositoryBase<AircraftsList, Aircraft>(dataFileLoader);
            _routeRepository = new RepositoryBase<RoutesList, Route>(dataFileLoader);
            _airlineRepository = new RepositoryBase<AirlineList, Airline>(dataFileLoader);
        }

        public async Task<AircraftsList>  GetAircraftsAsync()
        {
            return await _aircraftRepository.FindAllAsync();
        }

        public async Task<AircraftsList> GetAircraftsAsync(Func<Aircraft, bool> expression)
        {
            return await _aircraftRepository.FindByConditionAsync(expression);
        }

        public async Task<AirlineList> GetAirlinesAsync()
        {
            return await _airlineRepository.FindAllAsync();
        }

        public async Task<AirlineList> GetAirlinesAsync(Func<Airline, bool> expression)
        {
            return await _airlineRepository.FindByConditionAsync(expression);
        }

        public async Task<AirportsList> GetAirportsAsync()
        {
            return await _airportRepository.FindAllAsync();
        }

        public async Task<AirportsList> GetAirportsAsync(Func<Airport, bool> expression)
        {
            return await _airportRepository.FindByConditionAsync(expression);
        }

        public async Task<RoutesList> GetRoutesAsync()
        {
            return await _routeRepository.FindAllAsync();
        }

        public async Task<RoutesList> GetRoutesAsync(Func<Route, bool> expression)
        {
            return await _routeRepository.FindByConditionAsync(expression);
        }
    }
}
