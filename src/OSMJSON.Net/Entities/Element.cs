using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace OSMJSON.Net.Entities
{
    public enum ElementTypes { Node, Way, Relation }

    public class Element
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public ElementTypes Type { get; }
        public ulong Id { get; }
        public double Lon { get; set; }
        public double Lat { get; set; }
        public Dictionary<string, string> Tags { get; set; }

        public Element(ElementTypes type, ulong id)
        {
            Type = type;
            Id = id;
        }
    }
}