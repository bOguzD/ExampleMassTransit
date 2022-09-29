using MassTransit;
using Shared;
using System;
using System.Security.Authentication;
using System.Threading.Tasks;

namespace Consumer
{
    public class Message : IMessage
    {
        public string Text { get; set; }
    }
    public class MessageConsumer : IConsumer<IMessage>
    {
       
        public async Task Consume(ConsumeContext<IMessage> context)
        {

            //Console.WriteLine($"Gelen mesaj : {context.Message.UserId + " " + context.Message.FirstName + " " + context.Message.LastName + " " + context.Message.Email}");
            Console.WriteLine($"Gelen mesaj : {context.Message.Text}");
        }
    }

    class Program
    {
        static async Task Main(string[] args)
        {
            string rabbitMqUri = "amqp://localhost";
            string queue = "test-jsondata";

            string userName = "guest";
            string password = "guest";

            var bus = Bus.Factory.CreateUsingRabbitMq(factory =>
            {
                factory.Host(rabbitMqUri, configurator =>
                {
                    configurator.Username(userName);
                    configurator.Password(password);
                });

                factory.ReceiveEndpoint(queue, endpoint => endpoint.Consumer<MessageConsumer>());
            });
            await bus.StartAsync();
            Console.ReadLine();
            await bus.StopAsync();
        }
    }
}