using System;
using System.Collections.Generic;
using System.Text;

namespace Igrm.OpenFlights.Helpers
{
    public enum DisposeModeEnum
    {
        DoNothing = 1,
        DisposeMemoryCache = 2,
        DisposeHttpClientAndMemoryCache = 3 
    }
}
