using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publish
{
    public class Publisher
    {
        private static readonly IModel _channel;
        static Publisher()
        {
            var factory = new ConnectionFactory() { HostName = "puffin-01.rmq2.cloudamqp.com", Password = "qmHhSVVnSVyeIAN8hGV-DcRBqJvIjcXt", UserName = "quneisdl", Uri = new Uri("amqps://quneisdl:qmHhSVVnSVyeIAN8hGV-DcRBqJvIjcXt@puffin.rmq2.cloudamqp.com/quneisdl") };
            var connection = factory.CreateConnection();
            _channel = connection.CreateModel();
        }

        public static void Publish(string que, string message)
        {
            _channel.ExchangeDeclare(exchange: "logs", type: "topic");
            _channel.QueueDeclare(queue: que, durable: true, exclusive: false, autoDelete: false, arguments: null);
            var body = Encoding.UTF8.GetBytes(message);

            var properties = _channel.CreateBasicProperties();
            properties.Persistent = true;

            _channel.BasicPublish(exchange: "logs", routingKey: "asd.critical", basicProperties: properties, body: body);
        }
    }
}
