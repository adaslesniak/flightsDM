namespace FlightsDomainModel;

public class ServedFlights : SetOfModels<Flight> {
    public List<Flight> All() =>
        _models;

    public Flight? WithId(string id) =>
        _models.FirstOrDefault(fly => fly.Id == id);

    public List<Flight> AtRoute(string from, string destination) =>
        _models.Where(fly => fly.From.Name == from && fly.Destination.Name == destination).ToList();
}
