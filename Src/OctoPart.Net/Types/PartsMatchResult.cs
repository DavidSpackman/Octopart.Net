using System.Collections.Generic;

namespace OctoPart.Net
{
    public class PartsMatchResult
    {
        public string __class__ { get; set; }
        public IList<Part> items { get; set; }
        public int hits { get; set; }
        public string reference { get; set; }
        public string error { get; set; }
    }
}