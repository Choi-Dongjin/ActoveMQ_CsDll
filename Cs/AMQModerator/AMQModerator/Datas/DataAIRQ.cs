using System.Collections.Generic;

namespace AMQModerator.Datas
{
    public class DataAIRQ : IDataJudgment
    {
        public string Version { get; set; }
        public string MessageName { get; set; }
        public string Description { get; set; }
        public string ConsumerAddr { get; set; }
        public int ConsumerDestinationType { get; set; }
        public string ProducerAddr { get; set; }
        public int ProducerDestinationType { get; set; }
        public string TransID { get; set; }
        public string FACILITY { get; set; }
        public string PRODUCT { get; set; }
        public string MACHINE_ID { get; set; }
        public string PROCESS_CODE { get; set; }
        public string LOT_ID { get; set; }
        public string PANEL_ID { get; set; }
        public string MODULE_ID { get; set; }
        public string JUDGE_SERVICE_TYPE { get; set; }
        public string SUB_JUDGE_SERVICE_TYPE { get; set; }
        public List<string> IMAGE_PATH_LIST { get; set; }
        public DataAIRQRequestInfo REQUEST_INFO { get; set; }
    }
}