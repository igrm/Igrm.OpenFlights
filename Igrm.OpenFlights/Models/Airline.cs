using Igrm.OpenFlights.Attributes;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Igrm.OpenFlights.Models
{
    public class Airline
    {
        ///<summary>
        ///Unique OpenFlights identifier for this airline.
        ///</summary>
        public uint AirlineId { get; set; }
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

        public static explicit operator Airline(string[] array)
        {
            Airline airline = new Airline();
            int position = 0;

            Type airlineType = typeof(Airline);

            foreach (var item in array)
            {
                PropertyInfo pi = airlineType.GetProperties()[position];
                if (item != null)
                {
                    if (pi.PropertyType.Name == "Decimal")
                        pi.SetValue(airline, Convert.ToDecimal(item));
                    else
                        pi.SetValue(airline, item);
                }
                position++;
            }

            return airline;
        }

    }

    [FileCache(CacheKey ="Airlines", FileName = "airlines.dat", Uri = "https://raw.githubusercontent.com/jpatokal/openflights/master/data/airlines.dat")]
    public class AirlineList:List<Airline>
    {

    }
}
