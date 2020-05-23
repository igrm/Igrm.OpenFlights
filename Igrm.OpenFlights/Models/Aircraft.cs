using Igrm.OpenFlights.Attributes;
using System;
using System.Collections.Generic;

namespace Igrm.OpenFlights.Models
{
    public class Aircraft
    {
        public Aircraft()
        {
            Name = String.Empty;
            Iata = String.Empty;
            Icao = String.Empty;
        }
        /// <summary>
        /// Full name of the aircraft.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// IATA code 	
        /// </summary>
        public string Iata 	 { get; set; }

        /// <summary>
        /// ICAO code 	
        /// </summary>
        public string Icao 	 { get; set; }
    }

    [FileCache(CacheKey="Planes", FileName ="planes.dat", Uri = "https://raw.githubusercontent.com/jpatokal/openflights/master/data/planes.dat")]
    public class AircraftsList: List<Aircraft>
    {

    }
}
