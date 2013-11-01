using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OctoPart.Net
{
    public class PartOffer
    {
        public string __class__ { get; set; }
        public string sku { get; set; }
        public Seller seller { get; set; }
        public string product_url { get; set; }
        public Dictionary<string, IList<IList<object>>> prices { get; set; }
        public int in_stock_quantity { get; set; }
        public object on_order_quantity { get; set; }
        public object on_order_eta { get; set; }
        public int? factory_lead_days { get; set; }
        public object factory_order_multiple { get; set; }
        public int? order_multiple { get; set; }
        public int? moq { get; set; }
        public string last_updated { get; set; }
        public string packaging { get; set; }
        public bool is_authorized { get; set; }
    }
}
