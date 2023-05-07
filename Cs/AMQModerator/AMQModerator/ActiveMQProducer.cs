using Apache.NMS;
using Apache.NMS.ActiveMQ;
using Newtonsoft.Json.Linq;
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

        public void TESTInitSendMess_AIRQ()
        {
            const string message = "{\r\n  \"ConsumerAddr\": \"ADJP.VARO.QUEUE.REQUEST.DL\",\r\n  \"ConsumerDestinationType\": 0,\r\n  \"ProducerAddr\": \"TEST.SANG.ACT.01\",\r\n  \"ProducerDestinationType\": 0,\r\n  \"TransID\": \"TRANSID\",\r\n  \"FACILITY\": \"CM\",\r\n  \"PRODUCT\": \"VARO\",\r\n  \"MACHINE_ID\": \"EQUIPMENT\",\r\n  \"PROCESS_CODE\": \"CWLA\",\r\n  \"LOT_ID\": \"LOT01\",\r\n  \"PANEL_ID\": \"PANEL001\",\r\n  \"MODULE_ID\": \"LINER_ID\",\r\n  \"JUDGE_SERVICE_TYPE\": \"SYNAPSE_IMAGING\",\r\n  \"SUB_JUDGE_SERVICE_TYPE\": \"SYNAPSE_RULE_INSPECTION\",\r\n  \"IMAGE_PATH_LIST\": [\r\n    \"D:\\\\ADJ_VARO\\\\DATA\\\\IMAGE\\\\RWGE\\\\02\\\\09\\\\GT7AA1BKD23GWA_00_2D1_AMV49221110103125053QBM-26_20230209000031_RWGE-00002T03_.bmp\",\r\n    \" D:\\\\ADJ_VARO\\\\DATA\\\\IMAGE\\\\RWGE\\\\02\\\\09\\\\GT7AA1BKD23GWA_00_2D2_AMV49221110103125053QBM-26_20230209000032_RWGE-00002T03_.bmp\",\r\n    \" D:\\\\ADJ_VARO\\\\DATA\\\\IMAGE\\\\RWGE\\\\02\\\\09\\\\GT7AA1BKD23GWA_00_2D3_AMV49221110103125053QBM-26_20230209000034_RWGE-00002T03_.bmp\",\r\n    \" D:\\\\ADJ_VARO\\\\DATA\\\\IMAGE\\\\RWGE\\\\02\\\\09\\\\GT7AA1BKD23GWA_00_AttachPR1_AMV49221110103125053QBM-26_20230208234303_RWGE-00002T01_.bmp\",\r\n    \" D:\\\\ADJ_VARO\\\\DATA\\\\IMAGE\\\\RWGE\\\\02\\\\09\\\\GT7AA1BKD23GWA_00_AttachPR2_AMV49221110103125053QBM-26_20230208234430_RWGE-00002T01_.bmp\",\r\n    \" D:\\\\ADJ_VARO\\\\DATA\\\\IMAGE\\\\RWGE\\\\02\\\\09\\\\GT7AA1BKD23GWA_00_AttachPR3_AMV49221110103125053QBM-26_20230208234604_RWGE-00002T01_.bmp\",\r\n    \" D:\\\\ADJ_VARO\\\\DATA\\\\IMAGE\\\\RWGE\\\\02\\\\09\\\\GT7AA1BKD23GWA_00_PDI1_AMV49221110103125053QBM-26_20230209000010_RWGE-00002T02_.bmp\",\r\n    \" D:\\\\ADJ_VARO\\\\DATA\\\\IMAGE\\\\RWGE\\\\02\\\\09\\\\GT7AA1BKD23GWA_00_PDI2_AMV49221110103125053QBM-26_20230209000008_RWGE-00002T02_(1).bmp\",\r\n    \" D:\\\\ADJ_VARO\\\\DATA\\\\IMAGE\\\\RWGE\\\\02\\\\09\\\\GT7AA1BKD23GWA_00_PDI3_AMV49221110103125053QBM-26_20230209000007_RWGE-00002T02_.bmp\",\r\n    \" D:\\\\ADJ_VARO\\\\DATA\\\\IMAGE\\\\RWGE\\\\02\\\\09\\\\GT7AA1BKD23GWA_00_PR1_AMV49221110103125053QBM-26_20230208235849_RWGE-00002T02_.bmp\",\r\n    \" D:\\\\ADJ_VARO\\\\DATA\\\\IMAGE\\\\RWGE\\\\02\\\\09\\\\GT7AA1BKD23GWA_00_PR2_AMV49221110103125053QBM-26_20230208235850_RWGE-00002T02_.bmp\",\r\n    \" D:\\\\ADJ_VARO\\\\DATA\\\\IMAGE\\\\RWGE\\\\02\\\\09\\\\GT7AA1BKD23GWA_00_PR3_AMV49221110103125053QBM-26_20230208235852_RWGE-00002T02_(1).bmp\"\r\n  ],\r\n  \"REQUEST_INFO\": {\r\n    \"Image_Save_ADJ_Root_Path\": \"D:\\\\ADJ_VARO\\\\DATA\\\\IMAGE\\\\RWGE\\\\02\\\\09\\\\CROP\",\r\n    \"Image_Save_Review_Root_Path\": \"D:\\\\ADJ_VARO\\\\DATA\\\\IMAGE\\\\RWGE\\\\02\\\\09\\\\REVIEW\"\r\n  }\r\n}\r\n";

            JObject jObject = JObject.Parse(message);

            ITextMessage textMessage = _producer.CreateTextMessage();
            textMessage.NMSCorrelationID = "TEST_MESS_ID"; // 그대로 보내주세요.
            textMessage.NMSType = "AIRQ"; // 통신 타입. 전송하는 통신 타입
            textMessage.Properties.SetString("guid", Guid.NewGuid().ToString()); // GUID
            textMessage.Text = jObject.ToString();
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