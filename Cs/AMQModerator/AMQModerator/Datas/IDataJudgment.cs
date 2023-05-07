namespace AMQModerator.Datas
{
    public interface IDataJudgment : IDataMessage
    {
        /// <summary>
        /// 공장 정보
        /// </summary>
        string FACILITY { get; set; }

        /// <summary>
        /// 제품 구분
        /// </summary>
        string PRODUCT { get; set; }

        /// <summary>
        /// 설비 ID
        /// </summary>
        string MACHINE_ID { get; set; }

        /// <summary>
        /// 공정 /CWLA, CFA, RWGE
        /// </summary>
        string PROCESS_CODE { get; set; }

        /// <summary>
        /// lot ID
        /// </summary>
        string LOT_ID { get; set; }

        /// <summary>
        /// 판넬 ID
        /// </summary>
        string PANEL_ID { get; set; }

        /// <summary>
        /// CWLA / LINER IDCFA
        /// RWGW / 패널 ID - POKET 넘버
        /// </summary>
        string MODULE_ID { get; set; }

        /// <summary>
        /// SYNAPSE_IMAGING
        /// VARO_IMAGE_AI
        /// VARO_VISION_ANOMALY
        /// VARO_DATA_AI
        /// </summary>
        string JUDGE_SERVICE_TYPE { get; set; }

/// <summary>
        /// IMAGE_AI : DEFECT_NAME
        /// SYNAPSE : SYNAPSE_RULE_INSPECTION, SYNAPSE_GV_EXTRACTION
        /// </summary>
        string SUB_JUDGE_SERVICE_TYPE { get; set; }
    }
}