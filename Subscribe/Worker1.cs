using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscribe
{
    public class Worker1 : AbstractWorker
    {
        public Worker1()
            : base("asdf", "*.critical")
        {

        }
        protected override void Implement(IModel channel, BasicDeliverEventArgs ea)
        {
            var body = ea.Body;
            var message = Encoding.UTF8.GetString(body.ToArray());
            Console.WriteLine(" worker1 Received {0}", message);
            System.Threading.Thread.Sleep(10000);
            channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
        }
    }
}
