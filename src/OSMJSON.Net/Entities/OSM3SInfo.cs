using System;
using Newtonsoft.Json;

namespace OSMJSON.Net.Entities
{
    public class OSM3SInfo
    {
        [JsonProperty("timestamp_osm_base")]
        public DateTime? OsmTimestamp { get; set; }
        public string Copyright { get; set; }
    }
}