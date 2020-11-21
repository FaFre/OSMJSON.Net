namespace OSMJSON.Net.Entities
{
    public class Node : Element
    {
        public double Lon { get; set; }
        public double Lat { get; set; }

        public Node(ElementTypes? type, ulong? id) : base(type, id)
        {
        }
    }
}