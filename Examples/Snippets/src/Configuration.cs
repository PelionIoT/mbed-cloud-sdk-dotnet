using System;
using System.Linq;
using System.Threading;
using MbedCloudSDK.Common;
using MbedCloudSDK.Common.Filter.Maps;
using MbedCloudSDK.Common.Query;
using MbedCloudSDK.Connect.Api;
using MbedCloudSDK.Connect.Api.Subscribe.Models;
using MbedCloudSDK.DeviceDirectory.Api;

namespace Snippets.src
{
    public class configuration
    {
        public void Configuration()
        {
            // an example: configuring the SDK
            var config = new Config("An MbedCloud Api  Key", "custom host url");

            var deviceDirectory = new DeviceDirectoryApi(config);
            // end of example
        }
    }
}