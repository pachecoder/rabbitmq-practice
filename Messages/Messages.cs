namespace Messages
{
    using EasyNetQ;
    using System.Threading;

    [Queue("MessagesQueue", ExchangeName = "MyTestExchange")]
    public class TextMessage
    {
        public string Text { get; set; }

        public string LongQueueTask()
        {
            Thread.Sleep(5000);
            return Text;
        }
    }

    
}
