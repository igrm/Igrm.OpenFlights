using Igrm.OpenFlights.Interfaces;
using Igrm.OpenFlights.Models;
using Microsoft.Extensions.Caching.Memory;

namespace Igrm.OpenFlights.Implementations
{
    public class RouteRepository: RepositoryBase<RoutesList, Route>, IRouteRepository
    {
        public RouteRepository(IDataFileLoader loader, IMemoryCache memoryCache) : base(loader, memoryCache)
        {
                
        }
    }
}
