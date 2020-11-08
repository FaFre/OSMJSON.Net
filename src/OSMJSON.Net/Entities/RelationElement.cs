namespace OSMJSON.Net.Entities
{
    public class RelationElement
    {
        public ElementTypes Type { get; }
        public ulong Id { get; }
        public ulong Ref { get; set; }
        public string Role { get; set; }

        public RelationElement(ElementTypes type, ulong id)
        {
            Type = type;
            Id = id;
        }
    }
}