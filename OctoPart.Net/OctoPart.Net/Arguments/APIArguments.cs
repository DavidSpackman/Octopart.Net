using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OctoPart.Net
{

    public class APIArguments : UniversalAPIArguments 
    {

        public IList<string> ShowDirectives { get; set; }

        public IList<string> HideDirectives { get; set; }

        public bool datasheets { get; set; }

        public bool compliance_documents { get; set; }

        public bool descriptions { get; set; }

        public bool imagesets { get; set; }

        public bool specs { get; set; }

        public bool category_uids { get; set; }

        public bool external_links { get; set; }

        public bool eda_resources { get; set; }

        public APIArguments()
        {
            datasheets = false;
            compliance_documents = false;
            descriptions = false;
            imagesets = false;
            specs = false;
            category_uids = false;
            external_links = false;
            eda_resources = false;
            pretty_print = false;
            suppress_status_codes = false;
            HideDirectives = new List<string>();
            ShowDirectives = new List<string>();
        }
    }

    public class SearchAPIArguments : APIArguments
    {
        public string q { get; set; }

        public int start { get; set; }

        public int limit { get; set; }

        public string sortby { get; set; }

        public SearchAPIArguments()
        {
            q = "";
            start = 0;
            limit = 10;
            sortby = "score desc";
        }

    }

    public class GetMultiAPIArguments : APIArguments
    {
        public IList<string> uids { get; set; }

        public GetMultiAPIArguments()
        {
            uids = new List<string>();
        }

    }

}
