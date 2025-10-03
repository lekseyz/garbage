using main.Configurations;
using RabbitMQ.Client;

namespace main.Extensions;

public static class RabbitExtensions
{
    public static async Task AddRabbitMq(this IServiceCollection services, WebApplicationBuilder builder)
    {
        var configuration =  builder.Configuration.GetSection("RabbitMQOptions").Get<RabbitMQOptions>();
        
        var factory = new ConnectionFactory
        {
            HostName = configuration.Host,
            UserName = configuration.Username,
            Password = configuration.Password,
            Port = configuration.Port
        };
        var connection = await factory.CreateConnectionAsync();
        
        services.AddSingleton<IConnection>(_ => connection);
    }
}