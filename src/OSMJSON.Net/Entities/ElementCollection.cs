using System.Collections.Generic;
using Newtonsoft.Json;
using OSMJSON.Net.Converters;

namespace OSMJSON.Net.Entities
{
    public class ElementCollection
    {
        [JsonProperty("version")]
        public string? Version { get; set; }
        [JsonProperty("generator")]
        public string? Generator { get; set; }
        [JsonProperty("osm3s", NullValueHandling = NullValueHandling.Ignore)]
        public OSM3SInfo? OSM3S { get; set; }
        [JsonProperty("copyright", NullValueHandling = NullValueHandling.Ignore)]
        public string? Copyright { get; set; }
        [JsonProperty("attribution", NullValueHandling = NullValueHandling.Ignore)]
        public string? Attribution { get; set; }
        [JsonProperty("license", NullValueHandling = NullValueHandling.Ignore)]
        public string? License { get; set; }
        [JsonProperty("elements", ItemConverterType = typeof(ElementConverter))]
        public IReadOnlyCollection<Element>? Elements { get; set; }
    }
}