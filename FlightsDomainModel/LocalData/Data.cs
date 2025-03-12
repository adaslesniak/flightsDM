namespace FlightsDomainModel;

public class Data {

    /// <summary>
    /// simple dataset, rarely changing, in whole cached 
    /// </summary>
    public KnownAirports Airports { get; } = new();
    /// <summary>
    /// a wrapper to call directly to airlane service, those can change from second to second, so no need to even cache that
    /// but locally we probably need to store seats that are in basked, bought, etc
    /// </summary>
    public SeatsService Offer { get; } = new();
    /// <summary>
    /// our local data, shouldn't change too much... could be cached - biggest consideradion is data privacy
    /// </summary>
    public RegistredPassangers Passangers { get; } = new();
    /// <summary>
    /// list of flights - changed from time to time, but not by seconds, so caching it makes a lot of sense, but refreshing regularly is a must
    /// </summary>
    public ServedFlights Flights { get; } = new();
    /// <summary>
    /// Not sure if we should keep it here - data privacy is most important consideration when working with this
    /// </summary>
    public SoldTickets Purchased { get; } = new();
    /// <summary>
    /// totally local and it's hardcoded, as each airlane must be implemented by different api to their services
    /// </summary>
    public PartnerAirlanes Airlanes { get; } = new();
    /// <summary>
    /// totally local and at least at the start it must be implemented by programmers, later a system of data defined rules can be implemented
    /// </summary>
    public ExistingDiscounts Discounts { get; } = new();
}
