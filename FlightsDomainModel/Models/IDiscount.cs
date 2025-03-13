namespace FlightsDomainModel;

public interface IDiscount {
    int Id { get; }
    int ValueInCents { get; }
    string Description { get; }
    bool CanBeApplied(Tenant tenant, Seat offer);
}
