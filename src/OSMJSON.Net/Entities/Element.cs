using System.Collections.Generic;

namespace OSMJSON.Net.Entities
{
    public enum ElementTypes { Node, Way, Relation }

    public class Element
    {
        public ElementTypes Type { get; }
        public ulong Id { get; }
        public double Long { get; set; }
        public double Lat { get; set; }
        public Dictionary<string, string> Tags { get; set; }

        public Element(ElementTypes type, ulong id)
        {
            Type = type;
            Id = id;
        }
    }
}