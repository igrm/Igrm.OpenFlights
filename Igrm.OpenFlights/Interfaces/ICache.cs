using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Igrm.OpenFlights.Interfaces
{
    public interface ICache<T>:IDisposable
    {
        Task<T> GetAsync();
        Task SetAsync(T value);
    }
}
