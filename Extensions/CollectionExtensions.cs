namespace Extensions;

public static class CollectionExtensions
{
    public static bool IsNullOrEmpty<T>(this IEnumerable<T> collection)
    {
        return collection == null || !collection.Any();
    }
    
    public static bool HasItems<T>(this IEnumerable<T> collection)
    {
        return collection != null && collection.Any();
    }
    
    public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
    {
        if (collection == null || action == null) return;
        
        foreach (var item in collection)
        {
            action(item);
        }
    }
    
    public static IEnumerable<T> WhereNotNull<T>(this IEnumerable<T> collection) where T : class
    {
        return collection?.Where(item => item != null) ?? Enumerable.Empty<T>();
    }
    
    public static List<T> ToSafeList<T>(this IEnumerable<T> collection)
    {
        return collection?.ToList() ?? new List<T>();
    }
}