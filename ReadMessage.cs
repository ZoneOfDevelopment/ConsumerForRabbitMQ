using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace ConsumerForRabbitMQ
{
    internal static class ReadMessage
    {
        public static void Start(IModel channel, string queueName)
        {
            // connect to the queue
            channel.QueueDeclare(queueName,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            // Consumer definition
            var consumer = new EventingBasicConsumer(channel);

            // Definition of event when the Consumer gets a message
            consumer.Received += (sender, e) => {
                ManageMessage(e);
            };

            // Start pushing messages to our consumer
            channel.BasicConsume(queueName, true, consumer);

            Console.WriteLine("Consumer is running");
            Console.ReadLine();
        }

        private static void ManageMessage(BasicDeliverEventArgs e)
        {
            // Obviously for this demo, we just print the message...
            var body = e.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            Console.WriteLine(message);
        }
    }
}
