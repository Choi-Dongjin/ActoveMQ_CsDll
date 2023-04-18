using System;

namespace AMQModerator.Datas
{
    public class DataEAYT_R : IDataMessage
    {
        public string Version { get; set; }
        public string MessageName { get; set; }
        public string Description { get; set; }
        public string ConsumerAddr { get; set; }
        public int ConsumerDestinationType { get; set; }
        public string ProducerAddr { get; set; }
        public int ProducerDestinationType { get; set; }
        public string TransID { get; set; }
        public DateTime TXN_DATE_TIME { get; set; }
        public string RTN_CD { get; set; }
        public string ERR_CD { get; set; }
        public string ERR_MSG { get; set; }
    }
}