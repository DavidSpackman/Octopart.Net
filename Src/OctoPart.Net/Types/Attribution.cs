using System.Collections.Generic;

namespace OctoPart.Net
{
    public class Attribution
    {
        public string __class__ { get; set; }
        public string first_acquired { get; set; }
        public IList<Source> sources { get; set; }
    }
}