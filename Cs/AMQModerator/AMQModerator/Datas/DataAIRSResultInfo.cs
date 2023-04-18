using System.Collections.Generic;

namespace AMQModerator.Datas
{
    public class DataAIRSResultInfo
    {
        public string SynapseProgramVersion { get; set; }
        public List<SynapseRuleResult> SynapseRuleResultList { get; set; }
        public string Image_Save_ADJ_Root_Path { get; set; }
        public string Image_Save_Review_Root_Path { get; set; }
    }
}