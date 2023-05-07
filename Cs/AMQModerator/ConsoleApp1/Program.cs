using AMQModerator;
using Newtonsoft.Json.Linq;
using Apache.NMS;
using Apache.NMS.ActiveMQ;
using Apache.NMS.ActiveMQ.Commands;
using AMQModerator.Datas;

namespace ConsoleApp1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Program program = new();

            while (!program.mainCTS.IsCancellationRequested)
            {
                Thread.Sleep(1000);
            }
        }

        private const string tEAYT = "{\"Version\":\"0.1\",\"MessageName\":\"EAYT\",\"Description\":\"Are you there\",\"ConsumerAddr\":\"ADJ.CONTAINER.CM.SYNAPSE\",\"ConsumerDestinationType\":0,\"ProducerAddr\":\"ADJ.CONTAINER.CM.001\",\"ProducerDestinationType\":0,\"TransID\":\"MP01_THREAD001_DL_20230324170902222\",\"EQP\":\"ADJ_MAIN_001\",\"NAME\":\"LGITRVDI04V579\",\"REPLY_REQ\":0,\"TO_EQP\":\"ADJP_DL_IF\"}";

        private const string tEAYTR = "{\"Version\":\"0.1\",\"MessageName\":\"EAYT_R\",\"Description\":\"Are you there reply\",\"ConsumerAddr\":\"ADJ.CONTAINER.CM.001\",\"ConsumerDestinationType\":0,\"ProducerAddr\":\"ADJ.CONTAINER.CM.SYNAPSE\",\"ProducerDestinationType\":0,\"TransID\":\"MP01_THREAD001_DL_20230324170902222\",\"EQP\":\"ADJP_DL_IF\",\"NAME\":\"LGITRVDI04V579\",\"TXN_DATE\":\"20230324\",\"TXN_TIME\":\"170903745\",\"RTN_CD\":\"0\",\"ERR_CD\":\"\",\"ERR_MSG\":\"\"}";

        private const string tAIRQ = "{\r\n  \"Version\": \"2.3.4.3\",\r\n  \"MessageName\": \"AIRQ\",\r\n  \"Description\": \"ADJP Inspection ReQuset\",\r\n  \"ConsumerAddr\": \"ADJP.VARO.QUEUE.REQUEST.DL\",\r\n  \"ConsumerDestinationType\": 0,\r\n  \"ProducerAddr\": \"TEST.SANG.ACT.01\",\r\n  \"ProducerDestinationType\": 0,\r\n  \"TransID\": \"TRANSID\",\r\n  \"FACILITY\": \"CM\",\r\n  \"PRODUCT\": \"VARO\",\r\n  \"MACHINE_ID\": \"EQUIPMENT\",\r\n  \"PROCESS_CODE\": \"CWLA\",\r\n  \"LOT_ID\": \"LOT01\",\r\n  \"PANEL_ID\": \"PANEL001\",\r\n  \"MODULE_ID\": \"LINER_ID\",\r\n  \"JUDGE_SERVICE_TYPE\": \"SYNAPSE_IMAGING\",\r\n  \"SUB_JUDGE_SERVICE_TYPE\": \"SYNAPSE_RULE_INSPECTION\",\r\n  \"IMAGE_PATH_LIST\": [\r\n    \"D:\\\\ADJ_VARO\\\\DATA\\\\IMAGE\\\\RWGE\\\\02\\\\09\\\\GT7AA1BKD23GWA_00_2D1_AMV49221110103125053QBM-26_20230209000031_RWGE-00002T03_.bmp\",\r\n    \" D:\\\\ADJ_VARO\\\\DATA\\\\IMAGE\\\\RWGE\\\\02\\\\09\\\\GT7AA1BKD23GWA_00_2D2_AMV49221110103125053QBM-26_20230209000032_RWGE-00002T03_.bmp\",\r\n    \" D:\\\\ADJ_VARO\\\\DATA\\\\IMAGE\\\\RWGE\\\\02\\\\09\\\\GT7AA1BKD23GWA_00_2D3_AMV49221110103125053QBM-26_20230209000034_RWGE-00002T03_.bmp\",\r\n    \" D:\\\\ADJ_VARO\\\\DATA\\\\IMAGE\\\\RWGE\\\\02\\\\09\\\\GT7AA1BKD23GWA_00_AttachPR1_AMV49221110103125053QBM-26_20230208234303_RWGE-00002T01_.bmp\",\r\n    \" D:\\\\ADJ_VARO\\\\DATA\\\\IMAGE\\\\RWGE\\\\02\\\\09\\\\GT7AA1BKD23GWA_00_AttachPR2_AMV49221110103125053QBM-26_20230208234430_RWGE-00002T01_.bmp\",\r\n    \" D:\\\\ADJ_VARO\\\\DATA\\\\IMAGE\\\\RWGE\\\\02\\\\09\\\\GT7AA1BKD23GWA_00_AttachPR3_AMV49221110103125053QBM-26_20230208234604_RWGE-00002T01_.bmp\",\r\n    \" D:\\\\ADJ_VARO\\\\DATA\\\\IMAGE\\\\RWGE\\\\02\\\\09\\\\GT7AA1BKD23GWA_00_PDI1_AMV49221110103125053QBM-26_20230209000010_RWGE-00002T02_.bmp\",\r\n    \" D:\\\\ADJ_VARO\\\\DATA\\\\IMAGE\\\\RWGE\\\\02\\\\09\\\\GT7AA1BKD23GWA_00_PDI2_AMV49221110103125053QBM-26_20230209000008_RWGE-00002T02_(1).bmp\",\r\n    \" D:\\\\ADJ_VARO\\\\DATA\\\\IMAGE\\\\RWGE\\\\02\\\\09\\\\GT7AA1BKD23GWA_00_PDI3_AMV49221110103125053QBM-26_20230209000007_RWGE-00002T02_.bmp\",\r\n    \" D:\\\\ADJ_VARO\\\\DATA\\\\IMAGE\\\\RWGE\\\\02\\\\09\\\\GT7AA1BKD23GWA_00_PR1_AMV49221110103125053QBM-26_20230208235849_RWGE-00002T02_.bmp\",\r\n    \" D:\\\\ADJ_VARO\\\\DATA\\\\IMAGE\\\\RWGE\\\\02\\\\09\\\\GT7AA1BKD23GWA_00_PR2_AMV49221110103125053QBM-26_20230208235850_RWGE-00002T02_.bmp\",\r\n    \" D:\\\\ADJ_VARO\\\\DATA\\\\IMAGE\\\\RWGE\\\\02\\\\09\\\\GT7AA1BKD23GWA_00_PR3_AMV49221110103125053QBM-26_20230208235852_RWGE-00002T02_(1).bmp\"\r\n  ],\r\n  \"REQUEST_INFO\": {\r\n    \"Image_Save_ADJ_Root_Path\": \"D:\\\\ADJ_VARO\\\\DATA\\\\IMAGE\\\\RWGE\\\\02\\\\09\\\\CROP\",\r\n    \"Image_Save_Review_Root_Path\": \"D:\\\\ADJ_VARO\\\\DATA\\\\IMAGE\\\\RWGE\\\\02\\\\09\\\\REVIEW\"\r\n  }\r\n}";

        private const string tSPRS = "{\"Version\":\"2.3.3.2\",\"MessageName\":\"SPRS\",\"Description\":\"SYNAPS Processing Result\",\"ConsumerAddr\":\"TEST.SANG.ACT.02\",\"ConsumerDestinationType\":0,\"ProducerAddr\":\"TEST.SANG.ACT.01\",\"ProducerDestinationType\":0,\"TransID“:”CM01_THREAD001_DL_20230324170902222”,\"FACILITY\":\"CM\",\"LINE\":\"LINE011\",\"EQUIPMENT\":\"EQUIPMENT\",\"MAIN_PROCESS\":\"CWLA\",\"DETAIL_PROCESS\":\"Coil Winding\",\"LOT_ID\":\"LOT01\",\"SENSOR_ID\":\"\",\"TESTITEM_PROCESS_INFO\":\"\",\"TESTITEM_COIL_INDEX\":\"PR\",\"MODULEID_PANEL_ID\":\"PANEL001\",\"MODULEID_FLEX_INDEX\":\"30\",\"TESTTIME\":\"yyyymmddhhmmss\",\"STATION\":\"CWL-001\",\"JUDGE_PROGRAM_ID\":\"SYNAPSE01\",\"JUDGE_SERVIE_TYPE\":\"DEFECT_INSPECTION\",\"RESULT\":\"0\",\"ERROR_CODE\":\"\",\"ERROR_MESSAGE\":\"\",\"WORK_START_DATE\":\"2023-03-29T15:09:54.9093122+09:00\",\"WORK_TIME\":\"10675199.02:48:05.4775807\",\"WAIT_TIME\":\"-10675199.02:48:05.4775808\",\"RESULT_INFO\":{}}";

        private CancellationTokenSource mainCTS = new();
        private const string brokerUri1 = "tcp://localhost:61616";
        //const string brokerUri2 = "tcp://localhost:61617";

        private const string queueName = "queue://TEST.SANG.ACT.02";
        private const string topicName = "topic://example.01";

        private ActiveMQProducer qProducer = new ActiveMQProducer(brokerUri1, "queue://ADJP.VARO.QUEUE.REQUEST.DL");
        private ActiveMQProducer tProducer = new ActiveMQProducer(brokerUri1, topicName);
        private ActiveMQConsumer qConsumer = new ActiveMQConsumer(brokerUri1, queueName);
        private ActiveMQConsumer tConsumer = new ActiveMQConsumer(brokerUri1, topicName);

        public Program()
        {
            //this.tProducer.SendMessage(tSPRQ);
            this.qProducer.TESTInitSendMess_AIRQ();
            Task qConsumerTask = Task.Run(() => QConsumerStart(qConsumer, this.mainCTS.Token));
            //Task tConsumerTask = Task.Run(() => TConsumerStart(tConsumer, this.mainCTS.Token));
        }

        public void QConsumerStart(ActiveMQConsumer consumer, CancellationToken ct)
        {
            while (!ct.IsCancellationRequested)
            {
                string message = consumer.ReceiveMessage();
                Console.WriteLine("Received message (Queue) : " + message + "\n");
                JObject jObject;
                try
                {
                    jObject = JObject.Parse(message);
                }
                catch { continue; }

                //Data_EAYT? data_EAYT = JsonConvert.DeserializeObject<Data_EAYT>(message);

                if (!jObject.ContainsKey("MessageName"))
                    continue;

                string? messageName = jObject.Value<string>("MessageName");
                if (string.IsNullOrWhiteSpace(messageName))
                    continue;

                switch (messageName)
                {
                    case "EAYT":
                        this.qProducer.SendMessage(tEAYTR);
                        //Console.WriteLine("Produced message (Queue) : " + tEAYTR);
                        break;

                    case "EAYT_R":
                        break;

                    case "SPRQ":
                        this.qProducer.SendMessage(tSPRS);
                        
                        break;

                    case "SPRS":
                        break;
                }
            }
        }

        private void TConsumerStart(ActiveMQConsumer consumer, CancellationToken ct)
        {
            while (!ct.IsCancellationRequested)
            {
                string message = consumer.ReceiveMessage();
                Console.WriteLine("Received message (Topic) : " + message + "\n");

                JObject jObject;
                try
                {
                    jObject = JObject.Parse(message);
                }
                catch { continue; }

                if (!jObject.ContainsKey("ConsumerAddr"))
                    continue;

                string? consumerAddr = jObject.Value<string>("ConsumerAddr");
                if (string.IsNullOrWhiteSpace(consumerAddr))
                    continue;

                if (!consumerAddr.Equals("TEST.SANG.ACT.02"))
                    continue;

                if (!jObject.ContainsKey("MessageName"))
                    continue;

                string? messageName = jObject.Value<string>("MessageName");
                if (string.IsNullOrWhiteSpace(messageName))
                    continue;

                switch (messageName)
                {
                    case "EAYT":
                        this.tProducer.SendMessage(tEAYTR);
                        //Console.WriteLine("Produced message (Queue) : " + tEAYTR);
                        break;

                    case "EAYT_R":
                        break;

                    case "SPRQ":
                        this.tProducer.SendMessage(tSPRS);
                        break;

                    case "SPRS":
                        break;
                }
            }
        }
    }
}