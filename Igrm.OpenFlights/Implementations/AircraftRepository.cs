using Igrm.OpenFlights.Interfaces;
using Igrm.OpenFlights.Models;
using Microsoft.Extensions.Caching.Memory;

namespace Igrm.OpenFlights.Implementations
{
    public class AircraftRepository: RepositoryBase<AircraftsList, Aircraft>, IAircraftRepository
    {
        public AircraftRepository(IDataFileLoader loader, IMemoryCache memoryCache) : base(loader, memoryCache)
        {
                
        }
    }
}
