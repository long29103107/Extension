namespace Extensions;

public static class DateTimeExtensions
{
    public static bool IsBetween(this DateTime dateTime, DateTime startDate, DateTime endDate)
    {
        return dateTime >= startDate && dateTime <= endDate;
    }
    
    public static DateTime StartOfDay(this DateTime dateTime)
    {
        return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0, dateTime.Kind);
    }
    
    public static DateTime EndOfDay(this DateTime dateTime)
    {
        return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 23, 59, 59, 999, dateTime.Kind);
    }
    
    public static int GetAge(this DateTime birthDate)
    {
        var today = DateTime.Today;
        var age = today.Year - birthDate.Year;
        if (birthDate.Date > today.AddYears(-age)) age--;
        return age;
    }
    
    public static bool IsWeekend(this DateTime dateTime)
    {
        return dateTime.DayOfWeek == DayOfWeek.Saturday || dateTime.DayOfWeek == DayOfWeek.Sunday;
    }
    
    public static DateTime NextBusinessDay(this DateTime dateTime)
    {
        var nextDay = dateTime.AddDays(1);
        while (nextDay.IsWeekend())
        {
            nextDay = nextDay.AddDays(1);
        }
        return nextDay;
    }

    public static long ToUnixTimeSeconds(this DateTime dt)
        => new DateTimeOffset(dt).ToUnixTimeSeconds();
}