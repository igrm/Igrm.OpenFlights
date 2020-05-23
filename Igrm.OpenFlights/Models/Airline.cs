using Igrm.OpenFlights.Attributes;
using System;
using System.Collections.Generic;

namespace Igrm.OpenFlights.Models
{
    public class Airline
    {
        public Airline()
        {
            Name = String.Empty;
            Alias = String.Empty;
            Iata = String.Empty;
            Icao = String.Empty;
            CallSign = String.Empty;
            Country = String.Empty;
            Active = String.Empty;
        }
        ///<summary>
        ///Unique OpenFlights identifier for this airline.
        ///</summary>
        public int AirlineId { get; set; }
        ///<summary>
        ///Name of the airline.
        ///</summary>
        public string Name { get; set; }
        ///<summary>
        ///Alias of the airline. For example, All Nippon Airways is commonly known as ANA.
        ///</summary>
        public string Alias { get; set; }
        ///<summary>
        ///2-letter IATA code, if available.
        ///</summary>
        public string Iata { get; set; }
        ///<summary>
        ///3-letter ICAO code, if available.
        ///</summary>
        public string Icao { get; set; }
        ///<summary>
        ///Airline callsign.
        ///</summary>
        public string CallSign { get; set; }
        ///<summary>
        ///Country or territory where airline is incorporated.
        ///</summary>
        public string Country { get; set; }
        ///<summary>
        ///Y if the airline is or has until recently been operational, N if it is defunct. This field is not reliable: in particular, major airlines that stopped flying long ago, but have not had their IATA code reassigned (eg. Ansett/AN), will incorrectly show as Y.
        ///</summary>
        public string Active { get; set; }

    }

    [FileCache(CacheKey ="Airlines", FileName = "airlines.dat", Uri = "https://raw.githubusercontent.com/jpatokal/openflights/master/data/airlines.dat")]
    public class AirlineList:List<Airline>
    {

    }
}
