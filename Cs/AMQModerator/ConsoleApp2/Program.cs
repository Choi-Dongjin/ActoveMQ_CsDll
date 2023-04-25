using AMQModerator;
using AMQModerator.Datas;
using Newtonsoft.Json.Linq;
using System.Text.Json;

namespace ConsoleApp2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            //ActiveMQMorderator amq;
            //amq = new(_brokerUri1, _queueName);
            //while (true)
            //{
            //    string mess = amq.ReceiveMessage();
            //}
            Program program = new();
        }

        #region TEST Mess

        private const string tEAYT = "{\r\n   \"Version\": \"2.3.3.1\",\r\n   \"MessageName\": \"EAYT\",\r\n   \"Description\": \"Are you there\",\r\n   \"ConsumerAddr\": \"ADJP.VARO.QUEUE.REQUEST.DL\",\r\n   \"ConsumerDestinationType\": 0,\r\n   \"ProducerAddr\": \"ADJP.VARO.QUEUE.REQUEST.DL\",\r\n   \"ProducerDestinationType\": 0,\r\n   \"TransID\": \"TRANS_ID\",\r\n   \"REPLY_REQ\": 0,\r\n   \"TXN_DATE_TIME\": \"2023-04-13T13:16:43.1829265+09:00\"\r\n }";

        private const string tEAYTR = "{\"Version\":\"0.1\",\"MessageName\":\"EAYT_R\",\"Description\":\"Are you there reply\",\"ConsumerAddr\":\"ADJ.CONTAINER.CM.001\",\"ConsumerDestinationType\":0,\"ProducerAddr\":\"ADJ.CONTAINER.CM.SYNAPSE\",\"ProducerDestinationType\":0,\"TransID\":\"MP01_THREAD001_DL_20230324170902222\",\"EQP\":\"ADJP_DL_IF\",\"NAME\":\"LGITRVDI04V579\",\"TXN_DATE\":\"20230324\",\"TXN_TIME\":\"170903745\",\"RTN_CD\":\"0\",\"ERR_CD\":\"\",\"ERR_MSG\":\"\"}";

        private const string tAIRQ = "{\r\n  \"Version\": \"2.3.4.3\",\r\n  \"MessageName\": \"AIRQ\",\r\n  \"Description\": \"ADJP Inspection ReQuset\",\r\n  \"ConsumerAddr\": \"ADJP.VARO.QUEUE.REQUEST.DL\",\r\n  \"ConsumerDestinationType\": 0,\r\n  \"ProducerAddr\": \"TEST.SANG.ACT.01\",\r\n  \"ProducerDestinationType\": 0,\r\n  \"TransID\": \"TTT-0000-0001\",\r\n  \"FACILITY\": \"CM\",\r\n  \"PRODUCT\": \"VARO\",\r\n  \"MACHINE_ID\": \"EQUIPMENT\",\r\n  \"PROCESS_CODE\": \"RWGE\",\r\n  \"LOT_ID\": \"LOT01\",\r\n  \"PANEL_ID\": \"PANEL001\",\r\n  \"MODULE_ID\": \"LINER_ID\",\r\n  \"JUDGE_SERVICE_TYPE\": \"SYNAPSE_IMAGING\",\t\r\n  \"SUB_JUDGE_SERVICE_TYPE\": \"SYNAPSE_RULE_INSPECTION\",\r\n  \"IMAGE_PATH_LIST\": [\r\n    \"D:\\\\ADJ_VARO\\\\DATA\\\\IMAGE\\\\RWGE\\\\02\\\\09\\\\GT7AA1BKD23GWA_00_2D1_AMV49221110103125053QBM-26_20230209000031_RWGE-00002T03_.bmp\",\r\n    \" D:\\\\ADJ_VARO\\\\DATA\\\\IMAGE\\\\RWGE\\\\02\\\\09\\\\GT7AA1BKD23GWA_00_2D2_AMV49221110103125053QBM-26_20230209000032_RWGE-00002T03_.bmp\",\r\n    \" D:\\\\ADJ_VARO\\\\DATA\\\\IMAGE\\\\RWGE\\\\02\\\\09\\\\GT7AA1BKD23GWA_00_2D3_AMV49221110103125053QBM-26_20230209000034_RWGE-00002T03_.bmp\",\r\n    \" D:\\\\ADJ_VARO\\\\DATA\\\\IMAGE\\\\RWGE\\\\02\\\\09\\\\GT7AA1BKD23GWA_00_AttachPR1_AMV49221110103125053QBM-26_20230208234303_RWGE-00002T01_.bmp\",\r\n    \" D:\\\\ADJ_VARO\\\\DATA\\\\IMAGE\\\\RWGE\\\\02\\\\09\\\\GT7AA1BKD23GWA_00_AttachPR2_AMV49221110103125053QBM-26_20230208234430_RWGE-00002T01_.bmp\",\r\n    \" D:\\\\ADJ_VARO\\\\DATA\\\\IMAGE\\\\RWGE\\\\02\\\\09\\\\GT7AA1BKD23GWA_00_AttachPR3_AMV49221110103125053QBM-26_20230208234604_RWGE-00002T01_.bmp\",\r\n    \" D:\\\\ADJ_VARO\\\\DATA\\\\IMAGE\\\\RWGE\\\\02\\\\09\\\\GT7AA1BKD23GWA_00_PDI1_AMV49221110103125053QBM-26_20230209000010_RWGE-00002T02_.bmp\",\r\n    \" D:\\\\ADJ_VARO\\\\DATA\\\\IMAGE\\\\RWGE\\\\02\\\\09\\\\GT7AA1BKD23GWA_00_PDI2_AMV49221110103125053QBM-26_20230209000008_RWGE-00002T02_(1).bmp\",\r\n    \" D:\\\\ADJ_VARO\\\\DATA\\\\IMAGE\\\\RWGE\\\\02\\\\09\\\\GT7AA1BKD23GWA_00_PDI3_AMV49221110103125053QBM-26_20230209000007_RWGE-00002T02_.bmp\",\r\n    \" D:\\\\ADJ_VARO\\\\DATA\\\\IMAGE\\\\RWGE\\\\02\\\\09\\\\GT7AA1BKD23GWA_00_PR1_AMV49221110103125053QBM-26_20230208235849_RWGE-00002T02_.bmp\",\r\n    \" D:\\\\ADJ_VARO\\\\DATA\\\\IMAGE\\\\RWGE\\\\02\\\\09\\\\GT7AA1BKD23GWA_00_PR2_AMV49221110103125053QBM-26_20230208235850_RWGE-00002T02_.bmp\",\r\n    \" D:\\\\ADJ_VARO\\\\DATA\\\\IMAGE\\\\RWGE\\\\02\\\\09\\\\GT7AA1BKD23GWA_00_PR3_AMV49221110103125053QBM-26_20230208235852_RWGE-00002T02_(1).bmp\"\r\n  ],\r\n  \"REQUEST_INFO\": {\r\n    \"Image_Save_ADJ_Root_Path\": \"D:\\\\ADJ_VARO\\\\DATA\\\\IMAGE\\\\RWGE\\\\02\\\\09\\\\CROP\",\r\n    \"Image_Save_Review_Root_Path\": \"D:\\\\ADJ_VARO\\\\DATA\\\\IMAGE\\\\RWGE\\\\02\\\\09\\\\REVIEW\"\r\n  }\r\n}\r\n";

        private const string tSPRS = "{\"Version\":\"2.3.3.2\",\"MessageName\":\"SPRS\",\"Description\":\"SYNAPS Processing Result\",\"ConsumerAddr\":\"TEST.SANG.ACT.02\",\"ConsumerDestinationType\":0,\"ProducerAddr\":\"TEST.SANG.ACT.01\",\"ProducerDestinationType\":0,\"TransID“:”CM01_THREAD001_DL_20230324170902222”,\"FACILITY\":\"CM\",\"LINE\":\"LINE011\",\"EQUIPMENT\":\"EQUIPMENT\",\"MAIN_PROCESS\":\"CWLA\",\"DETAIL_PROCESS\":\"Coil Winding\",\"LOT_ID\":\"LOT01\",\"SENSOR_ID\":\"\",\"TESTITEM_PROCESS_INFO\":\"\",\"TESTITEM_COIL_INDEX\":\"PR\",\"MODULEID_PANEL_ID\":\"PANEL001\",\"MODULEID_FLEX_INDEX\":\"30\",\"TESTTIME\":\"yyyymmddhhmmss\",\"STATION\":\"CWL-001\",\"JUDGE_PROGRAM_ID\":\"SYNAPSE01\",\"JUDGE_SERVIE_TYPE\":\"DEFECT_INSPECTION\",\"RESULT\":\"0\",\"ERROR_CODE\":\"\",\"ERROR_MESSAGE\":\"\",\"WORK_START_DATE\":\"2023-03-29T15:09:54.9093122+09:00\",\"WORK_TIME\":\"10675199.02:48:05.4775807\",\"WAIT_TIME\":\"-10675199.02:48:05.4775808\",\"RESULT_INFO\":{}}";

        #endregion TEST Mess

        private CancellationTokenSource _mainCTS = new();
        private const string _brokerUri1 = "failover:tcp://127.0.0.1:61616";
        //private const string brokerUri2 = "tcp://localhost:61617";
        private const string _queueName = "queue://TEST.SANG.ACT.01";

        private readonly ActiveMQMorderator _activeMQMorderator;

        public Program()
        {
            if (!ActiveMQHelper.IsConnected(_brokerUri1))
            {
                return;
            }

            this._activeMQMorderator = new(_brokerUri1, _queueName);
            //Task.Run(() => ConsumerStart(this._mainCTS.Token));
            this._activeMQMorderator.TestInitSendMessage_EAYT(tEAYT);
            string mess = this._activeMQMorderator.ReceiveMessage();
            this._activeMQMorderator.TestInitSendMessage_AIRQ(tAIRQ);
            mess = this._activeMQMorderator.ReceiveMessage();
            DataAIRS? dataAIRS = null;
            try
            {
                dataAIRS = JsonSerializer.Deserialize<DataAIRS>(mess);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.Message);
            }

            if (dataAIRS != null)
            {
                Console.WriteLine(mess.ToString());
            }
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
                        this._activeMQMorderator.SendMessageStandard(tEAYTR, "EAYT");
                        //Console.WriteLine("Produced message (Queue) : " + tEAYTR);
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