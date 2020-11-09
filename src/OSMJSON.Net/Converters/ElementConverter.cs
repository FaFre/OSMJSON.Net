using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OSMJSON.Net.Entities;

namespace OSMJSON.Net.Converters
{
    public class ElementConverter : JsonConverter<Element>
    {
        public override Element ReadJson(JsonReader reader, Type objectType, Element existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return _readElement(JObject.Load(reader));
        }

        public override void WriteJson(JsonWriter writer, Element value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }

        private Element _readElement(JObject value)
        {
            string toCamelCase(string input)
            {
                if (string.IsNullOrEmpty(input))
                    return input;

                return Char.ToUpper(input.First()) + input.Substring(1);
            };

            if (value.TryGetValue("type", StringComparison.InvariantCultureIgnoreCase, out var typeToken))
            {
                if (Enum.TryParse<ElementTypes>(toCamelCase(typeToken.Value<string>()), out var type))
                {
                    switch (type)
                    {
                        case ElementTypes.Node:
                            return value.ToObject<Node>();
                        case ElementTypes.Way:
                            return value.ToObject<Way>();
                        case ElementTypes.Relation:
                            return value.ToObject<Relation>();
                    }
                }
                else
                {
                    throw new JsonException("Unknown Element-type");
                }
            }
            else
            {
                throw new JsonException("The type property is necessary for all Elements");
            }

            return null;
        }
    }
}