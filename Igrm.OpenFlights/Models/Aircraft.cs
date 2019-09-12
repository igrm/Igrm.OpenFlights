using Igrm.OpenFlights.Attributes;
using System;
using System.Collections.Generic;
using System.Reflection;
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

        public static explicit operator Aircraft(string[] array)
        {
            Aircraft aircraft = new Aircraft();
            int position = 0;

            Type aircraftType = typeof(Aircraft);

            foreach (var item in array)
            {
                PropertyInfo pi = aircraftType.GetProperties()[position];
                if (item != null)
                {
                    if (pi.PropertyType.Name == "Decimal")
                        pi.SetValue(aircraft, Convert.ToDecimal(item));
                    else
                        pi.SetValue(aircraft, item);
                }
                position++;
            }

            return aircraft;
        }
    }

    [FileCache(CacheKey="Planes", FileName ="planes.dat", Uri = "https://raw.githubusercontent.com/jpatokal/openflights/master/data/planes.dat")]
    public class AircraftsList: List<Aircraft>
    {

    }
}
