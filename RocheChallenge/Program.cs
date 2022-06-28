// See https://aka.ms/new-console-template for more information

using Microsoft.OpenApi.Models;

Console.WriteLine("TODO WebAPI started");

#region APP

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "TODO WebAPI", Version = "v1" });
});

Host.CreateDefaultBuilder(args).ConfigureLogging((webhostContext, builder) =>
{
    builder.AddConfiguration(webhostContext.Configuration.GetSection("Logging"));
});

var app = builder.Build();

#endregion

#region SWAGGER

app.UseSwagger();
app.UseSwaggerUI();

#endregion

#region MINIMAL API

app.MapGet("/", () => "Hello World!");

#endregion

#region RUN

using (var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
{
    var logger = serviceScope.ServiceProvider.GetService<ILogger<Program>>();
    if (logger != null)
    {
        logger.LogTrace("Trace first log message from application");
    }
    else
    {
        throw new InvalidOperationException("Cannot log anything, logger is null");
    }
}

app.Run();

#endregion