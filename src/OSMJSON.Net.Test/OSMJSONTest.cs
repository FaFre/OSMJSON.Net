using System.IO;
using JsonDiffPatchDotNet;
using Newtonsoft.Json.Linq;
using OSMJSON.Net.Entities;
using Xunit;
using Xunit.Abstractions;

namespace OSMJSON.Net.Test
{
    public class OSMJSONTest
    {
        private readonly ITestOutputHelper output;

        private bool _reserializationTest(string file)
        {
            var json = File.ReadAllText(file);
            var deserialized = OSMJSON.Deserialize(json);
            var reserialized = OSMJSON.Serialize(deserialized);

            var diff = new JsonDiffPatch();
            var a = JToken.Parse(json);
            var b = JToken.Parse(reserialized);

            var result = diff.Diff(a, b);
            if (result != null)
            {
                output.WriteLine($"Json not equal for file {file}: {result}");
                return false;
            }

            return true;
        }

        public OSMJSONTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void DeserializeOSMJSONTest()
        {
            Assert.True(_reserializationTest("./Fixtures/osmSampleData.json"));
        }

        [Fact]
        public void DeserializeOverpassJSONTest()
        {
            Assert.True(_reserializationTest("./Fixtures/overpassMixed.json"));
        }
    }
}