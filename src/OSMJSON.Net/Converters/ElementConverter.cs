using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OSMJSON.Net.Entities;

namespace OSMJSON.Net.Converters
{
    public class ElementConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.Null:
                    return null;
                case JsonToken.StartObject:
                    var value = JObject.Load(reader);
                    return _readElement(value);
                case JsonToken.StartArray:
                    var values = JArray.Load(reader);
                    var elements = new List<Element>(values.Count);
                    elements.AddRange(values.Cast<JObject>().Select(_readElement));
                    return elements;
            }

            return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
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
            }

            return null;
        }
    }
}