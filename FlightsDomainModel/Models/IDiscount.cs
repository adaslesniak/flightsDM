namespace FlightsDomainModel;

public interface IDiscount {
    Guid Id { get; }
    int ValueInCents { get; }
    string Description { get; }
    bool CanBeApplied(Tenant tenant, Offer offer);
}
