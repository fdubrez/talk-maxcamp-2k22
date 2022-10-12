var builder = WebApplication.CreateBuilder(args);

// add services to DI container
{
    var services = builder.Services;
    services.AddControllers();
}

var app = builder.Build();

// configure HTTP request pipeline
{
    app.MapControllers();
}

int port = !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("PORT")) ? int.Parse(Environment.GetEnvironmentVariable("PORT")) : 8080;
app.Run($"http://*:{port}");
