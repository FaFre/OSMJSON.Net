using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OSMJSON.Net.Entities
{
    public enum ElementTypes : byte
    {
        Node = 1,
        Way,
        Relation
    }

    public class Element
    {
        public ElementTypes Type { get; }
        public long Id { get; }
        public IReadOnlyDictionary<string, string>? Tags { get; set; }
        public DateTime? Timestamp { get; set; }
        public int? Version { get; set; }
        public int? Changeset { get; set; }
        public string? User { get; set; }
        [JsonPropertyName("uid")]
        public ulong? UId { get; set; }

        public Element(ElementTypes type, long id)
        {
            Type = type;
            Id = id;
        }
    }
}