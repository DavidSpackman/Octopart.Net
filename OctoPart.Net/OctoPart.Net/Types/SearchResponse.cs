using System.Collections.Generic;

namespace OctoPart.Net
{
    public class SearchResponse
    {
        public string __class__ { get; set; }
        public SearchRequest request { get; set; }
        public IList<SearchResult> results { get; set; }
        public int msec { get; set; }
        public int hits { get; set; }
    }
}