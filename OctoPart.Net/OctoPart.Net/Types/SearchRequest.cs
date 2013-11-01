namespace OctoPart.Net
{
    public class SearchRequest
    {
        public string __class__ { get; set; }
        public string q { get; set; }
        public int start { get; set; }
        public int limit { get; set; }
        public string sortby { get; set; }
        //public string filter { get; set; }

        public SearchRequest()
        {
            q = "";
            start = 0;
            limit = 0;
            sortby = "";
        }
    }
}