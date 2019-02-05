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
            ApiKey = Convert.ToString(InnerHashtable["api_key"]) ?? Environment.GetEnvironmentVariable("MBED_CLOUD_SDK_API_KEY");
            Host = Convert.ToString(InnerHashtable["host"]) ?? Environment.GetEnvironmentVariable("MBED_CLOUD_SDK_HOST");
            AutostartDaemon = Convert.ToBoolean(InnerHashtable["autostart_daemon"]);

            if (string.IsNullOrEmpty(ApiKey))
            {
                ApiKey = Environment.GetEnvironmentVariable("MBED_CLOUD_SDK_API_KEY");
            }

            if (string.IsNullOrEmpty(Host))
            {
                Host = Environment.GetEnvironmentVariable("MBED_CLOUD_SDK_HOST");
            }
        }
    }
}