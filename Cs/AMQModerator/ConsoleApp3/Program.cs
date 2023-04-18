using AMQModerator.Datas;
using Newtonsoft.Json.Linq;
using System.Text.Json;

namespace ConsoleApp3
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            JObject jObject;
            try
            {
                jObject = JObject.Parse(Program.message);
            }
            catch { }

            DataAIRQ? dataEAYT = JsonSerializer.Deserialize<DataAIRQ>(Program.message);

            if (dataEAYT != null) { }
        }

        public const string message = "{\r\n  \"Version\": \"2.3.4.3\",\r\n  \"MessageName\": \"AIRQ\",\r\n  \"Description\": \"ADJP Inspection ReQuset\",\r\n  \"ConsumerAddr\": \"ADJP.VARO.QUEUE.REQUEST.DL\",\r\n  \"ConsumerDestinationType\": 0,\r\n  \"ProducerAddr\": \"TEST.SANG.ACT.01\",\r\n  \"ProducerDestinationType\": 0,\r\n  \"TransID\": \"TTT-0000-0001\",\r\n  \"FACILITY\": \"CM\",\r\n  \"PRODUCT\": \"VARO\",\r\n  \"MACHINE_ID\": \"EQUIPMENT\",\r\n  \"PROCESS_CODE\": \"RWGE\",\r\n  \"LOT_ID\": \"LOT01\",\r\n  \"PANEL_ID\": \"PANEL001\",\r\n  \"MODULE_ID\": \"LINER_ID\",\r\n  \"JUDGE_SERVICE_TYPE\": \"SYNAPSE_IMAGING\",\t\r\n  \"SUB_JUDGE_SERVICE_TYPE\": \"SYNAPSE_RULE_INSPECTION\",\r\n  \"IMAGE_PATH_LIST\": [\r\n    \"D:\\\\ADJ_VARO\\\\DATA\\\\IMAGE\\\\RWGE\\\\02\\\\09\\\\GT7AA1BKD23GWA_00_2D1_AMV49221110103125053QBM-26_20230209000031_RWGE-00002T03_.bmp\",\r\n    \" D:\\\\ADJ_VARO\\\\DATA\\\\IMAGE\\\\RWGE\\\\02\\\\09\\\\GT7AA1BKD23GWA_00_2D2_AMV49221110103125053QBM-26_20230209000032_RWGE-00002T03_.bmp\",\r\n    \" D:\\\\ADJ_VARO\\\\DATA\\\\IMAGE\\\\RWGE\\\\02\\\\09\\\\GT7AA1BKD23GWA_00_2D3_AMV49221110103125053QBM-26_20230209000034_RWGE-00002T03_.bmp\",\r\n    \" D:\\\\ADJ_VARO\\\\DATA\\\\IMAGE\\\\RWGE\\\\02\\\\09\\\\GT7AA1BKD23GWA_00_AttachPR1_AMV49221110103125053QBM-26_20230208234303_RWGE-00002T01_.bmp\",\r\n    \" D:\\\\ADJ_VARO\\\\DATA\\\\IMAGE\\\\RWGE\\\\02\\\\09\\\\GT7AA1BKD23GWA_00_AttachPR2_AMV49221110103125053QBM-26_20230208234430_RWGE-00002T01_.bmp\",\r\n    \" D:\\\\ADJ_VARO\\\\DATA\\\\IMAGE\\\\RWGE\\\\02\\\\09\\\\GT7AA1BKD23GWA_00_AttachPR3_AMV49221110103125053QBM-26_20230208234604_RWGE-00002T01_.bmp\",\r\n    \" D:\\\\ADJ_VARO\\\\DATA\\\\IMAGE\\\\RWGE\\\\02\\\\09\\\\GT7AA1BKD23GWA_00_PDI1_AMV49221110103125053QBM-26_20230209000010_RWGE-00002T02_.bmp\",\r\n    \" D:\\\\ADJ_VARO\\\\DATA\\\\IMAGE\\\\RWGE\\\\02\\\\09\\\\GT7AA1BKD23GWA_00_PDI2_AMV49221110103125053QBM-26_20230209000008_RWGE-00002T02_(1).bmp\",\r\n    \" D:\\\\ADJ_VARO\\\\DATA\\\\IMAGE\\\\RWGE\\\\02\\\\09\\\\GT7AA1BKD23GWA_00_PDI3_AMV49221110103125053QBM-26_20230209000007_RWGE-00002T02_.bmp\",\r\n    \" D:\\\\ADJ_VARO\\\\DATA\\\\IMAGE\\\\RWGE\\\\02\\\\09\\\\GT7AA1BKD23GWA_00_PR1_AMV49221110103125053QBM-26_20230208235849_RWGE-00002T02_.bmp\",\r\n    \" D:\\\\ADJ_VARO\\\\DATA\\\\IMAGE\\\\RWGE\\\\02\\\\09\\\\GT7AA1BKD23GWA_00_PR2_AMV49221110103125053QBM-26_20230208235850_RWGE-00002T02_.bmp\",\r\n    \" D:\\\\ADJ_VARO\\\\DATA\\\\IMAGE\\\\RWGE\\\\02\\\\09\\\\GT7AA1BKD23GWA_00_PR3_AMV49221110103125053QBM-26_20230208235852_RWGE-00002T02_(1).bmp\"\r\n  ],\r\n  \"REQUEST_INFO\": {\r\n    \"Image_Save_ADJ_Root_Path\": \"D:\\\\ADJ_VARO\\\\DATA\\\\IMAGE\\\\RWGE\\\\02\\\\09\\\\CROP\",\r\n    \"Image_Save_Review_Root_Path\": \"D:\\\\ADJ_VARO\\\\DATA\\\\IMAGE\\\\RWGE\\\\02\\\\09\\\\REVIEW\"\r\n  }\r\n}\r\n";
    }
}