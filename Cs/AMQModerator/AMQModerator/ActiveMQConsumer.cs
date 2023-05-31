using Apache.NMS;
using Apache.NMS.ActiveMQ;
using System;
using System.Collections;
using System.Data.Common;

namespace AMQModerator
{
    public class ActiveMQConsumer : IDisposable
    {
        private readonly IConnectionFactory _factory;
        private readonly IConnection _connection;
        private readonly ISession _session;
        private readonly IDestination _destination;
        private readonly IMessageConsumer _consumer;

        private IMessage _receiveIMessage;

        public IMessage ReceiveIMessage
        {
            get { return _receiveIMessage; }
            set { _receiveIMessage = value; }
        }

        public ActiveMQConsumer(string brokerUri, string destinationName)
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
            _consumer = _session.CreateConsumer(_destination);
        }

        public string ReceiveMessage()
        {
            IMessage message = _consumer.Receive();
            ReceiveIMessage = message;
            if (message is ITextMessage textMessage)
            {
                //Console.WriteLine("Received message: " + textMessage.Text);
                return textMessage.Text;
            }
            return null;
        }

        public string GetAllMessages()
        {
            var queueBrowser = _session.CreateBrowser((IQueue)_destination);
            var messages = new ArrayList();
            foreach (IMessage message in queueBrowser)
            {
                if (message is ITextMessage textMessage)
                {
                    ReceiveIMessage = textMessage;
                    Console.WriteLine(string.Format("Got GetAllMessages {0} : {1}", messages.Count, textMessage.Text));
                    messages.Add(textMessage.Text);
                }
            }
            return string.Join("\n", messages.ToArray());
        }

        public void ClearAllMessages()
        {
            _consumer.Close();
            _session.DeleteDestination(_destination);
            _session.CreateConsumer(_destination);
        }

        public bool IsConnected()
        {
            return _connection.IsStarted;
        }

        public void Dispose()
        {
            _consumer?.Close();
            _session?.Close();
            _connection?.Close();
            _consumer?.Dispose();
            _destination.Dispose();
            _session?.Dispose();
            _connection?.Dispose();

        }
    }
}