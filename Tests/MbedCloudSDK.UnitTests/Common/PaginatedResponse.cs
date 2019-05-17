using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mbed.Cloud.Common;
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

            Assert.AreEqual(10, pag.All().Count);
        }

        [Test]
        public void PaginatedResponseShouldGetPageEmpty()
        {
            var options = new QueryOptions { PageSize = 0 };
            var pag = new PaginatedResponse<QueryOptions, MockData>(mockFuncWithData, options);

            Assert.AreEqual(0, pag.All().Count);
        }

        private Func<QueryOptions, Task<ResponsePage<MockData>>> mockFuncWithData = (ops) =>
        {
            var data = new List<MockData>();
            for (int i = 0; i < ops.PageSize; i++)
            {
                data.Add(new MockData { data = i });
            }

            return Task.Run(() => new ResponsePage<MockData>(data));
        };

        private class MockData : Entity
        {
            public int data { get; set; }
        }
    }
}