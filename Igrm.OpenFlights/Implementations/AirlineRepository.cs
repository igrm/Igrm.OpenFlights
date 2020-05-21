using Igrm.OpenFlights.Interfaces;
using Igrm.OpenFlights.Models;

namespace Igrm.OpenFlights.Implementations
{
    public class AirlineRepository: RepositoryBase<AirlineList, Airline>, IAirlineRepository
    {
        public AirlineRepository(IDataFileLoader loader) : base(loader)
        {
                
        }
    }
}
