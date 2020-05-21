using Igrm.OpenFlights.Interfaces;
using Igrm.OpenFlights.Models;

namespace Igrm.OpenFlights.Implementations
{
    public class AirportRepository : RepositoryBase<AirportsList, Airport>, IAirportRepository
    {
        public AirportRepository(IDataFileLoader loader) : base(loader)
        {
        }
    }
}
