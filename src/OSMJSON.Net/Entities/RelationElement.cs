using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace OSMJSON.Net.Entities
{
    public class RelationElement
    {
        [JsonConverter(typeof(StringEnumConverter), typeof(CamelCaseNamingStrategy))]
        [JsonProperty("type")]
        public ElementTypes Type { get; }
        [JsonProperty("ref")]
        public ulong? Ref { get; set; }
        [JsonProperty("role")]
        public string? Role { get; set; }

        public RelationElement(ElementTypes? type)
        {
            if (!type.HasValue)
                throw new System.Exception("Element type is required");

            Type = type.Value;
        }
    }
}