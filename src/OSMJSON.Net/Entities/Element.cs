using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace OSMJSON.Net.Entities
{
    public enum ElementTypes { Node, Way, Relation }

    public class Element
    {
        [JsonConverter(typeof(StringEnumConverter), typeof(CamelCaseNamingStrategy))]
        [JsonProperty("type")]
        public ElementTypes Type { get; }
        [JsonProperty("id")]
        public ulong Id { get; }
        [JsonProperty("tags", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, string> Tags { get; set; }
        [JsonProperty("timestamp", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? Timestamp { get; set; }
        [JsonProperty("version", NullValueHandling = NullValueHandling.Ignore)]
        public int? Version { get; set; }
        [JsonProperty("changeset", NullValueHandling = NullValueHandling.Ignore)]
        public int? Changeset { get; set; }
        [JsonProperty("user", NullValueHandling = NullValueHandling.Ignore)]
        public string User { get; set; }
        [JsonProperty("uid", NullValueHandling = NullValueHandling.Ignore)]
        public ulong? UId { get; set; }

        public Element(ElementTypes? type, ulong? id)
        {
            if (!id.HasValue)
                throw new System.Exception("Id is required");

            if (!type.HasValue)
                throw new System.Exception("Element type is required");

            Type = type.Value;
            Id = id.Value;
        }
    }
}