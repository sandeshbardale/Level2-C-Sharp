using System;
using System.Text;
using System.Threading;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace MiniERPRabbitMQ
{
    class Program
    {
        static void Main(string[] args)
        {
            string queueName = "orderQueue";

            // 1. Setup RabbitMQ connection
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            // Declare a queue
            channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

            // 2. Start Consumer in a background thread
            var consumerThread = new Thread(() =>
            {
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine($"[Consumer] Received order: {message}");
                };
                channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);
            });
            consumerThread.Start();

            // 3. Producer: send messages
            Console.WriteLine("Enter order messages to send to RabbitMQ (type 'exit' to quit):");
            while (true)
            {
                string message = Console.ReadLine();
                if (message.ToLower() == "exit") break;

                var body = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish(exchange: "", routingKey: queueName, basicProperties: null, body: body);
                Console.WriteLine($"[Producer] Sent order: {message}");
            }

            Console.WriteLine("Exiting...");
        }
    }
}