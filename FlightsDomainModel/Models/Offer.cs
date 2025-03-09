namespace FlightsDomainModel;

public class Offer {
    readonly MutableOffer _data;

    public string FlightId => _data.FlightId!;
    public DateTime TakeOff => _data.TakeOff;
    public TimeSpan Duration => _data.Duration;
    public int BasePriceInCents => _data.BasePriceInCents!;
    public int MinPriceInCents => _data.MinPriceInCents!;
    public IEnumerable<Guid> AllowedDiscounts => _data.AllowedDiscounts!;
    public Operator Provider => _data.Provider!;
    public Airport From => _data.From!;
    public Airport Destination => _data.Destination!;
   
    private Offer(MutableOffer dto) { 
        _data = dto;
    }
}

//for serialization purposes, that would depend on storage type
internal class MutableOffer {
    public string? FlightId { get; set; }
    public DateTime TakeOff { get; set; }
    public TimeSpan Duration { get; set; }
    public int BasePriceInCents { get; set; }
    public int MinPriceInCents { get; set; }
    public List<Guid>? AllowedDiscounts { get; set; }
    public Operator? Provider { get; set; }
    public Airport? From { get; set; }
    public Airport? Destination { get; set; }
}


