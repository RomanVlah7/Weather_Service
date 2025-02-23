using Weather_service.Data.Configs.RabbitMQ_config;

namespace Message_service.Sercvice;

public class RabbitMqService
{
    private readonly RabbitMqConsumer _rabbitMqConsumer;

    public RabbitMqService(RabbitMqConsumer rabbitMqConsumer)
    {
        _rabbitMqConsumer = rabbitMqConsumer;
    }

    public void StartListeningRabbitMq()
    {
        _rabbitMqConsumer.StartListening(RabbitMqTopics.UserTopic);
    }
}