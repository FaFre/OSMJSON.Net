using System.Collections.Generic;
using OSMJSON.Net.Converters;

namespace OSMJSON.Net.Entities
{
    public class ElementCollection
    {
        public string? Version { get; set; }
        public string? Generator { get; set; }
        public OSM3SInfo? OSM3S { get; set; }
        public string? Copyright { get; set; }
        public string? Attribution { get; set; }
        public string? License { get; set; }
        public IReadOnlyCollection<Element>? Elements { get; set; }
    }
}