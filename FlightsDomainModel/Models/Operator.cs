namespace FlightsDomainModel;

public class Operator
{
    readonly MutableOperator _data;

    public string Id => _data.Id!;
    public string FullName => _data.FullName!;
   
    private Operator(MutableOperator dto) {
        _data = dto;
    }
}

public class MutableOperator
{
    public string? Id { get; set; }
    public string? FullName { get; set; }
}