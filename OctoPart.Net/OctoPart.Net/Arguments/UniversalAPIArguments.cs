using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OctoPart.Net
{
    public class UniversalAPIArguments
    {
        public string callback { get; set; }
        public bool pretty_print { get; set; }
        public bool suppress_status_codes { get; set; }
        public string apikey { get; set; }
    }
}
