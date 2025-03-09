using System.Reflection;
namespace FlightsDomainModel;

internal static class NullCheckedFactory
{
    internal static bool Create<T, MT>(MT dto, out T? created) {
        created = default;
        if(dto is null) {
            Log.Error("Can't create object from null dto");
            return false;
        }
        if(ContainsNulls(dto)) {
            Log.Error("Wrong dto, contained nulls");
            return false;
        }
        try {
            created = Construct<T, MT>(dto);
            return true;
        } catch {
            Console.WriteLine($"Wrong use of {nameof(NullCheckedFactory)}, {typeof(T)} doesn't have proper construstor");
            return false;
        }
        
    }

    static T Construct<T, MT>(MT dto) {
        var ctor = typeof(T).GetConstructor(new Type[] { typeof(MT) });
        return (T)ctor.Invoke([dto]);
    }

    static bool ContainsNulls<T>(T dto) {
        return typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                   .All(prop => prop.GetValue(dto) != null);
    }
}
