using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using OSMJSON.Net.Entities;

namespace OSMJSON.Net
{
    public static class OSMJSON
    {
        private static readonly DefaultContractResolver _contractResolver = new DefaultContractResolver
        {
            NamingStrategy = new CamelCaseNamingStrategy
            {
                OverrideSpecifiedNames = false
            }
        };

        public static ElementCollection Deserialize(string json, JsonSerializerSettings settings = null)
        {
            settings = settings ?? new JsonSerializerSettings()
            {
                ContractResolver = _contractResolver
            };

            return JsonConvert.DeserializeObject<ElementCollection>(json, settings);
        }
    }
}