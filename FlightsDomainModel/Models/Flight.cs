namespace FlightsDomainModel;

public class Flight {
    MutableFlight _data;

    public Offer Details => _data.Details!;
    public Tenant Owner => _data.Owner!;
    public int FinalPrice => _data.FinalPrice;
    public IEnumerable<IDiscount> AppliedDisconuts => _data.AppliedDisconuts!;

    private Flight(MutableFlight dto) {
        _data = dto;
    }

}

//used for serialization, would use whatever dto comes from data repository
internal class MutableFlight {
    public Offer? Details { get; set; }
    public Tenant? Owner { get; set; }
    public int FinalPrice { get; set; }
    public IEnumerable<IDiscount>? AppliedDisconuts { get; set; }
}
