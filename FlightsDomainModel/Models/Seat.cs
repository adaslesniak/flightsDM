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
    public IEnumerable<IDiscount> AllowedDiscounts { get; }
    
    public int BasePriceInCents => _data.BasePriceInCents!;
    public int MinPriceInCents => _data.MinPriceInCents!;
    public IAirlane Provider => Flight.Airline;
    public Airport From => Flight.From;
    public Airport Destination => Flight.Destination;
   
    private Seat(SeatDto dto, Data context) { 
        _data = dto;
        Flight = context.Flights.WithId(dto.FlightId)!;
    }

    public Seat(int id, Flight flight, int basePrice, int minPrice, params IDiscount[] allowedDiscounts) {
        _data = new() {
            FlightId = flight.Id,
            Id = id,
            IsSold = false,
            MinPriceInCents = minPrice,
            BasePriceInCents = basePrice,
            AllowedDiscounts = allowedDiscounts.Select(d => d.Id).ToList()
        };
        AllowedDiscounts = allowedDiscounts;
        Flight = flight;
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
    public List<int>? AllowedDiscounts { get; set; }
}


