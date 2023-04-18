using Apache.NMS;
using Apache.NMS.ActiveMQ;
using System;

namespace AMQModerator
{
    public class ActiveMQProducer : IDisposable
    {
        private readonly IConnectionFactory _factory;
        private readonly IConnection _connection;
        private readonly ISession _session;
        private readonly IDestination _destination;
        private readonly IMessageProducer _producer;

        public ActiveMQProducer(string brokerUri, string destinationName)
        {
            _factory = new ConnectionFactory(brokerUri);
            _connection = _factory.CreateConnection();
            _connection.Start();
            _session = _connection.CreateSession();
            if (destinationName.StartsWith("queue://"))
            {
                _destination = _session.GetQueue(destinationName.Substring(8));
            }
            else if (destinationName.StartsWith("topic://"))
            {
                _destination = _session.GetTopic(destinationName.Substring(8));
            }
            else
            {
                throw new ArgumentException("Invalid destination name: " + destinationName);
            }
            _producer = _session.CreateProducer(_destination);
        }

        public void SendMessage(string message)
        {
            ITextMessage textMessage = _producer.CreateTextMessage();
            textMessage.Text = message;
            _producer.Send(textMessage);
        }

        public bool IsConnected()
        {
            return _connection.IsStarted;
        }

        public void Dispose()
        {
            _producer?.Dispose();
            _session?.Dispose();
            _connection?.Dispose();
        }
    }
}