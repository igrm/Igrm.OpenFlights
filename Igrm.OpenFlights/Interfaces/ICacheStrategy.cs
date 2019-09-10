using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Igrm.OpenFlights.Interfaces
{
    public interface ICacheStrategy<T>: IDisposable
    {
        Task<T> ExecuteGetAsync(string key);
        Task ExecuteSetAsyn(T value, string key);
    }
}
