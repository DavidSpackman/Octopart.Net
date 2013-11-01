using Newtonsoft.Json;

namespace OctoPart.Net
{
    public class SearchResult
    {
        [JsonConverter(typeof(EndPointSerializer))]
        public Endpoint item { get; set; }
    }
}