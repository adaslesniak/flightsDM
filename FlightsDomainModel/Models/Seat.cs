namespace FlightsDomainModel;

/// <summary>
/// Represents a single seat on a plane.
/// Purchasable item.
/// </summary>
public class Seat {
    readonly SeatDto _data;

    public int Id => _data.Id;
    public bool IsAvailable => !_data.IsSold;
    public Flight Flight { get; }
    
    public int BasePriceInCents => _data.BasePriceInCents!;
    public int MinPriceInCents => _data.MinPriceInCents!;
    public IEnumerable<Guid> AllowedDiscounts => _data.AllowedDiscounts!;
    public IAirlane Provider => Flight.Airline;
    public Airport From => Flight.From;
    public Airport Destination => Flight.Destination;
   
    private Seat(SeatDto dto, Data context) { 
        _data = dto;
        Flight = context.Flights.WithId(dto.FlightId)!;
    }

    public void MarkSold() =>
        _data.IsSold = true;
}

//for serialization purposes, that would depend on storage type
internal class SeatDto {
    public int Id { get; set; }
    public bool IsSold { get; set; }
    public string FlightId { get; set; } = string.Empty;
    public int BasePriceInCents { get; set; }
    public int MinPriceInCents { get; set; }
    public List<Guid>? AllowedDiscounts { get; set; }
}


