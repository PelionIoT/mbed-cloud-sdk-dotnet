using System;
using System.Collections.Generic;
using Mbed.Cloud.Common.Filters;
using Mbed.Cloud.Foundation;
using NUnit.Framework;
using Shouldly;

namespace MbedCloudSDK.UnitTests.Foundation.Filters
{
    [TestFixture]
    public class FilterTests
    {
        [Test]
        public void ShouldEncodeString()
        {
            var filter = new Filter();
            filter.AddFilterItem("name", new FilterItem("Badger"));

            var expectedValue = "Badger";
            filter.GetEncodedValue("name").ShouldBe(expectedValue);
        }

        [Test]
        public void ShouldEncodeNumber()
        {
            var filter = new Filter();
            filter.AddFilterItem("name", new FilterItem(-50));

            var expectedValue = -50;
            filter.GetEncodedValue("name").ShouldBe(expectedValue);
        }

        [Test]
        public void ShouldEncodeBool()
        {
            var filter = new Filter();
            filter.AddFilterItem("name", new FilterItem(true));

            var expectedValue = "true";
            filter.GetEncodedValue("name").ShouldBe(expectedValue);
        }

        [Test]
        public void ShouldEncodeDate()
        {
            var filter = new Filter();
            filter.AddFilterItem("name", new FilterItem(new DateTime(2019, 3, 7, 13, 33, 47)));
            
            var expectedValue = "2019-03-07T13:33:47.000Z";
            filter.GetEncodedValue("name").ShouldBe(expectedValue);
        }

        [Test]
        public void ShouldEncodeList()
        {
            var filter = new Filter();
            filter.AddFilterItem("name", new FilterItem(new [] { "Badger", "Gopher"}));

            var expectedValue = "Badger,Gopher";
            filter.GetEncodedValue("name").ShouldBe(expectedValue);
        }

        [Test]
        public void ShouldEncodeDictionary()
        {
            var filter = new Filter();
            filter.AddFilterItem("name", new FilterItem(new Dictionary<string, string>{{ "Animal", "Badger"}}));

            var expectedValue = "{\"Animal\":\"Badger\"}";
            filter.GetEncodedValue("name").ShouldBe(expectedValue);
        }

        [Test]
        public void ShouldEncodeNull()
        {
            var filter = new Filter();
            filter.AddFilterItem("name", new FilterItem(null));

            filter.GetEncodedValue("name").ShouldBe(null);
        }

        [Test]
        public void ShouldEncodeEntity()
        {
            var filter = new Filter();
            filter.AddFilterItem("name", new FilterItem(new User
            {
                Username = "TestUser",
                Id = "123456",
            }));

            var expectedValue = "123456";
            filter.GetEncodedValue("name").ShouldBe(expectedValue);
        }

    }
}