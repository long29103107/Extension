using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace Extensions;

public static class StringExtensions
{
    public static bool IsNullOrEmpty(this string value)
        => string.IsNullOrEmpty(value);
    
    public static bool IsNotNullOrEmpty(this string value)
        => !string.IsNullOrEmpty(value);

    public static string ToSafeString(this object value) 
        => value?.ToString() ?? string.Empty;

    public static string Truncate(this string value, int maxLength)
         => string.IsNullOrEmpty(value) 
            ? string.Empty 
            : (value.Length <= maxLength 
                ? value 
                : value.Substring(0, maxLength));

    public static bool IsNullOrEmptyOrWhiteSpace(this string value)
        => string.IsNullOrWhiteSpace(value);

    public static int ToSafeInt(this string value, int fallback = 0)
        => int.TryParse(value, out var n) ? n : fallback;
    public static string ToTitleCase(this string value)
        => string.IsNullOrWhiteSpace(value) ? value
           : CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value.ToLower());

    public static string ToSha256(this string value)
    {
        if (value is null) return null;
        using var sha = SHA256.Create();
        var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(value));
        return BitConverter.ToString(bytes).Replace("-", "").ToLowerInvariant();
    }
}