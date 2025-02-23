using System.Text;
using RabbitMQ.Client;

namespace Weather_service.Data.Configs.RabbitMQ_config;

public class RabbitMqService
{
    private readonly IConnection _connection;
    private readonly IModel _channel;

    public RabbitMqService()
    {
        var factory = new ConnectionFactory()
        {
            HostName = "localhost",
            Port = 5672,
            UserName = "guest",
            Password = "guest"
        };

        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();
    }
    
    public void SendMessage(string queueName, string message)
    {
        _channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
            
        var body = Encoding.UTF8.GetBytes(message);
        _channel.BasicPublish("", queueName, null, body);

        Console.WriteLine($"[✔] Sent message to '{queueName}': {message}");
    }
    
    public void SendJsonMessage(string queueName, object data)
    {
        string message = System.Text.Json.JsonSerializer.Serialize(data);
        SendMessage(queueName, message);
    }
}