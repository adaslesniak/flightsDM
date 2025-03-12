namespace FlightsDomainModel;

/// <summary>
/// Represents unfished purchase, an adjustable offer to the user.
/// </summary>
public class PurchaseOffer {
    public Seat Seat { get; init; }
    public Tenant Passanger { get; init; }
    public List<IDiscount> AppliedDiscounts { get; init; }
}