using System.Diagnostics.CodeAnalysis;

namespace FlightsDomainModel;

/// <summary>
/// this is just a sketch to be replaced by access to real data
/// </summary>
/// <typeparam name="T"></typeparam>
public class SetOfModels<T>
{
    protected readonly List<T> _models = new();

    protected bool FindAny(Func<T, bool> pattern, [MaybeNullWhen(false)] out T found) {
        found = _models.FirstOrDefault(pattern);
        return found != null;
    }

    protected bool FindAll(Func<T, bool> pattern, [MaybeNullWhen(false)] out List<T> found) {
        found = _models.Where(pattern).ToList();
        return found != null && found.Count > 0;
    }

    protected bool Add(T newRecord) {
        if(newRecord is null) {
            Log.Error("Trying to add null record");
            return false;
        }
        if(_models.Any(registred => registred!.Equals(newRecord))) {
            Log.Error("Trying to duplicate existing record");
            return false;
        }
        _models.Add(newRecord);
        return true;
    }

    public bool Initialize(IEnumerable<T> withRange) {
        if(_models.Count != 0) {
            Log.Error("Set already initialized");
            return false;
        }
        _models.AddRange(withRange);
        return true;
    }
}