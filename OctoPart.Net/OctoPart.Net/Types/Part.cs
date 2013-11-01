using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OctoPart.Net
{
    public class Part : Endpoint
    {
        public long uid_v2 { get; set; }
        public string mpn { get; set; }
        public Manufacturer manufacturer { get; set; }
        public Brand brand { get; set; }
        public string octopart_url { get; set; }
        public IList<PartOffer> offers { get; set; }
        public IList<Datasheet> datasheets { get; set; }
        public IList<ComplianceDocument> compliance_documents { get; set; }
        public IList<Description> descriptions { get; set; }
        public IList<ImageSet> imagesets { get; set; }
        public ExternalLinks external_links { get; set; }
        public IList<string> category_uids { get; set; }
        public Dictionary<string, AbstractQValue> specs { get; set; }
    }
}
