using System;

namespace AMQModerator.Datas
{
    public class DataAIRS : IDataJudgment
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
        public string JUDGE_PROGRAM_ID { get; set; }
        public string RESULT { get; set; }
        public string ERROR_CODE { get; set; }
        public string ERROR_MESSAGE { get; set; }
        public string WORK_START_DATE { get; set; }
        public string WORK_TIME { get; set; }
        public string WAIT_TIME { get; set; }
        public DataAIRSResultInfo RESULT_INFO { get; set; }
    }
}