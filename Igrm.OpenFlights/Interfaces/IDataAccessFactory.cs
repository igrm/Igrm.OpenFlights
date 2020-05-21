namespace Igrm.OpenFlights.Interfaces
{
    public interface IDataAccessFactory
    {
        IAirlineRepository CreateAirlineRepository();
        IAircraftRepository CreateAircraftRepository();
        IRouteRepository CreateRouteRepository();
        IAirportRepository CreateAirportRepository();
    }
}
