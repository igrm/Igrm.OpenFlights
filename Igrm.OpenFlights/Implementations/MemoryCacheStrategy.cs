using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Igrm.OpenFlights.Implementations
{
    public class MemoryCacheStrategy<T> : CacheStrategyBase<T> where T : class
    {
        public MemoryCacheStrategy():base(new MemoryCache(new MemoryCacheOptions()))
        {

        }
    }
}
