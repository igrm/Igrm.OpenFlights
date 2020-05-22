using Igrm.OpenFlights.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Igrm.OpenFlights.Implementations
{
    public class MemoryCacheStrategy<T> : CacheStrategyBase<T> where T : class
    {
        private readonly PostEvictionDelegate _postEvictionDelegate;
        private readonly IDataFileLoader _dataFileLoader;

        public MemoryCacheStrategy(IMemoryCache memoryCache, MemoryCacheEntryOptions memoryCacheEntryOptions):base(memoryCache, memoryCacheEntryOptions)
        {
        }

        public MemoryCacheStrategy(int cacheExpirationMinutes, IDataFileLoader dataFileLoader, IMemoryCache memoryCache) :this(memoryCache,new MemoryCacheEntryOptions())
        {
            _memoryCacheEntryOptions.AbsoluteExpirationRelativeToNow = new TimeSpan(hours:0,minutes: cacheExpirationMinutes, seconds:0);
            _dataFileLoader = dataFileLoader;
            _postEvictionDelegate = new PostEvictionDelegate((key, value, reason, state) => {
                if(reason==EvictionReason.Expired)
                    _dataFileLoader.LoadFileAsync<T>(overwrite:true);
            });
            _memoryCacheEntryOptions.RegisterPostEvictionCallback(_postEvictionDelegate);
        }
    }
}
