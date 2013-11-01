namespace OctoPart.Net
{
    public class QuantitativeValue : AbstractQValue
    {
        public string __class__ { get; set; }
        public string min_value { get; set; }
        public string max_value { get; set; }
        public UnitOfMeasurement unit { get; set; }
        public Attribution attribution { get; set; }
    }
}