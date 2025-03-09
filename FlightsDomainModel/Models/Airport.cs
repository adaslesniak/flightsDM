namespace FlightsDomainModel;

/// <summary>
/// I could use string, but in future more details can be needeed
/// </summary>
public class Airport {
    readonly MutableAirport _data;

    public string Name => _data.Name!;
    public string Country => _data.Country!;
    public string Continent => _data.Continent!;

    private Airport(MutableAirport dto) {
        _data = dto;
    }
}

public class MutableAirport {
    public string? Name { get; set; }
    public string? Country { get; set; }
    public string? Continent { get; set; }
}
