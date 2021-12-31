using RabbitMQ.Client;

namespace ConsumerForRabbitMQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // definition of Connection 
            var _rabbitMQServer = new ConnectionFactory() { HostName = "localhost", Password = "guest", UserName = "guest" };

            // create connection
            using var connection = _rabbitMQServer.CreateConnection();

            // create channel
            using var channel = connection.CreateModel();

            // Read messages
            ReadMessage.Start(channel, "testRabbitMQ");
        }
    }
}
