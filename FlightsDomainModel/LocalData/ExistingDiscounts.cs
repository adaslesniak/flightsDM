namespace FlightsDomainModel;

public class ExistingDiscounts : SetOfModels<IDiscount> {

    public List<IDiscount> All() =>
        _models.ToList();

    public IDiscount WithId(int id) =>
        _models.FirstOrDefault(dsc => dsc.Id == id);
}
