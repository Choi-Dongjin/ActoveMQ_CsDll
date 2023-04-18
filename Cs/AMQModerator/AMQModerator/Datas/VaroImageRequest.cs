using System.Collections.Generic;

namespace AMQModerator.Datas
{
    public struct VaroImageRequest
    {
        public string DefectItem { get; set; }
        public string CROP_ROOT_PATH { get; set; }
        public List<string> CROP_PATH_LIST { get; set; }
    }
}