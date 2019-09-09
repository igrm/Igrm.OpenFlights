using System;
using System.Collections.Generic;
using System.Text;

namespace Igrm.OpenFlights.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CacheAttribute : Attribute
    {
        public string Filename { get; set; }
        public string Uri { get; set; }

        public int CacheKey { get; set; }
    }
}
