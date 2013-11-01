using System.Collections.Generic;
using Newtonsoft.Json;

namespace OctoPart.Net
{
    public class GetMulti
    {
        [JsonConverter(typeof(EndPointSerializer))]
        public Dictionary<string, Dictionary<string, Endpoint>> item { get; set; }
    }
}