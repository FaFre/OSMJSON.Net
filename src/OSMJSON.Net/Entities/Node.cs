using Newtonsoft.Json;

namespace OSMJSON.Net.Entities
{
    public class Node : Element
    {
        [JsonProperty("lon")]
        public double Lon { get; set; }
        [JsonProperty("lat")]
        public double Lat { get; set; }

        public Node(ElementTypes? type, ulong? id) : base(type, id)
        {
        }
    }
}