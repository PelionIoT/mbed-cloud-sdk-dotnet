using System;
using System.Collections.Generic;
using Mbed.Cloud.Common;
using MbedCloudSDK.Common;

namespace MbedCloudSDK.IntegrationTests.Models
{
    public class StubApi
    {
        public Config Config { get; private set; }

        public StubApi(Config config)
        {
            Config = config;
        }

        public string GetModuleName()
        {
            return "test_stub";
        }

        public void Exception()
        {
            throw new Exception("just a test");
        }

        public Dictionary<string, object> Success(string testArgument0, int testArgument1, string testArgument2, DateTime testArgument3)
        {
            var dict = new Dictionary<string, object>();
            dict.Add("test_argument0", testArgument0);
            dict.Add("test_argument1", testArgument1);
            dict.Add("test_argument2", testArgument2);
            dict.Add("test_argument3", testArgument3.AddDays(1));
            dict.Add("success", true);
            dict.Add("api_key", Config.ApiKey);
            dict.Add("host", Config.Host);
            return dict;
        }
    }
}