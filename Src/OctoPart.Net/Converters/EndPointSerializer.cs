using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace OctoPart.Net
{
    public class EndPointSerializer : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            //var properties = jo.Properties().ToList();
            if (jo["__class__"].ToString() == "Part")
            {
                return jo.ToObject<Part>();
            }
            else if (jo["__class__"].ToString() == "Brand")
            {
                return jo.ToObject<Brand>();
            }
            else if (jo["__class__"].ToString() == "Seller")
            {
                return jo.ToObject<Seller>();
            }
            else
            {
                return jo.ToObject<Category>();
            }
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(Endpoint).IsAssignableFrom(objectType);
        }
    }
}