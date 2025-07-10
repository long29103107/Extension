namespace Extensions;

public static class ExceptionExtensions
{
    public static T ExecuteWithRetry<T>(Func<T> operation, int maxRetries = 3, int delayMs = 1000)
    {
        var retryCount = 0;
        
        while (retryCount < maxRetries)
        {
            try
            {
                return operation();
            }
            catch (Exception ex) when (retryCount < maxRetries - 1)
            {
                retryCount++;
                Thread.Sleep(delayMs * retryCount); // Exponential backoff
            }
        }
        
        return operation(); // Final attempt without catching exception
    }
    
    public static async Task<T> ExecuteWithRetryAsync<T>(Func<Task<T>> operation, int maxRetries = 3, int delayMs = 1000)
    {
        var retryCount = 0;
        
        while (retryCount < maxRetries)
        {
            try
            {
                return await operation();
            }
            catch (Exception ex) when (retryCount < maxRetries - 1)
            {
                retryCount++;
                await Task.Delay(delayMs * retryCount); // Exponential backoff
            }
        }
        
        return await operation(); // Final attempt without catching exception
    }
    
    public static void SwallowExceptions(Action action)
    {
        try
        {
            action();
        }
        catch
        {
            // Intentionally swallow all exceptions
        }
    }
}