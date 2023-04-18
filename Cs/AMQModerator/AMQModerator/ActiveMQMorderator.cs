using Apache.NMS;
using Apache.NMS.ActiveMQ;
using System;

namespace AMQModerator
{
    public class ActiveMQMorderator : IDisposable
    {
        #region Dispos

        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 관리형 상태(관리형 개체)를 삭제합니다.
                }

                _producer?.Dispose();
                _session?.Dispose();
                _connection?.Dispose();
                _producer?.Dispose();

                // TODO: 비관리형 리소스(비관리형 개체)를 해제하고 종료자를 재정의합니다.
                // TODO: 큰 필드를 null로 설정합니다.
                disposedValue = true;
            }
        }

        // // TODO: 비관리형 리소스를 해제하는 코드가 'Dispose(bool disposing)'에 포함된 경우에만 종료자를 재정의합니다.
        // ~ActiveMQMorderator()
        // {
        //     // 이 코드를 변경하지 마세요. 'Dispose(bool disposing)' 메서드에 정리 코드를 입력합니다.
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // 이 코드를 변경하지 마세요. 'Dispose(bool disposing)' 메서드에 정리 코드를 입력합니다.
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion Dispos

        private readonly IConnectionFactory _factory;
        private readonly IConnection _connection;
        private readonly ISession _session;
        private readonly IDestination _destination;
        private readonly IMessageConsumer _consumer;
        private readonly IMessageProducer _producer;
        private IMessage _receiveMessage;

        public IMessage ReceiveIMessage
        {
            get { return _receiveMessage; }
            private set { _receiveMessage = value; }
        }

        public string ReceiveIMessageNMSType
        {
            get { return _receiveMessage.NMSType; }
        }

        public ActiveMQMorderator(string brokerUri, string destinationName)
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
            _producer = _session.CreateProducer(_destination);
        }

        public bool IsConnected()
        {
            return _connection.IsStarted;
        }

        public void SendMessage(string message)
        {
            ITextMessage textMessage = _producer.CreateTextMessage();
            textMessage.Text = message;
            _producer.Send(textMessage);
        }

        public void TestInitSendMessage_EAYT(string message)
        {
            ITextMessage textMessage = _producer.CreateTextMessage();
            textMessage.NMSCorrelationID = "TEST_MESS_ID"; // 그대로 보내주세요.
            textMessage.NMSType = "EAYT"; // 통신 타입. 전송하는 통신 타입
            textMessage.Properties.SetString("guid", Guid.NewGuid().ToString()); // GUID
            textMessage.Text = message;
            _producer.Send(textMessage);
        }

        public void TestInitSendMessage_SPRQ(string message)
        {
            ITextMessage textMessage = _producer.CreateTextMessage();
            textMessage.NMSCorrelationID = "TEST_MESS_ID"; // 그대로 보내주세요.
            textMessage.NMSType = "SPRQ"; // 통신 타입. 전송하는 통신 타입
            textMessage.Properties.SetString("guid", Guid.NewGuid().ToString()); // GUID
            textMessage.Text = message;
            _producer.Send(textMessage);
        }

        public bool SendMessageStandard(string message, string nmsType)
        {
            if (_receiveMessage is null)
                return false;

            ITextMessage textMessage = _producer.CreateTextMessage();
            textMessage.NMSCorrelationID = _receiveMessage.NMSCorrelationID; // 그대로 보내주세요.
            textMessage.NMSType = nmsType; // 통신 타입. 전송하는 통신 타입
            textMessage.Properties.SetString("guid", _receiveMessage.Properties.GetString("guid")); // GUID
            textMessage.Text = message;
            _producer.Send(textMessage);
            return true;
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
    }
}