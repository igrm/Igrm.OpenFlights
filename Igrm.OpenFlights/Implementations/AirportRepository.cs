using Igrm.OpenFlights.Interfaces;
using Igrm.OpenFlights.Models;
using Microsoft.Extensions.Caching.Memory;

namespace Igrm.OpenFlights.Implementations
{
    public class AirportRepository : RepositoryBase<AirportsList, Airport>, IAirportRepository
    {
        public AirportRepository(IDataFileLoader loader, IMemoryCache memoryCache) : base(loader, memoryCache)
        {
        }
    }
}
