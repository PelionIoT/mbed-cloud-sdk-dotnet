using MbedCloudSDK.Common.Filter;
using Newtonsoft.Json;
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
        public void BlankFilterWithEmptyJsonReturnsEmptyString()
        {
            var filter = new MbedCloudSDK.Common.Filter.Filter("{}");
            Assert.AreEqual(string.Empty, filter.FilterString);
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
            filter.AddCustom("custom_2", new FilterAttribute("custom_value_2", FilterOperator.NotEqual));
            Assert.AreEqual("key=value&error__neq=found&range__lte=10&range__gte=2&custom_attribute__custom_1=custom_value_1&custom_attribute__custom_2__neq=custom_value_2", filter.FilterString);
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
    }
}