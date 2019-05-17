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
            var billingApi = new BillingApi(new Config());
            Console.WriteLine($"Quota remaining: {billingApi.GetQuotaRemaining()}");
        }
    }
}