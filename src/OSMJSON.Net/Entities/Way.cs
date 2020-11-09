using System.Collections.Generic;
using Newtonsoft.Json;

namespace OSMJSON.Net.Entities
{
    public class Way : Element
    {
        [JsonProperty("nodes", NullValueHandling = NullValueHandling.Ignore)]
        public List<ulong> Nodes { get; set; }

        public Way(ElementTypes? type, ulong? id) : base(type, id)
        {
        }
    }
}