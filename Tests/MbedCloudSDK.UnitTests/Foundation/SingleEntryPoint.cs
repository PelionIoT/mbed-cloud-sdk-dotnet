using MbedCloudSDK.Common;
using NUnit.Framework;

namespace MbedCloudSDK.UnitTests.Foundation
{
    [TestFixture]
    public class SingleEntryPoint
    {
        // [Test]
        // public void GlobalConfig()
        // {
        //     var sdk = new SDK();
        //     Assert.IsNotNull(sdk.GetConfig());
        //     Assert.IsInstanceOf(typeof(string), sdk.GetConfig().ApiKey);
        // }

        // [Test]
        // public void GlobalConfigOnEntity()
        // {
        //     var user = new User();
        //     Assert.IsNotNull(user.Config);
        //     Assert.IsInstanceOf(typeof(string), user.Config.ApiKey);
        // }

        // [Test]
        // public void SDKInstance()
        // {
        //     var sdk = new SDK("ak_1");
        //     Assert.AreEqual("ak_1", sdk.GetConfig().ApiKey);

        //     var user = sdk.User();
        //     Assert.AreEqual("ak_1", user.Config.ApiKey);
        // }

        // [Test]
        // public void MultipleSDKInstances()
        // {
        //     var sdk1 = new SDK("ak_1");
        //     Assert.AreEqual("ak_1", sdk1.GetConfig().ApiKey);

        //     var sdk2 = new SDK("ak_2");
        //     Assert.AreEqual("ak_2", sdk2.GetConfig().ApiKey);
        // }

        // [Test]
        // public void ReusableConfig()
        // {
        //     var config = new Config("ak_1");
        //     var sdk = new SDK(config);

        //     Assert.AreEqual("ak_1", sdk.GetConfig().ApiKey);

        //     var user = sdk.User();
        //     Assert.AreEqual("ak_1", user.Config.ApiKey);

        //     var sdk2 = new SDK(config);
        //     Assert.AreEqual("ak_1", sdk.GetConfig().ApiKey);

        //     var user2 = new User(config);
        //     Assert.AreEqual("ak_1", user2.Config.ApiKey);
        // }
    }
}