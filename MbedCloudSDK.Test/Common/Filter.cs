using System;
using MbedCloudSDK.Common.Filter;
using MbedCloudSDK.Common.Filter.Maps;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace MbedCloudSDK.Test.Common.Filter
{
    [TestFixture]
    public class Filter
    {
        [Test]
        public void BlankFilterReturnsEmptyFilterString()
        {
            var filter = new MbedCloudSDK.Common.Filter.Filter();
            Assert.AreEqual(string.Empty, filter.FilterString);
        }

        [Test]
        public void BlankFilterWithEmptyStringReturnsEmptyFilterString()
        {
            var filter = new MbedCloudSDK.Common.Filter.Filter("");
            Assert.AreEqual(string.Empty, filter.FilterString);
        }

        [Test]
        public void BlankFilterWithEmptyJsonReturnsEmptyString()
        {
            var filter = new MbedCloudSDK.Common.Filter.Filter("{}");
            Assert.AreEqual(string.Empty, filter.FilterString);
        }

        [Test]
        public void BlankFilterReturnsEmptyJson()
        {
            var filter = new MbedCloudSDK.Common.Filter.Filter();
            Assert.AreEqual(default(JObject), filter.FilterJson);
        }

        [Test]
        public void ShouldEncodeFilter()
        {
            var filter = new MbedCloudSDK.Common.Filter.Filter();
            filter.Add("key", "value", FilterOperator.Equals);
            filter.Add("error", "found", FilterOperator.NotEqual);
            filter.Add("range", new FilterAttribute("10", FilterOperator.LessOrEqual), new FilterAttribute("2", FilterOperator.GreaterOrEqual));
            Assert.AreEqual("key=value&error__neq=found&range__lte=10&range__gte=2", filter.FilterString);
        }

        [Test]
        public void FilterReturnsCorrectJson()
        {
            var filter = new MbedCloudSDK.Common.Filter.Filter();
            filter.Add("key", "value", FilterOperator.Equals);
            filter.Add("error", "found", FilterOperator.NotEqual);
            filter.Add("range", new FilterAttribute("10", FilterOperator.LessOrEqual), new FilterAttribute("2", FilterOperator.GreaterOrEqual));
            Assert.AreEqual("{\"key\":{\"$eq\":\"value\"},\"error\":{\"$ne\":\"found\"},\"range\":{\"$lte\":\"10\",\"$gte\":\"2\"}}", filter.FilterJson.ToString(Formatting.None));
        }

        [Test]
        public void ShouldEncodeFilterAfterAddingWithSameKey()
        {
            var filter = new MbedCloudSDK.Common.Filter.Filter();
            filter.Add("key", "value", FilterOperator.Equals);
            filter.Add("error", "found", FilterOperator.NotEqual);
            filter.Add("range", "10", FilterOperator.LessOrEqual);
            filter.Add("range", "2", FilterOperator.GreaterOrEqual);
            Assert.AreEqual("key=value&error__neq=found&range__lte=10&range__gte=2", filter.FilterString);
        }

        [Test]
        public void ShouldEncodeBareFilter()
        {
            var filter = new MbedCloudSDK.Common.Filter.Filter();
            filter.Add("key", "value");
            filter.Add("error", "found", FilterOperator.NotEqual);
            filter.Add("range", new FilterAttribute("10", FilterOperator.LessOrEqual), new FilterAttribute("2", FilterOperator.GreaterOrEqual));
            Assert.AreEqual("key=value&error__neq=found&range__lte=10&range__gte=2", filter.FilterString);
        }

        [Test]
        public void ShouldEncodeFilterWithCustomAttributes()
        {
            var filter = new MbedCloudSDK.Common.Filter.Filter();
            filter.Add("key", "value", FilterOperator.Equals);
            filter.Add("error", "found", FilterOperator.NotEqual);
            filter.Add("range", new FilterAttribute("10", FilterOperator.LessOrEqual), new FilterAttribute("2", FilterOperator.GreaterOrEqual));
            filter.AddCustom("custom_1", new FilterAttribute("custom_value_1", FilterOperator.Equals));
            filter.AddCustom("custom_2", "custom_value_2", FilterOperator.NotEqual);
            Assert.AreEqual("key=value&error__neq=found&range__lte=10&range__gte=2&custom_attribute__custom_1=custom_value_1&custom_attribute__custom_2__neq=custom_value_2", filter.FilterString);
        }

        [Test]
        public void ShouldEncodeFilterWithMappedFields()
        {
            var filter = new MbedCloudSDK.Common.Filter.Filter();
            filter.Add(DeviceFilterMapEnum.Alias, "value", FilterOperator.Equals);
            filter.Add(DeviceFilterMapEnum.Alias, new FilterAttribute("wrong_value", FilterOperator.NotEqual));
            filter.Add(UpdateFilterMapEnum.FinishedAt, "found", FilterOperator.NotEqual);
            filter.Add(UpdateFilterMapEnum.FinishedAt, new FilterAttribute("not_found", FilterOperator.NotEqual));
            filter.Add("range", new FilterAttribute("10", FilterOperator.LessOrEqual), new FilterAttribute("2", FilterOperator.GreaterOrEqual));
            Assert.AreEqual("endpoint_name=value&endpoint_name__neq=wrong_value&finished__neq=found&finished__neq=not_found&range__lte=10&range__gte=2", filter.FilterString);
        }

        [Test]
        public void ShouldEncodeFilterFromJson()
        {
            var filterString = "{\"key\": {\"$eq\": \"value\"}, \"error\": {\"$ne\": \"found\"}, \"range\": {\"$lte\": \"10\", \"$gte\": \"2\"}}";
            var filter = new MbedCloudSDK.Common.Filter.Filter(filterString);
            Assert.AreEqual("key=value&error__neq=found&range__lte=10&range__gte=2", filter.FilterString);
        }

        [Test]
        public void ShouldEncodeBareFilterFromJson()
        {
            var filterString = "{\"key\": \"value\", \"error\": {\"$ne\": \"found\"}, \"range\": {\"$lte\": \"10\", \"$gte\": \"2\"}}";
            var filter = new MbedCloudSDK.Common.Filter.Filter(filterString);
            Assert.AreEqual("key=value&error__neq=found&range__lte=10&range__gte=2", filter.FilterString);
        }

        [Test]
        public void ShouldEncodeFilterFromJsonWithCustomAttributes()
        {
            var filterString = "{\"key\": {\"$eq\": \"value\"}, \"error\": {\"$ne\": \"found\"}, \"range\": {\"$lte\": \"10\", \"$gte\": \"2\"}, \"custom_attributes\": {\"custom_1\": {\"$eq\": \"custom_value_1\"}, \"custom_2\": {\"$ne\": \"custom_value_2\"}}}";
            var filter = new MbedCloudSDK.Common.Filter.Filter(filterString);
            Assert.AreEqual("key=value&error__neq=found&range__lte=10&range__gte=2&custom_attribute__custom_1=custom_value_1&custom_attribute__custom_2__neq=custom_value_2", filter.FilterString);
        }

        [Test]
        public void ShouldDecodeFilter()
        {
            var filterString = "key=value&error__neq=found&range__lte=10&range__gte=2";
            var filter = new MbedCloudSDK.Common.Filter.Filter(filterString);
            Assert.AreEqual("key=value&error__neq=found&range__lte=10&range__gte=2", filter.FilterString);
        }

        [Test]
        public void ShouldDecodeWithCustomAttributes()
        {
            var filterString = "key=value&error__neq=found&range__lte=10&range__gte=2&custom_attribute__custom_1=custom_value_1&custom_attribute__custom_2__neq=custom_value_2";
            var filter = new MbedCloudSDK.Common.Filter.Filter(filterString);
            Assert.AreEqual("key=value&error__neq=found&range__lte=10&range__gte=2&custom_attribute__custom_1=custom_value_1&custom_attribute__custom_2__neq=custom_value_2", filter.FilterString);
        }

        [Test]
        public void RemoveShouldRemoveKeyFromFilter()
        {
            var filter = new MbedCloudSDK.Common.Filter.Filter();
            filter.Add("key", "value", FilterOperator.Equals);
            filter.Add("error", "found", FilterOperator.NotEqual);
            filter.Add("range", new FilterAttribute("10", FilterOperator.LessOrEqual), new FilterAttribute("2", FilterOperator.GreaterOrEqual));
            filter.Remove("range");
            Assert.AreEqual("key=value&error__neq=found", filter.FilterString);
        }

        [Test]
        public void RemoveKeyNotPresentShouldLEaveFilterUnchanged()
        {
            var filter = new MbedCloudSDK.Common.Filter.Filter();
            filter.Add("key", "value", FilterOperator.Equals);
            filter.Add("error", "found", FilterOperator.NotEqual);
            filter.Add("range", new FilterAttribute("10", FilterOperator.LessOrEqual), new FilterAttribute("2", FilterOperator.GreaterOrEqual));
            filter.Remove("rubbish");
            Assert.AreEqual("key=value&error__neq=found&range__lte=10&range__gte=2", filter.FilterString);
        }

        [Test]
        public void ContainsShouldReturnTrueIfKeyPresent()
        {
            var filter = new MbedCloudSDK.Common.Filter.Filter();
            filter.Add("key", "value", FilterOperator.Equals);
            var contains = filter.Contains("key");
            Assert.IsTrue(contains);
        }

        [Test]
        public void ContainsShouldReturnFalseIfKeyNotPresent()
        {
            var filter = new MbedCloudSDK.Common.Filter.Filter();
            filter.Add("key", "value", FilterOperator.Equals);
            var contains = filter.Contains("rubbish");
            Assert.IsFalse(contains);
        }

        [Test]
        public void ShouldEncodeDeviceKey()
        {
            var key = "Alias";
            var encodedKey = MbedCloudSDK.Common.Filter.Filter.EncodeKey(key);
            Assert.AreEqual("endpoint_name", encodedKey);
        }

        [Test]
        public void ShouldEncodeUpdateKey()
        {
            var key = "FinishedAt";
            var encodedKey = MbedCloudSDK.Common.Filter.Filter.EncodeKey(key);
            Assert.AreEqual("finished", encodedKey);
        }

        [Test]
        public void ShouldDecodeKey()
        {
            var key = "finished";
            var decodedKey = MbedCloudSDK.Common.Filter.Filter.DecodeKey(key);
            Assert.AreEqual("FinishedAt", decodedKey);
        }

        [Test]
        public void ShouldEncodeDate()
        {
            var filter = new MbedCloudSDK.Common.Filter.Filter();
            filter.Add("date", new DateTime(2017, 1, 1), FilterOperator.GreaterOrEqual);
            Assert.AreEqual("date__gte=2017-01-01T00:00:00.000Z", filter.FilterString);
        }
    }
}