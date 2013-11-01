namespace OctoPart.Net
{
    public class Category : Endpoint
    {
        public string name { get; set; }
        public string parent_uid { get; set; }
        public string children_uids { get; set; }
        public string ancestor_uids { get; set; }
    }
}