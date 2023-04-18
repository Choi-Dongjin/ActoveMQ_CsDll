using AMQModerator;
using Newtonsoft.Json.Linq;

namespace ConsoleApp2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Program program = new();

            while (!program._mainCTS.IsCancellationRequested)
            {
                Thread.Sleep(1000);
            }
        }

        #region TEST Mess

        private const string tEAYT = "{\"Version\":\"0.1\",\"MessageName\":\"EAYT\",\"Description\":\"Are you there\",\"ConsumerAddr\":\"ADJ.CONTAINER.CM.SYNAPSE\",\"ConsumerDestinationType\":0,\"ProducerAddr\":\"ADJ.CONTAINER.CM.001\",\"ProducerDestinationType\":0,\"TransID\":\"MP01_THREAD001_DL_20230324170902222\",\"EQP\":\"ADJ_MAIN_001\",\"NAME\":\"LGITRVDI04V579\",\"REPLY_REQ\":0,\"TO_EQP\":\"ADJP_DL_IF\"}";

        private const string tEAYTR = "{\"Version\":\"0.1\",\"MessageName\":\"EAYT_R\",\"Description\":\"Are you there reply\",\"ConsumerAddr\":\"ADJ.CONTAINER.CM.001\",\"ConsumerDestinationType\":0,\"ProducerAddr\":\"ADJ.CONTAINER.CM.SYNAPSE\",\"ProducerDestinationType\":0,\"TransID\":\"MP01_THREAD001_DL_20230324170902222\",\"EQP\":\"ADJP_DL_IF\",\"NAME\":\"LGITRVDI04V579\",\"TXN_DATE\":\"20230324\",\"TXN_TIME\":\"170903745\",\"RTN_CD\":\"0\",\"ERR_CD\":\"\",\"ERR_MSG\":\"\"}";

        private const string tSPRQ = "{\"Version\":\"2.3.3.1\",\"MessageName\":\"SPRQ\",\"Description\":\"SYNAPS Processing Request\",\"ConsumerAddr\":\"TEST.SANG.ACT.02\",\"ConsumerDestinationType\":0,\"ProducerAddr\":\"TEST.SANG.ACT.01\",\"ProducerDestinationType\":0,\"TransID\":\"TEST.SANG.ACT.02\",\"FACILITY\":\"CM\",\"LINE\":\"LINE011\",\"EQUIPMENT\":\"EQUIPMENT\",\"MAIN_PROCESS\":\"CWLA\",\"DETAIL_PROCESS\":\"Coil Winding\",\"LOT_ID\":\"LOT01\",\"SENSOR_ID\":\"\",\"TESTITEM_PROCESS_INFO\":\"\",\"TESTITEM_COIL_INDEX\":\"PR\",\"MODULEID_PANEL_ID\":\"PANEL001\",\"MODULEID_FLEX_INDEX\":\"30\",\"TESTTIME\":\"yyyymmddhhmmss\",\"STATION\":\"CWL-001\",\"JUDGE_SERVICE_TYPE\r\n\":\"RULE_INSPECTION\",\"IMAGE_PATH\":[\"IMAGE.BMP\",\"IMAGE2.BMP\"],\"REQUEST_INFO\":{\"IMAGE_PATH\":[\"IMAGE.BMP\",\"IMAGE2.BMP\"],\"RECIPE_ID\":[0,1]}}";

        private const string tSPRS = "{\"Version\":\"2.3.3.2\",\"MessageName\":\"SPRS\",\"Description\":\"SYNAPS Processing Result\",\"ConsumerAddr\":\"TEST.SANG.ACT.02\",\"ConsumerDestinationType\":0,\"ProducerAddr\":\"TEST.SANG.ACT.01\",\"ProducerDestinationType\":0,\"TransID“:”CM01_THREAD001_DL_20230324170902222”,\"FACILITY\":\"CM\",\"LINE\":\"LINE011\",\"EQUIPMENT\":\"EQUIPMENT\",\"MAIN_PROCESS\":\"CWLA\",\"DETAIL_PROCESS\":\"Coil Winding\",\"LOT_ID\":\"LOT01\",\"SENSOR_ID\":\"\",\"TESTITEM_PROCESS_INFO\":\"\",\"TESTITEM_COIL_INDEX\":\"PR\",\"MODULEID_PANEL_ID\":\"PANEL001\",\"MODULEID_FLEX_INDEX\":\"30\",\"TESTTIME\":\"yyyymmddhhmmss\",\"STATION\":\"CWL-001\",\"JUDGE_PROGRAM_ID\":\"SYNAPSE01\",\"JUDGE_SERVIE_TYPE\":\"DEFECT_INSPECTION\",\"RESULT\":\"0\",\"ERROR_CODE\":\"\",\"ERROR_MESSAGE\":\"\",\"WORK_START_DATE\":\"2023-03-29T15:09:54.9093122+09:00\",\"WORK_TIME\":\"10675199.02:48:05.4775807\",\"WAIT_TIME\":\"-10675199.02:48:05.4775808\",\"RESULT_INFO\":{}}";

        #endregion TEST Mess

        private CancellationTokenSource _mainCTS = new();
        private const string _brokerUri1 = "tcp://localhost:61616";
        //private const string brokerUri2 = "tcp://localhost:61617";

        private const string _queueName = "queue://example.01";

        private readonly ActiveMQMorderator _activeMQMorderator;

        public Program()
        {
            this._activeMQMorderator = new(_brokerUri1, _queueName);
            Task.Run(() => ConsumerStart(this._mainCTS.Token));
            this._activeMQMorderator.TestInitSendMessage_EAYT(tEAYT);
            this._activeMQMorderator.TestInitSendMessage_SPRQ(tSPRQ);
        }

        private void ConsumerStart(CancellationToken ct)
        {
            while (!ct.IsCancellationRequested)
            {
                string message = this._activeMQMorderator.ReceiveMessage();
                Console.WriteLine("Received message (Queue) : " + message + "\n");
                JObject jObject;
                try
                {
                    jObject = JObject.Parse(message);
                }
                catch { continue; }

                //Data_EAYT? data_EAYT = JsonConvert.DeserializeObject<Data_EAYT>(message);

                string messageName = this._activeMQMorderator.ReceiveIMessageNMSType;

                switch (messageName)
                {
                    case "EAYT":
                        this._activeMQMorderator.SendMessageStandard(tEAYTR, "EAYT_R");
                        //Console.WriteLine("Produced message (Queue) : " + tEAYTR);
                        break;

                    case "EAYT_R":
                        break;

                    case "SPRQ":
                        this._activeMQMorderator.SendMessageStandard(tSPRS, "SPRQ");
                        break;

                    case "SPRS":
                        break;
                }
            }
        }
    }
}