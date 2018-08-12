namespace Publisher
{
    using EasyNetQ;
    using Messages;
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                for (int numberOfQueue = 1; numberOfQueue <= 10; numberOfQueue++)
                {
                    var queueMessages = string.Format("This is the queue number: {0}", numberOfQueue);
                    CreateQueue(bus, queueMessages);
                    Console.WriteLine(queueMessages);
                    Console.ReadKey();
                }
            }
        }

        private static void CreateQueue(IBus bus, string queueMessages)
        {
            bus.Publish(new TextMessage
            {
                Text = queueMessages
            });
        }
    }
}
