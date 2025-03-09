using static FlightsDomainModel.Tenant;

namespace FlightsDomainModel;

//TODO: there should be more details, like first name, last name, how to call him (mr, miss, ms) and probably few more

public class Tenant {
    public enum Kind { A, B }
    readonly MutableTenant _data;

    public int Id => _data.Id;
    public DateTime BirthDay => _data.BirthDay;
    public Kind Category => _data.Category;

    private Tenant(MutableTenant dto) {
        _data = dto;
    }
}

internal class MutableTenant {
    public int Id { get; set; }
    public DateTime BirthDay { get; set; }
    public Kind Category { get; set; }
}