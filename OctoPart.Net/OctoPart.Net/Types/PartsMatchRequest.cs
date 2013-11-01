using System.Collections.Generic;

namespace OctoPart.Net
{
    public class PartsMatchRequest
    {
        public string __class__ { get; set; }
        public IList<PartsMatchQuery> queries { get; set; }
        public bool exact_only { get; set; }
    }
}