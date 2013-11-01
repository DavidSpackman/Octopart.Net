using System.Collections.Generic;

namespace OctoPart.Net
{
    public class Datasheet : Asset
    {
        public Attribution attribution { get; set; }
        public IList<string> subtypes { get; set; }
    }
}