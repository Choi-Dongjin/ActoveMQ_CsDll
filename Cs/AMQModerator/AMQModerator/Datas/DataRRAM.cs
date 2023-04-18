using System;

namespace AMQModerator.Datas
{
    internal class DataRRAM : IDataMessage
    {
        public string Version { get; set; }
        public string MessageName { get; set; }
        public string Description { get; set; }
        public string ConsumerAddr { get; set; }
        public int ConsumerDestinationType { get; set; }
        public string ProducerAddr { get; set; }
        public int ProducerDestinationType { get; set; }
        public string TransID { get; set; }

        /// <summary>
        /// 발신 일시
        /// </summary>
        public DateTime TXN_DATE_TIME { get; set; }
    }
}