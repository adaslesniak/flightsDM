using System.Diagnostics.CodeAnalysis;
namespace FlightsDomainModel;

public class KnownAirports : SetOfModels<Airport> {

    public Airport? WithId(int withId) =>
        _models.FirstOrDefault(apr => apr.Id == withId);
}


