using System;
using System.Threading.Tasks;
using Igrm.OpenFlights.Helpers;
using Igrm.OpenFlights.Interfaces;

namespace Igrm.OpenFlights.Implementations
{
    public class CacheBase<T> : ICache<T>
    {
        private readonly ICacheStrategy<T> _cacheStrategy;
        public CacheBase(ICacheStrategy<T> cacheStrategy)
        {
            _cacheStrategy = cacheStrategy;
        }

        public Task<T> GetAsync()
        {
            return _cacheStrategy.ExecuteGetAsync(GeneralHelper.GetAttributeData<T>().cacheKey);
        }

        public Task SetAsync(T value)
        {
            return _cacheStrategy.ExecuteSetAsyn(value, GeneralHelper.GetAttributeData<T>().cacheKey);
        }
    }
}
