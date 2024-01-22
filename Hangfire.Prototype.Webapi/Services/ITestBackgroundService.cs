namespace Hangfire.Prototype.Webapi.Services;

public interface ITestBackgroundService
{
    void Send(string message);
}
