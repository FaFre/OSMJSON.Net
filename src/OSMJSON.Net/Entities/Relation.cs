using System.Collections.Generic;
using Newtonsoft.Json;

namespace OSMJSON.Net.Entities
{
    public class Relation : Element
    {
        [JsonProperty("members", NullValueHandling = NullValueHandling.Ignore)]
        public IReadOnlyCollection<RelationElement>? Members { get; set; }

        public Relation(ElementTypes? type, ulong? id) : base(type, id)
        {
        }
    }
}