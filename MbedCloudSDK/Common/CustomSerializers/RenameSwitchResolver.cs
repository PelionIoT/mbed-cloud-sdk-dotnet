using System;
using System.Collections.Generic;
using Newtonsoft.Json.Serialization;

namespace MbedCloudSDK.Common.CustomSerializers
{
    public sealed class RenameSwitchResolver : DefaultContractResolver
    {
        private Dictionary<Type, Dictionary<string, string>> renames;
        public RenameSwitchResolver(Dictionary<Type, Dictionary<string, string>> renames = null)
        {
            this.renames = renames ?? new Dictionary<Type, Dictionary<string, string>>();
        }
        protected override JsonContract CreateContract(Type objectType)
        {
            if (renames.ContainsKey(objectType))
            {
                NamingStrategy = new SnakeCaseNamingStrategyWithRenaming(renames[objectType]);
            }
            else
            {
                if (NamingStrategy == null)
                {
                    NamingStrategy = new SnakeCaseNamingStrategy();
                }
            }

            return base.CreateContract(objectType);
        }
    }
}