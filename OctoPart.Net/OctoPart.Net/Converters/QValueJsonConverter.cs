using System;
using Newtonsoft.Json.Linq;

namespace OctoPart.Net
{
    public class QValueJsonConverter : JsonCreationConverter<AbstractQValue>
    {
        protected override AbstractQValue Create(Type objectType, JObject jObject)
        {
            if (jObject["__class__"].ToString() == "QuantitativeValue")
            {
                return new QuantitativeValue();
            }
            return new QualitativeValue();
            //return null;
        }

    }
}