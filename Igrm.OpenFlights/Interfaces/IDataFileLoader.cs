using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Igrm.OpenFlights.Interfaces
{
    public interface IDataFileLoader
    {
        Task<bool> FileExists(string name);
        Task LoadFileAsync<T>();
        Task LoadAllFilesAsync();
    }
}
