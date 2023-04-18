using System;

namespace AMQModerator.Datas
{
    public class DataEAYT : IDataMessage
    {
        public string Version { get; set; }
        public string MessageName { get; set; }
        public string Description { get; set; }
        public string ConsumerAddr { get; set; }
        public int ConsumerDestinationType { get; set; }
        public string ProducerAddr { get; set; }
        public int ProducerDestinationType { get; set; }
        public string TransID { get; set; }
        public int REPLY_REQ { get; set; }
        public DateTime TXN_DATE_TIME { get; set; }
    }
}