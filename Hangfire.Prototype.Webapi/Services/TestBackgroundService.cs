namespace Hangfire.Prototype.Webapi.Services;

public class TestBackgroundService : ITestBackgroundService
{
    public void Send(string message)
    {               
        Console.WriteLine($"started: {message} (added 15 second delay)" );
        Task.Delay(15000).Wait();
        Console.WriteLine($"completed");
    }
}
