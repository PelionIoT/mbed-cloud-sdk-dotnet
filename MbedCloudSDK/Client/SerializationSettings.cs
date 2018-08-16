using System.Collections.Generic;
using MbedCloudSDK.Common.CustomSerializers;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MbedCloudSDK.Client
{
    public static class SerializationSettings
    {
        public static JsonSerializerSettings GetSettings(Dictionary<string, string> renames)
        {
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new SnakeCaseNamingStrategyWithRenaming(renames),
                },
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
            };

            return settings;
        }
    }
}