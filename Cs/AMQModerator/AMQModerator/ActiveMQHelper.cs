using Apache.NMS.ActiveMQ;
using System;

namespace AMQModerator
{
    public static class ActiveMQHelper
    {
        public static bool IsConnected(string brokerUri)
        {
            try
            {
                var factory = new ConnectionFactory(brokerUri);
                var connection = factory.CreateConnection();
                connection.Start();
                connection.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}