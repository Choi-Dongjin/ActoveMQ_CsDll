using System.Collections.Generic;

namespace AMQModerator.Datas
{
    public class SynapseRuleResult
    {
        public string RAW_IMAGE_PATH { get; set; }
        public string MODEL_NAME { get; set; }
        public string MODEL_VERSION { get; set; }
        public List<SYNAPSE_DEFECT_ITEM> SYNAPSE_DEFECT_ITEM_LIST { get; set; }
    }
}