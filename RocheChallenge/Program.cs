// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using RocheChallenge.DbContexts;
using RocheChallenge.DTOs;

Console.WriteLine("TODO WebAPI started");

#region APP

var builder = WebApplication.CreateBuilder(args);

var connectionString = "Data Source=Todos.db";
builder.Services.AddSqlite<TodoDbContext>(connectionString);

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

app.MapGet("/todos", async (TodoDbContext db) =>
{
    return await db.Todos.ToListAsync();
});

app.MapGet("/todos/{id}", async (TodoDbContext db, int id) =>
{
    return await db.Todos.FindAsync(id) switch
    {
        Todo todo => Results.Ok(todo),
        null => Results.NotFound()
    };
});

app.MapPost("/todos", async (TodoDbContext db, Todo todo) =>
{
    await db.Todos.AddAsync(todo);
    await db.SaveChangesAsync();

    return Results.Created($"/todos/{todo.Id}", todo);
});

app.MapPut("/todos/{id}", async (TodoDbContext db, int id, Todo todo) =>
{
    if (id != todo.Id)
    {
        return Results.BadRequest();
    }

    if (!await db.Todos.AnyAsync(x => x.Id == id))
    {
        return Results.NotFound();
    }

    db.Update(todo);
    await db.SaveChangesAsync();

    return Results.Ok();
});

app.MapDelete("/todos/{id}", async (TodoDbContext db, int id) =>
{
    var todo = await db.Todos.FindAsync(id);
    if (todo is null)
    {
        return Results.NotFound();
    }

    db.Todos.Remove(todo);
    await db.SaveChangesAsync();

    return Results.Ok();
});

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