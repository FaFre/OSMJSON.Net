using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using OSMJSON.Net.Entities;
using OSMJSON.Net.Extension;

namespace OSMJSON.Net.Converters
{
    internal class ElementConverter : JsonConverter<Element>
    {
        public override Element? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return _readElement(JsonDocument.ParseValue(ref reader), options) ?? new Element(ElementTypes.Node, -1);
        }

        public override void Write(Utf8JsonWriter writer, Element value, JsonSerializerOptions options)
        {
            var writeOptions = new JsonSerializerOptions(options);

            var recursiveConverter = writeOptions.Converters.FirstOrDefault(x => x is ElementConverter);
            if (recursiveConverter != null)
                writeOptions.Converters.Remove(recursiveConverter);

            switch (value)
            {
                case Node node:
                    JsonSerializer.Serialize(writer, node, writeOptions);
                    break;
                case Way way:
                    JsonSerializer.Serialize(writer, way, writeOptions);
                    break;
                case Relation relation:
                    JsonSerializer.Serialize(writer, relation, writeOptions);
                    break;
                default:
                    JsonSerializer.Serialize(writer, value, writeOptions);
                    break;
            };
        }

        private Element? _readElement(JsonDocument value, JsonSerializerOptions options)
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
                            return value.ToObject<Node>(options);
                        case ElementTypes.Way:
                            return value.ToObject<Way>(options);
                        case ElementTypes.Relation:
                            return value.ToObject<Relation>(options);
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