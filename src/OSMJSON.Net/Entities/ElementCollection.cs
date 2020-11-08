using System.Collections.Generic;

namespace OSMJSON.Net.Entities
{
    public class ElementCollection
    {
        public float Version { get; set; }
        public string Generator { get; set; }
        public OSM3SInfo OSM3S { get; set; }
        public List<Element> MyProperty { get; set; }
    }
}