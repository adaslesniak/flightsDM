namespace FlightsDomainModel;

public class ExistingDiscounts : SetOfModels<IDiscount> {

    public List<IDiscount> All() =>
        _models.ToList();

    public IDiscount WithId(Guid id) =>
        _models.FirstOrDefault(dsc => dsc.Id == id);
}
