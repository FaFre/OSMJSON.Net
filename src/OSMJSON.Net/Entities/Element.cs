using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OSMJSON.Net.Entities
{
    public enum ElementTypes { Node, Way, Relation }

    public class Element
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ElementTypes Type { get; }
        public ulong Id { get; }
        public IReadOnlyDictionary<string, string>? Tags { get; set; }
        public DateTime? Timestamp { get; set; }
        public int? Version { get; set; }
        public int? Changeset { get; set; }
        public string? User { get; set; }
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