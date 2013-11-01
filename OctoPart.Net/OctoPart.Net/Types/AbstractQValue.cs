using System.Collections.Generic;
using Newtonsoft.Json;

namespace OctoPart.Net
{
    [JsonConverter(typeof(QValueJsonConverter))]
    public class AbstractQValue
    {
        
        public IList<string> value { get; set; }
    }
}