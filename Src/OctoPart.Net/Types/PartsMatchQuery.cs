namespace OctoPart.Net
{
    public class PartsMatchQuery
    {
        public string __class__ { get; set; }
        public string q { get; set; }
        public string mpn { get; set; }
        public string brand { get; set; }
        public string sku { get; set; }
        public string seller { get; set; }
        public string mpn_or_sku { get; set; }
        public int start { get; set; }
        public int limit { get; set; }
        public string reference { get; set; }

        public PartsMatchQuery()
        {
            q = "";
            sku = "";
            limit = 3;
            reference = "";
            mpn_or_sku = "";
            mpn = "";
            brand = "";
            start = 0;
            seller = "";
        }
    }
}