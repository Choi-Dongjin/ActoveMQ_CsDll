namespace ConsoleApp3
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            AMQModerator.Main.ConsumerInitialize("failover:tcp://127.0.0.1:61616", "queue://ADJP.VARO.QUEUE.REQUEST.DL");
            while (true)
            {
                string mes = AMQModerator.Main.ConsumerReceiveMessage(true);
            }
        }
    }
}
// Secondary
// secondary
// _secondary