using RabbitMQ.Client;

namespace main.Extensions;

public static class RabbitExtensions
{
    public async static Task AddRabbitMQ(this IServiceCollection services, IConfiguration configuration)
    {
        var factory = new ConnectionFactory
        {
            HostName = configuration["RABBITMQ:HOST"],
            UserName = configuration["RABBITMQ:USERNAME"],
            Password = configuration["RABBITMQ:PASSWORD"],
            Port = int.Parse(configuration["RABBITMQ:PORT"])
        };
        var connection = await factory.CreateConnectionAsync();
        
        services.AddSingleton<IConnection>(connection);
    }
}