using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Igrm.OpenFlights.Interfaces
{
    public interface IRepositoryBase<T, U>:IDisposable
    {
        Task<T> FindAllAsync();
        Task<T> FindByConditionAsync(Func<U, bool> expression);
    }
}
