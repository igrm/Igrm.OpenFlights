using Igrm.OpenFlights.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Igrm.OpenFlights.Models
{
    public class Airport
    {
        ///<summary>
        ///Unique OpenFlights identifier for this airport.
        ///</summary>
        public uint AirportId { get; set; }
        ///<summary>
        ///Name of airport. May or may not contain the City name.
        ///</summary>
        public string Name { get; set; }
        ///<summary>
        ///Main city served by airport. May be spelled differently from Name.
        ///</summary>
        public string City { get; set; }
        ///<summary>
        ///Country or territory where airport is located. See countries.dat to cross-reference to ISO 3166-1 codes.
        ///</summary>
        public string Country { get; set; }
        ///<summary>
        ///3-letter IATA code. Null if not assigned/unknown.
        ///</summary>
        public string Iata { get; set; }
        ///<summary>
        ///4-letter ICAO code.Null if not assigned.
        ///</summary>
        public string Icao { get; set; }
        ///<summary>
        ///Decimal degrees, usually to six significant digits. Negative is South, positive is North.
        ///</summary>
        public decimal Latitude { get; set; }
        ///<summary>
        ///Decimal degrees, usually to six significant digits. Negative is West, positive is East.
        ///</summary>
        public decimal Longitude { get; set; }
        ///<summary>
        ///In feet.
        ///</summary>
        public decimal Altitude { get; set; }
        ///<summary>
        ///Hours offset from UTC. Fractional hours are expressed as decimals, eg. India is 5.5.
        ///</summary>
        public decimal Timezone { get; set; }
        ///<summary>
        ///Daylight savings time. One of E (Europe), A (US/Canada), S (South America), O (Australia), Z (New Zealand), N (None) or U (Unknown). See also: Help: Time
        ///</summary>
        public string Dst { get; set; }
        ///<summary>
        ///Timezone in tz (Olson) format, eg. America/Los_Angeles.
        ///</summary>
        public string TzDatabaseTimezone { get; set; }
        ///<summary>
        ///Type of the airport. Value airport for air terminals, station for train stations, port for ferry terminals and unknown if not known. In airports.csv, only type=airport is included.
        ///</summary>
        public string Type { get; set; }
        ///<summary>
        ///Source of this data. OurAirports for data sourced from OurAirports, Legacy for old data not matched to OurAirports (mostly DAFIF), User for unverified user contributions. In airports.csv, only source=OurAirports is included.
        ///</summary>
        public string Source { get; set; }

    }

    [FileCache(CacheKey = "Airports", FileName = "airports.dat", Uri = "https://raw.githubusercontent.com/jpatokal/openflights/master/data/airports.dat")]
    public class AirportsList : List<Airport>
    {

    }
}
