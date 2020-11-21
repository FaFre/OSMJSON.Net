using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using OSMJSON.Net.Entities;
using OSMJSON.Net.Extension;

namespace OSMJSON.Net.Converters
{
    public class ElementConverter : JsonConverter<Element>
    {
        public override Element? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return _readElement(JsonDocument.ParseValue(ref reader)) ?? new Element(null, null);
        }

        public override void Write(Utf8JsonWriter writer, Element value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value);
        }

        private Element? _readElement(JsonDocument value)
        {
            string? toCamelCase(string? input)
            {
                if (string.IsNullOrEmpty(input))
                    return null;

                return Char.ToUpper(input.First()) + input.Substring(1);
            };

            if (value.RootElement.TryGetProperty("type", out var typeElement))
            {
                if (Enum.TryParse<ElementTypes>(toCamelCase(typeElement.GetString()), out var type))
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