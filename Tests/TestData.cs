using FlightsDomainModel;

namespace Tests;

internal class TestData {

    public Data Prepare() {
        var data = new Data();
        data.Airports.Initialize(MockupAirports);
        data.Passangers.Initialize(MockupTenants);
        data.Discounts.Initialize(MockupDiscounts);
        data.Airlanes.Initialize(MockupAirlines);
        data.Flights.Initialize(MockupFlights);
        data.Offer.Initialize(MockupSeats);
        data.Purchased.Initialize(MockupPurchases());
        return data;
    }

    List<IAirlane>? _mckAirlanes;
    List<IAirlane> MockupAirlines => _mckAirlanes ??= new() {
        new MckAirlane()
    };

    List<IDiscount> _mckDiscounts;
    List<IDiscount> MockupDiscounts => _mckDiscounts ??= new () {
        new AfricaDiscount(),
        new BDayDiscount()
    };

    List<Airport>? _mckAirports;
    List<Airport> MockupAirports => _mckAirports ??= new() {
        MarakeshManera(),
        GdanskAirport(),
        SydneyAirport()
    };

    Airport MarakeshManera() => new Airport(new AirportDto() {
        Id = 1,
        Name = "MAN",
        Country = "MR",
        Continent = "Africa"
    }, new Data());

    Airport GdanskAirport() => new Airport(new AirportDto() {
        Id = 2,
        Name = "GDN",
        Country = "PL",
        Continent = "Europe"
    }, new Data());

    Airport SydneyAirport() => new Airport(new AirportDto() {
        Id = 3,
        Name = "SYD",
        Country = "AU",
        Continent = "Australia"
    }, new Data());


    List<Flight>? _mckFlights;
    List<Flight> MockupFlights => _mckFlights ??= new() {
        new Flight("MCK 12000 CBA", DateTime.Now, TimeSpan.Zero,
            MockupAirlines[0], MarakeshManera(), GdanskAirport()),
        new Flight("MCK 23000 CBA", DateTime.Now, TimeSpan.Zero,
            MockupAirlines[0], GdanskAirport(), SydneyAirport()),
        new Flight("MCK 31000 CBA", DateTime.Now, TimeSpan.Zero,
            MockupAirlines[0], SydneyAirport(), MarakeshManera()),
    };

    List<Seat>? _seats;
    List<Seat> MockupSeats => _seats ??= new() {
        new Seat(1, MockupFlights[0], 29, 20, MockupDiscounts.ToArray()),
        new Seat(2, MockupFlights[1], 33, 20, MockupDiscounts.ToArray()),
        new Seat(3, MockupFlights[2], 36, 20, MockupDiscounts.ToArray())
    };

    List<Tenant>? _mckTenants;
    List<Tenant> MockupTenants => _mckTenants ??= new() {
        new Tenant(new TenantDto() {
            Id = 0,
            BirthDay = DateTime.Now.Date - TimeSpan.FromDays(365.2425 * 25),
            Category = Tenant.Kind.A,
        }, new Data()),
        new Tenant(new TenantDto() {
            Id = 1,
            BirthDay = DateTime.Now,
            Category = Tenant.Kind.B,
        }, new Data()),
    };


    List<Ticket> MockupPurchases() =>
        new List<Ticket>(); 

    public class MckAirlane : IAirlane
    {
        string IAirlane.Id => "MCK";

        string IAirlane.FullName => "MockupAirline";

        string IAirlane.ThreeLetterCode => "MCK";

        bool IAirlane.AreAnySeatsLeft(Seat flight) =>
            true;

        bool IAirlane.Buy(Seat flight) =>
            true;

        IEnumerable<Seat> IAirlane.GetAvailableTickets(Seat flight) => new List<Seat>() {
            //TODO
        };

        bool IAirlane.IsStillAvailable(Seat ticket) =>
            true;

        IEnumerable<Flight> IAirlane.OfferedFlights() => new List<Flight>() {
            //TODO
        };
    }
}
