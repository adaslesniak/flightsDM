namespace FlightsDomainModel;

/// <summary>
/// Describes a point where flights can start or end
/// </summary>
public class Airport {
    readonly AirportDto _data;

    public int Id => _data.Id;
    public string Name => _data.Name!;
    public string Country => _data.Country!;
    public string Continent => _data.Continent!;

    //I hate that being public as it's dangerous and should be used through NullCheckFactory, but... it's pain in the ass to write tests without this
    public Airport(AirportDto dto, Data _) {
        _data = dto;
    }

    public override bool Equals(object? obj) =>
        obj is Airport other
        && other.Id == Id;
}

public class AirportDto {
    public int Id;
    public string? Name { get; set; }
    public string? Country { get; set; }
    public string? Continent { get; set; }
}
