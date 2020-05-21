using Igrm.OpenFlights.Interfaces;
using Igrm.OpenFlights.Models;

namespace Igrm.OpenFlights.Implementations
{
    public class RouteRepository: RepositoryBase<RoutesList, Route>, IRouteRepository
    {
        public RouteRepository(IDataFileLoader loader) : base(loader)
        {
                
        }
    }
}
