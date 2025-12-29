namespace Extensions;

public static class IntExtensions
{
    public static int Clamp(this int value, int min, int max)
        => Math.Min(Math.Max(value, min), max);

    public static bool IsBetween(this int value, int minInclusive, int maxInclusive)
        => value >= minInclusive && value <= maxInclusive;

    public static void Times(this int count, Action action)
    { 
        for (var i = 0; i < count; i++) action(); 
    }

    public static bool IsEven(this int value) => (value & 1) == 0;
    public static bool IsOdd(this int value) => (value & 1) == 1;
    public static string ToOrdinal(this int value)
    {
        var rem100 = value % 100;
        var suffix = (rem100 is 11 or 12 or 13) ? "th"
                   : (value % 10) switch { 1 => "st", 2 => "nd", 3 => "rd", _ => "th" };
        return $"{value}{suffix}";
    }

}
