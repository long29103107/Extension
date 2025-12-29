namespace Extensions;

public static class CharExtensions
{
    public static bool IsVowel(this char c)
        => "aeiouAEIOU".IndexOf(c) >= 0;

    public static bool IsConsonant(this char c)
        => char.IsLetter(c) && !"aeiouAEIOU".Contains(c);

    public static char ToUpperFast(this char c)
        => char.ToUpper(c);

    public static bool IsLetterOrDigit(this char c)
        => char.IsLetterOrDigit(c);

    public static string Repeat(this char c, int count)
        => new string(c, count);
}
