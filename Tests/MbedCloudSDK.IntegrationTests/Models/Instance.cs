using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MbedCloudSDK.IntegrationTests.Models
{
    public class Instance
    {
        public string Id { get; set; }
        [JsonConverter(typeof(ModuleEnumConverter))]
        public ModuleEnum Module { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}