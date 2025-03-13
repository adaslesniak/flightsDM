namespace FlightsDomainModel;

public interface IAirlane
{
    string Id { get; }
    string FullName { get; }
    string ThreeLetterCode { get; }
    public IEnumerable<Flight> OfferedFlights();
    /// <summary>
    /// Before purchase we must check if given seat wasn't purchesed in meantime
    /// </summary>
    public bool IsStillAvailable(Seat ticket);
    /// <summary>
    /// For queries where we do check if this flight has any seats still available for purchase
    /// </summary>
    public bool AreAnySeatsLeft(Seat flight);
    /// <summary>
    /// To check at the source how many seats are still available on the plane
    /// </summary>
    public IEnumerable<Seat> GetAvailableTickets(Seat flight);
    /// <summary>
    /// However we implement payments between us and airlane
    /// </summary>
    public bool Buy(Seat flight);
}