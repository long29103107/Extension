using System.Net.Mail;

namespace Extensions;

public static class ValidationExtensions
{
    public static bool IsValidEmail(this string email)
    {
        if (string.IsNullOrWhiteSpace(email)) return false;
        
        try
        {
            var addr = new MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }
    
    public static bool IsValidPhoneNumber(this string phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(phoneNumber)) return false;
        
        // Remove all non-numeric characters
        var cleaned = new string(phoneNumber.Where(char.IsDigit).ToArray());
        
        // Check if it's between 10-15 digits (international standard)
        return cleaned.Length >= 10 && cleaned.Length <= 15;
    }
    
    public static bool IsInRange(this int value, int min, int max)
    {
        return value >= min && value <= max;
    }
    
    public static bool IsInRange(this decimal value, decimal min, decimal max)
    {
        return value >= min && value <= max;
    }
    
    public static ValidationResult ValidateRequired<T>(this T value, string fieldName) where T : class
    {
        return value != null ? 
            ValidationResult.Success : 
            new ValidationResult($"{fieldName} is required");
    }
}

public class ValidationResult
{
    public bool IsValid { get; }
    public string ErrorMessage { get; }
    
    private ValidationResult(bool isValid, string errorMessage = null)
    {
        IsValid = isValid;
        ErrorMessage = errorMessage;
    }
    
    public static ValidationResult Success => new ValidationResult(true);
    public static ValidationResult Failure(string errorMessage) => new ValidationResult(false, errorMessage);
    
    public ValidationResult(string errorMessage) : this(false, errorMessage) { }
}