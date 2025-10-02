using main.DTOs;
using RabbitMQ.Client;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapPost("/users", (string name, string surname) =>
{
    Guid id = Guid.NewGuid();
    // TODO: add user implementation
    return Results.Created("/users/{id}", new UserCreatedResponse(id, name, surname));
});

app.MapGet("/users/{id:guid}", (Guid id) =>
{
    return Results.Ok(new UserGetResponse());
});

app.Run();
