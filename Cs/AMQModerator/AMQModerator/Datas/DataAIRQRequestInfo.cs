using System.Collections.Generic;

namespace AMQModerator.Datas
{
    public class DataAIRQRequestInfo
    {
        public string Image_Save_ADJ_Root_Path { get; set; }
        public string Image_Save_Review_Root_Path { get; set; }
        public List<VaroImageRequest> VARO_IMAGE_AI_Request_List { get; set; }
        public VaroImageRequest VARO_IMAGE_AI_Request { get; set; }
    }
}