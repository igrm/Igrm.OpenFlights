using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Igrm.OpenFlights.Interfaces
{
    public interface IDataFileLoader
    {
        Task LoadFileAsync<T>();
        Task LoadAllFilesAsync();
    }
}
