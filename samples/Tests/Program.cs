using Tests;

var builder = WebApplication.CreateBuilder(args);


static async Task HelloMiddleware(HttpContext httpContext, RequestDelegate next)
{
    await httpContext.Response.WriteAsync("Hello, ");
    await next(httpContext);
};
static Task WorldMiddleware(HttpContext httpContext, RequestDelegate next) => httpContext.Response.WriteAsync("World!");


// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//×Ô¶¯×¢Èë
builder.Services.AutoServiceCollection<WebModule>()
    .AutoModuleServiceCollection<TestModule>()
    .AddService();

var app = builder.Build();

app
    .Use(middleware: HelloMiddleware)
    .Use(middleware: WorldMiddleware);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();