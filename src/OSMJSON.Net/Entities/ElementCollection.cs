using System.Collections.Generic;
using Newtonsoft.Json;
using OSMJSON.Net.Converters;

namespace OSMJSON.Net.Entities
{
    public class ElementCollection
    {
        public float Version { get; set; }
        public string Generator { get; set; }
        public OSM3SInfo OSM3S { get; set; }
        public string Copyright { get; set; }
        public string Attribution { get; set; }
        public string License { get; set; }

        [JsonConverter(typeof(ElementConverter))]
        public List<Element> Elements { get; set; }
    }
}