﻿using Igrm.OpenFlights.Constants;
using Igrm.OpenFlights.Helpers;
using Igrm.OpenFlights.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Igrm.OpenFlights.Implementations
{
    public class RepositoryBase<T, U> : IRepositoryBase<T, U> where T: List<U>, new() where U: class, new()
    {
        private readonly ICache<T> _cache;
        private readonly IDataFileLoader _dataFileLoader;

        public RepositoryBase(IDataFileLoader dataFileLoader, IMemoryCache memoryCache)
        {
            _cache = new CacheBase<T>(new MemoryCacheStrategy<T>(OpenFligthsConstants.EXPIRY_MINUTES, dataFileLoader, memoryCache));
            _dataFileLoader = dataFileLoader;
        }

        public async Task<T> FindAllAsync()
        {
            T result = await _cache.GetAsync();
            if(result == null)
            {
                var list = await _dataFileLoader.ReadFileAsync(GeneralHelper.GetAttributeData<T>().fileName);
                result = new T();
                result.AddRange(Convert(list));
                await _cache.SetAsync(result);
            }
            return result;
        }

        public async Task<T> FindByConditionAsync(Func<U, bool> expression)
        {
            T result = await FindAllAsync();
            return (T)result.Where(expression).ToList();
        }

        private List<U> Convert(List<string[]> list)
        {
            return list.Select(x => GeneralHelper.Create<U>(x)).ToList();
        }
    }
}
