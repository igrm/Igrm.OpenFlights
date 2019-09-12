using Igrm.OpenFlights.Models;
using System;
using System.Threading.Tasks;

namespace Igrm.OpenFlights
{
    public interface IOpenFlightsDataCache
    {
        Task<AircraftsList> GetAircraftsAsync();
        Task<AircraftsList> GetAircraftsAsync(Func<Aircraft,bool> expression);
        Task<AirportsList> GetAirportsAsync();
        Task<AirportsList> GetAirportsAsync(Func<Airport, bool> expression);
        Task<AirlineList> GetAirlinesAsync();
        Task<AirlineList> GetAirlinesAsync(Func<Airline, bool> expression);
        Task<RoutesList> GetRoutesAsync();
        Task<RoutesList> GetRoutesAsync(Func<Route, bool> expression);
    }
}
