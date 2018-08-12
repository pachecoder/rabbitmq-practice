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
                var input = "";
                var createQueue = "Press any key to start to create queues. Write [Quit] to quit.";
                Console.WriteLine(createQueue);
                while ((input = Console.ReadLine()) != "Quit")
                {
                    for (int numberOfQueue = 1; numberOfQueue <= 10; numberOfQueue++)
                    {
                        var queueMessages = string.Format("This is the queue number: {0}", numberOfQueue);
                        CreateQueue(bus, queueMessages);
                        Console.WriteLine(queueMessages);
                    }
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
