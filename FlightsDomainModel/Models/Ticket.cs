namespace FlightsDomainModel;

/// <summary>
/// Represents a sold seat.
/// </summary>
public class Ticket {
    TicketDto _data;

    public Seat Details { get; }
    public Tenant Owner { get; }
    public IEnumerable<IDiscount> AppliedDisconuts { get; }
    public int FinalPrice => _data.FinalPrice;

    public Ticket(TicketDto dto, Data context) {
        _data = dto;
        Owner = context.Passangers.WithId(dto.TenantId)!;
        Details = context.Offer.WithId(dto.SeatId)!;
        var usedDiscounts = new List<IDiscount>();
        foreach(var discount in dto.AppliedDisconuts!) {
            usedDiscounts.Add(context.Discounts.WithId(discount)!);
        }
        AppliedDisconuts = usedDiscounts;
    }
}

//used for serialization, would use whatever dto comes from data repository
public class TicketDto {
    public int SeatId { get; set; }
    public int TenantId { get; set; }
    public int FinalPrice { get; set; }
    public int[]? AppliedDisconuts { get; set; }
}
