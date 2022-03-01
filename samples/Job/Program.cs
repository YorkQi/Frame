var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScheduler();

var app = builder.Build();

app.SchedulerStart();

app.Run();
