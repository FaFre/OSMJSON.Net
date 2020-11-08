using System;
using Newtonsoft.Json;

namespace OSMJSON.Net.Entities
{
    public class Node : Element
    {
        public DateTime? Timestamp { get; set; }
        public int Version { get; set; }
        public int Changeset { get; set; }
        public string User { get; set; }
        [JsonProperty("uid")]
        public ulong UId { get; set; }
        public Node(ElementTypes type, ulong id) : base(type, id)
        {
        }
    }
}