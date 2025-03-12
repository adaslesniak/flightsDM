namespace FlightsDomainModel;

public class PartnerAirlanes : SetOfModels<IAirlane> {

    public IAirlane? WithId(string id) =>
        _models.FirstOrDefault(aln => aln.Id == id);
}
