using main.Configurations;
using RabbitMQ.Client;

namespace main.Extensions;

public static class RabbitExtensions
{
    public static async Task AddRabbitMq(this IServiceCollection services, WebApplicationBuilder builder)
    {
        services.Configure<RabbitMQOptions>(builder.Configuration.GetSection("RabbitMQOptions"));

        await using var serviceProvider = services.BuildServiceProvider();
        var configuration = serviceProvider.GetRequiredService<RabbitMQOptions>();
        var factory = new ConnectionFactory
        {
            HostName = configuration.Host,
            UserName = configuration.Username,
            Password = configuration.Password,
            Port = configuration.Port
        };
        var connection = await factory.CreateConnectionAsync();
        
        services.AddSingleton<IConnection>(connection);
    }
}