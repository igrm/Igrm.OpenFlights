using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Igrm.OpenFlights.Constants;
using Igrm.OpenFlights.Helpers;
using Igrm.OpenFlights.Interfaces;
using System.Linq;

namespace Igrm.OpenFlights.Implementations
{
    public class RepositoryBase<T, U> : IRepositoryBase<T, U> where T: List<U>, new() where U: class, new()
    {
        private readonly ICache<T> _cache;
        private readonly IDataFileLoader _dataFileLoader;

        public RepositoryBase(IDataFileLoader dataFileLoader)
        {
            _cache = new CacheBase<T>(new MemoryCacheStrategy<T>(OpenFligthsConstants.EXPIRY_MINUTES, dataFileLoader));
            _dataFileLoader = dataFileLoader;
        }

        public async Task<T> FindAllAsync()
        {
            T result = await _cache.GetAsync();
            if(result == null)
            {
                var list = _dataFileLoader.ReadFile(GeneralHelper.GetAttributeData<T>().fileName);
                result = new T();
                result.AddRange(Convert(list));
                await _cache.SetAsync(result);
            }
            return result;
        }

        public async Task<T> FindByConditionAsync(Func<U, bool> expression)
        {
            T result = await FindAllAsync();
            return result.Where(expression).ToList() as T;
        }

        private List<U> Convert(List<string[]> list)
        {
            return list.Select(x => GeneralHelper.Create<U>(x)).ToList();
        }

        public void Dispose()
        {
            _cache.Dispose();
        }
    }
}
