using Igrm.OpenFlights.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Igrm.OpenFlights.Models
{
    public class Aircraft
    {
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
