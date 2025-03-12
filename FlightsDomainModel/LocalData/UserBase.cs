using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightsDomainModel;

public class UserBase : SetOfModels<Tenant> {

    public Tenant WithId(int id) =>
        _models.FirstOrDefault(tnt => tnt.Id == id);
}
