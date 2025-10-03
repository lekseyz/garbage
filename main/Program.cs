using main.DTOs;
using main.Extensions;
using main.Logic;
using RabbitMQ.Client;

var builder = WebApplication.CreateBuilder(args);
await builder.Services.AddRabbitMQ(builder.Configuration);
builder.Services.AddScoped<UserService>();

var app = builder.Build();

app.MapPost("/users", async (string name, string surname, UserService userService) =>
{
    Guid id = Guid.NewGuid();
    await userService.CreateUser(name, surname);
    return Results.Created("/users/{id}", new UserCreatedResponse(id, name, surname));
});

app.MapGet("/users/{id:guid}", (Guid id) =>
{
    return Results.Ok(new UserResponse("Aboba", "Abobovic"));
});

app.MapGet("/users/{id:guid}/name", () =>
{
    return Results.Ok(new UserNameResponse("Aboba"));
});

app.MapGet("/users/{id:guid}/surname", () =>
{
    return Results.Ok(new UserNameResponse("Abobovic"));
});

app.Run();
