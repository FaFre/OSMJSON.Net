using System.Text.Json;
using System.Text.Json.Serialization;
using OSMJSON.Net.Converters;
using OSMJSON.Net.Entities;

namespace OSMJSON.Net
{
    public static class OSMJSON
    {
        private static readonly JsonSerializerOptions _serializerOptions = new JsonSerializerOptions
        {
            IgnoreNullValues = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        static OSMJSON()
        {
            _serializerOptions.Converters.Add(new ElementConverter());
            _serializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
        }

        public static ElementCollection? Deserialize(string json)
        {
            return JsonSerializer.Deserialize<ElementCollection>(json, _serializerOptions);
        }

        public static string? Serialize(ElementCollection? elements)
        {
            return JsonSerializer.Serialize(elements, _serializerOptions);
        }
    }
}