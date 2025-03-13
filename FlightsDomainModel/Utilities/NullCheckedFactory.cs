using System.Reflection;
namespace FlightsDomainModel;

public static class NullCheckedFactory {
    internal static bool Create<T, MT>(MT dto, Data context, out T? created) {
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
            created = Construct<T, MT>(dto, context);
            if(ContainsNulls(created)) {
                throw new ArgumentNullException("Not all data is there, probably context is missing");
            }
            return true;
        } catch {
            Console.WriteLine($"Wrong use of {nameof(NullCheckedFactory)}, {typeof(T)} doesn't have proper construstor");
            return false;
        }
        
    }

    static T Construct<T, MT>(MT dto, Data data) {
        var ctor = typeof(T).GetConstructor(new Type[] { typeof(MT), typeof(Data) });
        return (T)ctor.Invoke([dto, data]);
    }

    //TODO: check for non nullable fields only
    static bool ContainsNulls<T>(T dto) =>
        typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                   .Any(prop => prop.GetValue(dto) == null);
}
