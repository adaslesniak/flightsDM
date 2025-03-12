using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography.X509Certificates;

namespace FlightsDomainModel;

public class RegistredPassangers : SetOfModels<Tenant> {

    public Tenant? WithId(int id) =>
        _models.FirstOrDefault(tnt => tnt.Id == id);
}
