using System;
using System.Collections.Generic;
using System.Linq;
using MbedCloudSDK.Common;
using MbedCloudSDK.Common.Query;
using NUnit.Framework;

namespace MbedCloudSDK.Test.Common
{
    [TestFixture]
    public class PaginatedResponse
    {
        [Test]
        public void PaginatedResponseShouldGetPage()
        {
            var options = new QueryOptions { PageSize = 10 };
            var pag = new PaginatedResponse<QueryOptions, MockData>(mockFuncWithData, options);

            Assert.AreEqual(10, pag.TotalCount);
            Assert.AreEqual(10, pag.ToList().Count);
        }

        private Func<QueryOptions, ResponsePage<MockData>> mockFuncWithData = (ops) =>
        {
            var data = new List<MockData>();
            for (int i = 0; i < ops.PageSize; i++)
            {
                data.Add(new MockData { data = i });
            }

            return new ResponsePage<MockData>(data);
        };

        private class MockData : BaseModel
        {
            public int data { get; set; }
        }
    }
}