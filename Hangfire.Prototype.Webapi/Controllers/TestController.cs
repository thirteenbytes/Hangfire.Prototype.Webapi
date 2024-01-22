using Hangfire.Prototype.Webapi.Services;
using Hangfire.Storage;
using Microsoft.AspNetCore.Mvc;

namespace Hangfire.Prototype.Webapi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TestController : ControllerBase
{
    private readonly ILogger<TestController> _logger;

    public TestController(ILogger<TestController> logger)
    {
        _logger = logger;
    }

    [HttpGet("EnqueueJob")]
    public string EnqueueJob()
    {

        var jobId = BackgroundJob
            .Enqueue<ITestBackgroundService>(service => service.Send("Background test is running..."));

        return $"jobId {jobId}";

    }

    [HttpGet("GetJobState{jobId}")]
    public string GetJobState(string jobId)
    {
        IStorageConnection connection = JobStorage.Current.GetConnection();
        var jobData = connection.GetJobData(jobId);

        return $"jobId {jobId} = {jobData.State}";
    }
}
