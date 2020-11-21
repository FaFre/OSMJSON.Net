using System;
using Newtonsoft.Json;

namespace OSMJSON.Net.Entities
{
    public class OSM3SInfo
    {
        [JsonProperty("timestamp_osm_base", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? OsmTimestamp { get; set; }
        [JsonProperty("copyright", NullValueHandling = NullValueHandling.Ignore)]
        public string? Copyright { get; set; }
    }
}