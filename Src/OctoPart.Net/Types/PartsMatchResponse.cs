using System.Collections.Generic;

namespace OctoPart.Net
{
    public class PartsMatchResponse
    {
        public PartsMatchRequest request { get; set; }
        public IList<PartsMatchResult> results { get; set; }
        public int msec { get; set; }
    }
}