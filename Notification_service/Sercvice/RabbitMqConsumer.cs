
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Message_service.Sercvice;

public class RabbitMqConsumer
{
    private readonly IConnection _connection;
    private readonly IModel _channel;

    public RabbitMqConsumer()
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

    public void StartListening(string queueName)
    {
        _channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

        var consumer = new EventingBasicConsumer(_channel);
        consumer.Received += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            Console.WriteLine($"Was received message: '{queueName}': {message}");
        };

        _channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);
        Console.WriteLine($"Consumer is listening  '{queueName}'...");
    }
}
