namespace Extensions;

public static class DecimalExtensions
{
    public static decimal Clamp(this decimal value, decimal min, decimal max)
        => Math.Min(Math.Max(value, min), max);

    public static decimal RoundTo(this decimal value, int digits)
        => Math.Round(value, digits, MidpointRounding.AwayFromZero);

    public static bool IsApproximately(this double value, double other, double tolerance = 0.0001)
        => Math.Abs(value - other) <= tolerance;

    public static decimal PercentOf(this decimal part, decimal whole)
        => whole == 0 ? 0 : (part / whole) * 100;

    public static decimal SafeDivide(this decimal dividend, decimal divisor, decimal fallback = 0)
        => divisor == 0 ? fallback : dividend / divisor;
}
