using RabbitMQ.Client;
using System.Text;

namespace main.Logic;

public class UserService
{
    private readonly IConnection _connection;

    public UserService(IConnection connection)
    {
        _connection = connection;
    }

    public async Task CreateUser(string name, string surname)
    {
        var channel = await _connection.CreateChannelAsync();
        await channel.QueueDeclareAsync("name.add", false, false, false);
        await channel.QueueDeclareAsync("surname.add", false, false, false);

        var nameBody = Encoding.UTF8.GetBytes(name);
        var surnameBody = Encoding.UTF8.GetBytes(surname);

        await channel.BasicPublishAsync(string.Empty, "name.add", nameBody);
        await channel.BasicPublishAsync(string.Empty, "surname.add", surnameBody);
    }

    public async Task<string> GetName(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<string> GetSurname(Guid id)
    {
        throw new NotImplementedException();
    }
}