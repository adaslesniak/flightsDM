using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightsDomainModel;

public class BDayDiscount : IDiscount
{
    int _id = 1;
    int _value = 5;

    int IDiscount.Id =>
        _id;

    int IDiscount.ValueInCents => 
        _value;

    string IDiscount.Description =>
        "Applied on user birthday";

    //TODO: consult busines - does this apply to day of flight, or day of purchase, should we use local time zone, or purchase time zone or flight start time zone
    bool IDiscount.CanBeApplied(Tenant tenant, Seat _) =>
        tenant.BirthDay.DayOfYear == DateTime.Now.DayOfYear;

}
