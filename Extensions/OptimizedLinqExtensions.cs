namespace Extensions;

public static class OptimizedLinqExtensions
{
    public static bool AnyFast<T>(this ICollection<T> collection)
    {
        return collection != null && collection.Count > 0;
    }
    
    public static bool AnyFast<T>(this ICollection<T> collection, Func<T, bool> predicate)
    {
        if (collection == null || predicate == null) return false;
        
        foreach (var item in collection)
        {
            if (predicate(item)) return true;
        }
        return false;
    }
    
    public static T FirstOrDefault<T>(this IEnumerable<T> collection, T defaultValue)
    {
        if (collection == null) return defaultValue;
        
        foreach (var item in collection)
        {
            return item;
        }
        return defaultValue;
    }
    
    public static IEnumerable<T> TakeFast<T>(this IEnumerable<T> collection, int count)
    {
        if (collection == null || count <= 0) yield break;
        
        var taken = 0;
        foreach (var item in collection)
        {
            if (taken >= count) yield break;
            yield return item;
            taken++;
        }
    }
}