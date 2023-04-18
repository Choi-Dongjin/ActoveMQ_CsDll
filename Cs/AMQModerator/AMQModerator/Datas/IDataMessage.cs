namespace AMQModerator.Datas
{
    public interface IDataMessage
    {
        /// <summary>
        /// 메시지 사용 버전
        /// </summary>
        string Version { get; set; }

        /// <summary>
        /// 메시지 명 Type
        /// </summary>
        string MessageName { get; set; }

        /// <summary>
        /// 메시지에 대한 설명
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// 수진 측 Subject
        /// </summary>
        string ConsumerAddr { get; set; }

        /// <summary>
        /// 수신 측 DestinationType (0 – Queue, 1 – Topic)
        /// </summary>
        int ConsumerDestinationType { get; set; }

        /// <summary>
        /// 발신측 Subject
        /// </summary>
        string ProducerAddr { get; set; }

        /// <summary>
        /// 발신 측 DestinationType (0 – Queue, 1 – Topic)
        /// </summary>
        int ProducerDestinationType { get; set; }

        /// <summary>
        /// 트랜잭션 ID
        /// </summary>
        string TransID { get; set; }
    }
}