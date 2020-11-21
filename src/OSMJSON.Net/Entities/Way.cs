using System.Collections.Generic;

namespace OSMJSON.Net.Entities
{
    public class Way : Element
    {
        public IReadOnlyCollection<ulong>? Nodes { get; set; }

        public Way(ElementTypes? type, ulong? id) : base(type, id)
        {
        }
    }
}