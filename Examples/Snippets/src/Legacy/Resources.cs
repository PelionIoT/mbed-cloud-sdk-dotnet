using System;
using Mbed.Cloud.Common;
using MbedCloudSDK.Billing.Api;
using NUnit.Framework;

namespace Snippets.src.Legacy
{
    [TestFixture]
    public class LegacyResourceExamples
    {
        [Test]
        public void ReadingAResource()
        {
            // an example: legacy_get_resource
            // cloak
            /*
            // uncloak
            using Mbed.Cloud.Common;
            using MbedCloudSDK.Billing.Api;
            // cloak
            */
            // uncloak
            var billingApi = new BillingApi(new Config());
            Console.WriteLine($"Quota remaining: {billingApi.GetQuotaRemaining()}");
            // end of example

        }

        [Test]
        public void ListingAResource()
        {
            // an example: legacy_listing_resources
            // cloak
            /*
            // uncloak
            using Mbed.Cloud.Common;
            using MbedCloudSDK.Billing.Api;
            // cloak
            */
            // uncloak
            var billingApi = new BillingApi(new Config());
            foreach (var quotaHistory in billingApi.GetQuotaHistory())
            {
                Console.WriteLine($"Quota change reason: {quotaHistory.Reason}, delta: {quotaHistory.Delta}");
            }
            // end of example
        }
    }
}