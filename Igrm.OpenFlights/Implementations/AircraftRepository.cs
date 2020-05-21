using Igrm.OpenFlights.Interfaces;
using Igrm.OpenFlights.Models;

namespace Igrm.OpenFlights.Implementations
{
    public class AircraftRepository: RepositoryBase<AircraftsList, Aircraft>, IAircraftRepository
    {
        public AircraftRepository(IDataFileLoader loader) : base(loader)
        {
                
        }
    }
}
