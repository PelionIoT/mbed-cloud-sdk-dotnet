using System.Collections.Generic;
using Newtonsoft.Json.Serialization;

namespace MbedCloudSDK.Common.CustomSerializers
{
    public sealed class SnakeCaseNamingStrategyWithRenaming : SnakeCaseNamingStrategy
    {
        private Dictionary<string, string> PropertyMappings { get; set; }

        public SnakeCaseNamingStrategyWithRenaming(Dictionary<string, string> mappings)
        {
            this.PropertyMappings = mappings;
        }

        protected override string ResolvePropertyName(string propertyName)
        {
            string resolvedName = null;
            var resolved = this.PropertyMappings.TryGetValue(propertyName, out resolvedName);
            return (resolved) ? resolvedName : base.ResolvePropertyName(propertyName);
        }
    }
}