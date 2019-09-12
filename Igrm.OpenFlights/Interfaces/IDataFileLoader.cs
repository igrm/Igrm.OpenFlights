using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Igrm.OpenFlights.Interfaces
{
    public interface IDataFileLoader
    {
        bool FileExists(string name);
        Task LoadFileAsync<T>(bool overwrite=false);
        Task LoadAllFilesAsync(bool overwrite = false);
        List<string[]> ReadFile(string name);
    }
}
