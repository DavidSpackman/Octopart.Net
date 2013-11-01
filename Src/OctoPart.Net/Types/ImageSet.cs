namespace OctoPart.Net
{
    public class ImageSet
    {
        public string __class__ { get; set; }
        public Asset swatch_image { get; set; }
        public Asset small_image { get; set; }
        public Asset medium_image { get; set; }
        public Asset large_image { get; set; }
        public Attribution attribution { get; set; }
    }
}