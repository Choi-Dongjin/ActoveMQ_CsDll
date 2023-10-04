using AMQModerator.Datas;
using Apache.NMS;
using Apache.NMS.ActiveMQ;
using Newtonsoft.Json.Linq;
using System;
using JsonSerializer = System.Text.Json.JsonSerializer;

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
        private IMessage _receiveIMessage;

        public IMessage ReceiveIMessage
        {
            get { return _receiveIMessage; }
            set { _receiveIMessage = value; }
        }

        public string ReceiveIMessageNMSType
        {
            get { return _receiveIMessage.NMSType; }
        }

        public ActiveMQMorderator(string brokerUri, string destinationName)
        {
            _factory = new ConnectionFactory(brokerUri);
            try
            {
                _connection = _factory.CreateConnection();
                _connection.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

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

        public void TestInitSendMessage_AIRQ(string message)
        {
            ITextMessage textMessage = _producer.CreateTextMessage();
            textMessage.NMSCorrelationID = "TEST_MESS_ID"; // 그대로 보내주세요.
            textMessage.NMSType = "AIRQ"; // 통신 타입. 전송하는 통신 타입
            textMessage.Properties.SetString("guid", Guid.NewGuid().ToString()); // GUID
            textMessage.Text = message;
            _producer.Send(textMessage);
        }

        public void TESTInitSendMess_AIRQ()
        {
            const string message = "{\r\n  \"Version\": \"2.3.4.3\",\r\n  \"MessageName\": \"AIRQ\",\r\n  \"Description\": \"ADJP Inspection ReQuset\",\r\n  \"ConsumerAddr\": \"ADJP.VARO.QUEUE.REQUEST.DL\",\r\n  \"ConsumerDestinationType\": 0,\r\n  \"ProducerAddr\": \"TEST.SANG.ACT.01\",\r\n  \"ProducerDestinationType\": 0,\r\n  \"TransID\": \"TTT-0000-0001\",\r\n  \"FACILITY\": \"CM\",\r\n  \"PRODUCT\": \"VARO\",\r\n  \"MACHINE_ID\": \"EQUIPMENT\",\r\n  \"PROCESS_CODE\": \"RWGE\",\r\n  \"LOT_ID\": \"LOT01\",\r\n  \"PANEL_ID\": \"PANEL001\",\r\n  \"MODULE_ID\": \"LINER_ID\",\r\n  \"JUDGE_SERVICE_TYPE\": \"SYNAPSE_IMAGING\",\t\r\n  \"SUB_JUDGE_SERVICE_TYPE\": \"SYNAPSE_RULE_INSPECTION\",\r\n  \"IMAGE_PATH_LIST\": [\r\n    \"D:\\\\ADJ_VARO\\\\DATA\\\\IMAGE\\\\RWGE\\\\02\\\\09\\\\GT7AA1BKD23GWA_00_2D1_AMV49221110103125053QBM-26_20230209000031_RWGE-00002T03_.bmp\",\r\n    \" D:\\\\ADJ_VARO\\\\DATA\\\\IMAGE\\\\RWGE\\\\02\\\\09\\\\GT7AA1BKD23GWA_00_2D2_AMV49221110103125053QBM-26_20230209000032_RWGE-00002T03_.bmp\",\r\n    \" D:\\\\ADJ_VARO\\\\DATA\\\\IMAGE\\\\RWGE\\\\02\\\\09\\\\GT7AA1BKD23GWA_00_2D3_AMV49221110103125053QBM-26_20230209000034_RWGE-00002T03_.bmp\",\r\n    \" D:\\\\ADJ_VARO\\\\DATA\\\\IMAGE\\\\RWGE\\\\02\\\\09\\\\GT7AA1BKD23GWA_00_AttachPR1_AMV49221110103125053QBM-26_20230208234303_RWGE-00002T01_.bmp\",\r\n    \" D:\\\\ADJ_VARO\\\\DATA\\\\IMAGE\\\\RWGE\\\\02\\\\09\\\\GT7AA1BKD23GWA_00_AttachPR2_AMV49221110103125053QBM-26_20230208234430_RWGE-00002T01_.bmp\",\r\n    \" D:\\\\ADJ_VARO\\\\DATA\\\\IMAGE\\\\RWGE\\\\02\\\\09\\\\GT7AA1BKD23GWA_00_AttachPR3_AMV49221110103125053QBM-26_20230208234604_RWGE-00002T01_.bmp\",\r\n    \" D:\\\\ADJ_VARO\\\\DATA\\\\IMAGE\\\\RWGE\\\\02\\\\09\\\\GT7AA1BKD23GWA_00_PDI1_AMV49221110103125053QBM-26_20230209000010_RWGE-00002T02_.bmp\",\r\n    \" D:\\\\ADJ_VARO\\\\DATA\\\\IMAGE\\\\RWGE\\\\02\\\\09\\\\GT7AA1BKD23GWA_00_PDI2_AMV49221110103125053QBM-26_20230209000008_RWGE-00002T02_(1).bmp\",\r\n    \" D:\\\\ADJ_VARO\\\\DATA\\\\IMAGE\\\\RWGE\\\\02\\\\09\\\\GT7AA1BKD23GWA_00_PDI3_AMV49221110103125053QBM-26_20230209000007_RWGE-00002T02_.bmp\",\r\n    \" D:\\\\ADJ_VARO\\\\DATA\\\\IMAGE\\\\RWGE\\\\02\\\\09\\\\GT7AA1BKD23GWA_00_PR1_AMV49221110103125053QBM-26_20230208235849_RWGE-00002T02_.bmp\",\r\n    \" D:\\\\ADJ_VARO\\\\DATA\\\\IMAGE\\\\RWGE\\\\02\\\\09\\\\GT7AA1BKD23GWA_00_PR2_AMV49221110103125053QBM-26_20230208235850_RWGE-00002T02_.bmp\",\r\n    \" D:\\\\ADJ_VARO\\\\DATA\\\\IMAGE\\\\RWGE\\\\02\\\\09\\\\GT7AA1BKD23GWA_00_PR3_AMV49221110103125053QBM-26_20230208235852_RWGE-00002T02_(1).bmp\"\r\n  ],\r\n  \"REQUEST_INFO\": {\r\n    \"Image_Save_ADJ_Root_Path\": \"D:\\\\ADJ_VARO\\\\DATA\\\\IMAGE\\\\RWGE\\\\02\\\\09\\\\CROP\",\r\n    \"Image_Save_Review_Root_Path\": \"D:\\\\ADJ_VARO\\\\DATA\\\\IMAGE\\\\RWGE\\\\02\\\\09\\\\REVIEW\"\r\n  }\r\n}\r\n";

            JObject jObject = JObject.Parse(message);

            ITextMessage textMessage = _producer.CreateTextMessage();
            textMessage.NMSCorrelationID = "TEST_MESS_ID"; // 그대로 보내주세요.
            textMessage.NMSType = "AIRQ"; // 통신 타입. 전송하는 통신 타입
            textMessage.Properties.SetString("guid", Guid.NewGuid().ToString()); // GUID
            textMessage.Text = jObject.ToString();
            _producer.Send(textMessage);
        }

        public bool SendMessageStandard(string message, string nmsType)
        {
            if (ReceiveIMessage is null)
                return false;

            ITextMessage textMessage = _producer.CreateTextMessage();
            textMessage.NMSCorrelationID = ReceiveIMessage.NMSCorrelationID; // 그대로 보내주세요.
            textMessage.NMSType = nmsType; // 통신 타입. 전송하는 통신 타입
            textMessage.Properties.SetString("guid", ReceiveIMessage.Properties.GetString("guid")); // GUID
            textMessage.Text = message;
            _producer.Send(textMessage);
            return true;
        }

        public bool SendMessageStandard(string message, string nmsType, IMessage receiveIMessage)
        {
            if (receiveIMessage is null)
                return false;

            ITextMessage textMessage = _producer.CreateTextMessage();
            textMessage.NMSCorrelationID = receiveIMessage.NMSCorrelationID; // 그대로 보내주세요.
            textMessage.NMSType = nmsType; // 통신 타입. 전송하는 통신 타입
            textMessage.Properties.SetString("guid", receiveIMessage.Properties.GetString("guid")); // GUID
            textMessage.Text = message;
            _producer.Send(textMessage);
            return true;
        }

        public string ReceiveMessage()
        {
            IMessage message = _consumer.Receive(TimeSpan.FromSeconds(10D));
            ReceiveIMessage = message;

            if (message is ITextMessage textMessage)
            {
                return textMessage.Text;
            }
            return null;
        }

        public string AnswerEAYT(string requestData)
        {
            JObject requestDataJaon;
            try
            {
                requestDataJaon = JObject.Parse(requestData);
            }
            catch { return string.Empty; }

            DataEAYT_R dataEAYT = JsonSerializer.Deserialize<DataEAYT_R>(requestData);
            if (dataEAYT == null)
            {
                return string.Empty;
            }
            string pConsumerAddr = dataEAYT.ConsumerAddr;
            int pConsumerDestinationType = dataEAYT.ConsumerDestinationType;
            string pProducerAddr = dataEAYT.ProducerAddr;
            int pProducerDestinationType = dataEAYT.ProducerDestinationType;

            dataEAYT.ConsumerAddr = pProducerAddr;
            dataEAYT.ConsumerDestinationType = pProducerDestinationType;
            dataEAYT.ProducerAddr = pConsumerAddr;
            dataEAYT.ProducerDestinationType = pConsumerDestinationType;

            dataEAYT.TXN_DATE_TIME = DateTime.Now;
            dataEAYT.RTN_CD = "0"; // 정상
            dataEAYT.ERR_CD = string.Empty;
            dataEAYT.ERR_MSG = string.Empty;

            return JsonSerializer.Serialize<DataEAYT_R>(dataEAYT);
        }
    }
}