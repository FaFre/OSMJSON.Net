using System.Collections.Generic;

namespace OSMJSON.Net.Entities
{
    public class Relation : Element
    {
        public IReadOnlyCollection<RelationElement>? Members { get; set; }

        public Relation(ElementTypes? type, ulong? id) : base(type, id)
        {
        }
    }
}