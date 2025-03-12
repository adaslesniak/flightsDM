namespace FlightsDomainModel;

public class SeatsService : SetOfModels<Seat> {

    /// <summary>
    /// this must call directlly to service provider as it must be super up to date
    /// </summary>
    public List<Seat> ForFlight(string flightId) =>
        _models.Where(st => st.Flight.Id == flightId).ToList();

    /// <summary>
    /// this is mostly for stored data, purchased seats - they won't change, so can be stored locally
    /// </summary>
    public Seat? WithId(int id) =>
        _models.FirstOrDefault(st => st.Id == id);
}
