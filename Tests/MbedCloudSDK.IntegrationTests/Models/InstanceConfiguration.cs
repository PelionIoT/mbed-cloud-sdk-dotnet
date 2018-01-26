using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MbedCloudSDK.IntegrationTests.Models
{
    public class InstanceConfiguration : DictionaryBase
    {
        [JsonProperty("api_key")]
        public string ApiKey { get; set; }
        [JsonProperty("host")]
        public string Host { get; set; }
        [JsonProperty("autostart_daemon")]
        public bool AutostartDaemon { get; set; }

        public Hashtable GetHashtable()
        {
            return this.InnerHashtable;
        }

        public void ReverseMap()
        {
            if (InnerHashtable.Count > 0)
            {
                ApiKey = Convert.ToString(InnerHashtable["api_key"]);
                Host = Convert.ToString(InnerHashtable["host"]);
                AutostartDaemon = Convert.ToBoolean(InnerHashtable["autostart_daemon"]);
            }
        }
    }
}