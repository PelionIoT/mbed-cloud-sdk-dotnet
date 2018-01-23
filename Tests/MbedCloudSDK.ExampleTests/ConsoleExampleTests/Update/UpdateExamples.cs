using MbedCloudSDK.Common;
using MbedCloudSDK.ExampleTests;
using NUnit.Framework;
using System;

namespace MbedCloudSDK.Test.ConsoleExampleTests.Update
{
    [TestFixture]
    public class UpdateExamples
    {
        [OneTimeSetUp]
        public void Init()
        {
            SetEnvironment.SetEnvironmentVariables();
        }

        [Test]
        public void CreateUpdateCampaign()
        {
            var key = Environment.GetEnvironmentVariable("MBED_CLOUD_API_KEY");
            var host = Environment.GetEnvironmentVariable("MBED_CLOUD_HOST");
            var config = new Config(key, host);
            var createUpdateCampaign = new ConsoleExamples.Examples.Update.UpdateExamples(config);
            var campaign = createUpdateCampaign.CreateCampaign();
            Assert.NotNull(campaign);
        }

        [Test]
        public void ListFirmwareImages()
        {
            var key = Environment.GetEnvironmentVariable("MBED_CLOUD_API_KEY");
            var host = Environment.GetEnvironmentVariable("MBED_CLOUD_HOST");
            var config = new Config(key, host);
            var listImages = new ConsoleExamples.Examples.Update.UpdateExamples(config);
            var images = listImages.ListImages();
            Assert.IsNotEmpty(images);
        }

        [Test]
        public void ListFirmwareManifests()
        {
            var key = Environment.GetEnvironmentVariable("MBED_CLOUD_API_KEY");
            var host = Environment.GetEnvironmentVariable("MBED_CLOUD_HOST");
            var config = new Config(key, host);
            var listManifests = new ConsoleExamples.Examples.Update.UpdateExamples(config);
            var manifests = listManifests.ListManifests();
            Assert.IsNotEmpty(manifests);
        }

        [Test]
        public void ListUpdateCampaigns()
        {
            var key = Environment.GetEnvironmentVariable("MBED_CLOUD_API_KEY");
            var host = Environment.GetEnvironmentVariable("MBED_CLOUD_HOST");
            var config = new Config(key, host);
            var listCampaigns = new ConsoleExamples.Examples.Update.UpdateExamples(config);
            var campaigns = listCampaigns.ListCampaigns();
            Assert.IsNotEmpty(campaigns);
        }
    }
}