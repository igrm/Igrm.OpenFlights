using Igrm.OpenFlights.Attributes;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Igrm.OpenFlights.Models
{
    public class Route
    {
        ///<summary>
        ///2-letter (IATA) or 3-letter (ICAO) code of the airline.
        ///</summary>
        public string Airline { get; set; }
        ///<summary>
        ///Unique OpenFlights identifier for airline (see Airline).
        ///</summary>
        public int AirlineId { get; set; }
        ///<summary>
        ///3-letter (IATA) or 4-letter (ICAO) code of the source airport.
        ///</summary>
        public string SourceAirport { get; set; }
        ///<summary>
        ///Unique OpenFlights identifier for source airport (see Airport)
        ///</summary>
        public int SourceAirportId { get; set; }
        ///<summary>
        ///3-letter (IATA) or 4-letter (ICAO) code of the destination airport.
        ///</summary>
        public string DestinationAirport { get; set; }
        ///<summary>
        ///Unique OpenFlights identifier for destination airport (see Airport)
        ///</summary>
        public int DestinationAirportId { get; set; }
        ///<summary>
        ///Y if this flight is a codeshare (that is, not operated by Airline, but another carrier), empty otherwise.
        ///</summary>
        public string CodeShare { get; set; }
        ///<summary>
        ///Number of stops on this flight (0 for direct)
        ///</summary>
        public string Stops { get; set; }
        ///<summary>
        ///3-letter codes for plane type(s) generally used on this flight, separated by spaces
        ///</summary>
        public string Equipment { get; set; }
    }

    [FileCache(CacheKey = "Routes", FileName = "routes.dat", Uri = "https://raw.githubusercontent.com/jpatokal/openflights/master/data/routes.dat")]
    public class RoutesList : List<Route>
    {

    }
}
