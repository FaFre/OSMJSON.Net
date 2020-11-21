using System.Text.Json.Serialization;

namespace OSMJSON.Net.Entities
{
    public class RelationElement
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ElementTypes Type { get; }
        public ulong? Ref { get; set; }
        public string? Role { get; set; }

        public RelationElement(ElementTypes? type)
        {
            if (!type.HasValue)
                throw new System.Exception("Element type is required");

            Type = type.Value;
        }
    }
}