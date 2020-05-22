using Igrm.OpenFlights.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Igrm.OpenFlights.Implementations
{
    public class CacheStrategyBase<T> : ICacheStrategy<T> where T : class
    {
        protected readonly IMemoryCache _memoryCache;
        protected readonly MemoryCacheEntryOptions _memoryCacheEntryOptions;

        public CacheStrategyBase(IMemoryCache memoryCache, MemoryCacheEntryOptions memoryCacheEntryOptions)
        {
            _memoryCache = memoryCache;
            _memoryCacheEntryOptions = memoryCacheEntryOptions;
        }

        public Task<T> ExecuteGetAsync(string key)
        {
            return Task.Run(() => _memoryCache.Get(key) as T);

        }

        public Task ExecuteSetAsyn(T value, string key)
        {
            return Task.Run(()=>_memoryCache.Set<T>(key, value, _memoryCacheEntryOptions));    
        }
    }
}
