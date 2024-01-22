using Hangfire;
using Hangfire.Prototype.Webapi.Services;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

var builder = WebApplication.CreateBuilder(args);

// Connection strings
var hangfireConnectionString = builder.Configuration.GetConnectionString("HangireConnection");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ITestBackgroundService, TestBackgroundService>();    

// Hangfire Client
builder.Services.AddHangfire(configuration =>configuration
    .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
    .UseSimpleAssemblyNameTypeSerializer()
    .UseRecommendedSerializerSettings()
    .UseSqlServerStorage(hangfireConnectionString));

// Hangfire Server
builder.Services.AddHangfireServer();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.UseHangfireDashboard();
app.MapHangfireDashboard("/hangfire");

app.Run();
