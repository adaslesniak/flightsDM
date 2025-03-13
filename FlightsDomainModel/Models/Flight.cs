using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightsDomainModel;

/// <summary>
/// Describes flight, a plane that flies from A to B at given time
/// </summary>
public class Flight {
    FlightDto _data;
    public string Id => _data.Id;
    public DateTime TakeOff => _data.TakeOff;
    public TimeSpan Duration => _data.Duration;
    public IAirlane Airline { get; }
    public Airport From { get; }
    public Airport Destination { get; }

    private Flight(FlightDto dto, Data context) {
        _data = dto;
        Airline = context.Airlanes.WithId(dto.AirlineId)!; 
        From = context.Airports.WithId(dto.SourceAirportId)!;
        Destination = context.Airports.WithId(dto.DestinationAirportId)!;
    }

    //just for tests - maybe we could live without it
    public Flight(string id, DateTime takeoff, TimeSpan duration, IAirlane airline, Airport from, Airport destination) {
        _data = new FlightDto { Id = id, TakeOff = takeoff, Duration = duration, AirlineId = airline.Id, SourceAirportId = from.Id, DestinationAirportId = destination.Id };    
        Airline = airline;
        From = from;
        Destination = destination;
    }
}

public class FlightDto {
    public string Id { get; set; } = string.Empty;
    public DateTime TakeOff { get; set; }
    public TimeSpan Duration { get; set; }
    public string AirlineId { get; set; } = string.Empty;
    public int SourceAirportId { get; set; }
    public int DestinationAirportId { get; set; }
}
