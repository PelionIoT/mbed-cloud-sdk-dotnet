using System;
using System.Collections.Generic;
using MbedCloudSDK.Certificates.Model;
using MbedCloudSDK.Common;
using MbedCloudSDK.Common.Extensions;
using MbedCloudSDK.DeviceDirectory.Model.Query;
using NUnit.Framework;

namespace MbedCloudSDK.Test.Common
{
    [TestFixture]
    public class ObjectExtensions
    {
        [Test]
        public void MapToObject()
        {
            var originalCertificate = new Certificate();
            originalCertificate.Description = "description of certificate";
            originalCertificate.Name = "Original Certificate";

            var updatedCertificate = new Certificate();
            updatedCertificate.Name = "Updated Certificate";

            var certificate = originalCertificate.MapToUpdate(updatedCertificate) as Certificate;

            Assert.AreEqual("Updated Certificate", certificate.Name);
        }

        [Test]
        public void MapToObjectWithNewFilter()
        {
            var originalQuery = new Query();
            originalQuery.Name = "Query";
            originalQuery.Filter = new MbedCloudSDK.Common.Filter.Filter();
            originalQuery.Filter.Add("orig", "true");

            var queryToUpdate = new Query();
            queryToUpdate.Filter = new MbedCloudSDK.Common.Filter.Filter();
            queryToUpdate.Filter.Add("new", "true");

            var query = originalQuery.MapToUpdate(queryToUpdate) as Query;
            Assert.IsTrue(query.Filter.Contains("new"));
            Assert.IsFalse(query.Filter.Contains("orig"));
        }

        [Test]
        public void MapToObjectWithBlankFilter()
        {
            var originalQuery = new Query();
            originalQuery.Name = "Query";
            originalQuery.Filter = new MbedCloudSDK.Common.Filter.Filter();
            originalQuery.Filter.Add("orig", "true");

            var queryToUpdate = new Query();
            queryToUpdate.Filter = new MbedCloudSDK.Common.Filter.Filter();
            queryToUpdate.Filter.IsBlank = true;

            var query = originalQuery.MapToUpdate(queryToUpdate) as Query;
            Assert.IsTrue(query.Filter.Contains("orig"));
        }

        [Test]
        public void IsValidJsonReturnsTrue()
        {
            var json = "{\"key\": {\"$eq\": \"value\"}, \"error\": {\"$ne\": \"found\"}, \"range\": {\"$lte\": \"10\", \"$gte\": \"2\"}}";
            var isValidJson = json.IsValidJson();
            Assert.IsTrue(isValidJson);
        }

        [Test]
        public void IsValidJsonArrayReturnsTrue()
        {
            var json = "[{\"key\": {\"$eq\": \"value\"}}, {\"error\": {\"$ne\": \"found\"}}, {\"range\": {\"$lte\": \"10\", \"$gte\": \"2\"}}]";
            var isValidJson = json.IsValidJson();
            Assert.IsTrue(isValidJson);
        }

        [Test]
        public void InvalidJsonReturnsFalse()
        {
            var json = "key=value&error__neq=found&range__lte=10&range__gte=2";
            var isValidJson = json.IsValidJson();
            Assert.IsFalse(isValidJson);
        }

        [Test]
        public void InvalidJsonThrowsJsonReaderException()
        {
            var json = "{key=value&error__neq=found&range__lte=10&range__gte=2}";
            var isValidJson = json.IsValidJson();
            Assert.IsFalse(isValidJson);
        }

        [Test]
        public void GetPropertiesOfAnObjectShouldReturnCorrectDictionary()
        {
            var obj = new ObjectWithKnownProperties();
            Assert.AreEqual(obj.GetTestPropertiesAsDictionary(), obj.GetProperties());
        }

        [Test]
        public void DebugDumptReturnsAnEmptyStringForNull()
        {
            object obj = null;
            Assert.AreEqual(string.Empty, obj.DebugDump(MbedCloudSDK.Common.Extensions.ObjectExtensions.DumpFormat.Text));
            Assert.AreEqual(string.Empty, obj.DebugDump(MbedCloudSDK.Common.Extensions.ObjectExtensions.DumpFormat.Json));
        }

        [Test]
        public void DebugDumpReturnsExpectedTextResult()
        {
            var obj = new ObjectWithKnownProperties();
            Assert.AreEqual(obj.GetTestDebugDump(), obj.DebugDump(MbedCloudSDK.Common.Extensions.ObjectExtensions.DumpFormat.Text));
        }

        [Test]
        public void DebugDumpReturnsValidJsonResult()
        {
            var obj = new ObjectWithKnownProperties();
            var json = obj.DebugDump(MbedCloudSDK.Common.Extensions.ObjectExtensions.DumpFormat.Json);

            // We just need to check that DumpFormat.Json is used, no need to test if underlying JSON serializer
            // works as expected...
            Assert.IsTrue(json.IsValidJson());
        }

        sealed class ObjectWithKnownProperties
        {
            public string One { get; } = OneDefaultValue;

            public string Two { get; } = TwoDefaultValue;

            // This is excluded because it's an indexer, note that in C# we can't create indexers
            // for named properties (something similar to public string SomeProperty[string key] { get { ... } })
            // but it's possible in other .NET languages (for example C++/CLI), we can't test it here but it should
            // work as expected...
            public string this[int index]
            {
                get => "";
            }

            public string ThisIsExcludedBecauseSetterOnly { set { } }

            public string ThisIsExcludedBecauseNonPublicGetter { private get; set; }

            internal string ThisIsExcludedBecauseNonPublic { get; set; }

            public Dictionary<string, object> GetTestPropertiesAsDictionary()
            {
                return new Dictionary<string, object>
                {
                    { nameof(One), OneDefaultValue },
                    { nameof(Two), TwoDefaultValue },
                };
            }

            public string GetTestDebugDump()
                => $"class {GetType().Name}SerializerData {{{Environment.NewLine}" +
                    $"    {nameof(One)}: {OneDefaultValue}{Environment.NewLine}" +
                    $"    {nameof(Two)}: {TwoDefaultValue}{Environment.NewLine}" +
                    $"}}{Environment.NewLine}";

            private const string OneDefaultValue = "one";
            private const string TwoDefaultValue = "two";
        }
    }
}