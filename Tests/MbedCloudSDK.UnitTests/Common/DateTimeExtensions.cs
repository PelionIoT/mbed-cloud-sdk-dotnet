using System;
using NUnit.Framework;
using MbedCloudSDK.Common.Extensions;

namespace MbedCloudSDK.UnitTests.Common
{
    [TestFixture]
    public class DateTimeExtensions
    {
        [Test]
        public void BillingMonthFormat()
        {
            var date = new DateTime(2018, 4, 1);
            Assert.AreEqual("2018-04", date.ToBillingMonth());

            date = new DateTime(2018, 11, 1);
            Assert.AreEqual("2018-11", date.ToBillingMonth());
        }
    }
}