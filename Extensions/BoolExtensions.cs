namespace Extensions;

public static class BoolExtensions
{
    public static int ToInt(this bool value) => value ? 1 : 0;
    public static string ToYesNo(this bool value) => value ? "Yes" : "No";
    public static T Choose<T>(this bool condition, T whenTrue, T whenFalse)
        => condition ? whenTrue : whenFalse;
    public static void IfTrue(this bool condition, Action action)
    { if (condition) action(); }
    public static bool Not(this bool value) => !value;
}
