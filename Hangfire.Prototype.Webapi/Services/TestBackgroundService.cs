namespace Hangfire.Prototype.Webapi.Services;

public class TestBackgroundService : ITestBackgroundService
{
    public void Send(string message)
    {
        Console.WriteLine(message);
    }
}
