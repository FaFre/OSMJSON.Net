using System.IO;
using Xunit;

namespace OSMJSON.Net.Test
{
    public class OSMJSONTest
    {
        [Fact]
        public void DeserializeOSMJSONTest()
        {
            var json = File.ReadAllText("./Fixtures/osmSampleData.json");
            var deserialized = OSMJSON.Deserialize(json);
        }

        [Fact]
        public void DeserializeOverpassJSONTest()
        {
            var json = File.ReadAllText("./Fixtures/overpassMixed.json");
            var deserialized = OSMJSON.Deserialize(json);
        }
    }
}