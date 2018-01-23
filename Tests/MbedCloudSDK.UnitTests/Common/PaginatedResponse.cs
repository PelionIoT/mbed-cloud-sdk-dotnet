using System;
using System.Collections.Generic;
using MbedCloudSDK.Common;
using MbedCloudSDK.Common.Query;
using NUnit.Framework;

namespace MbedCloudSDK.Test.Common
{
    [TestFixture]
    public class PaginatedResponse
    {
        [Test]
        public void PaginatedResdponseWithInitData()
        {
            var options = new QueryOptions();
            Func<QueryOptions, ResponsePage<string>> listFunc = (ops) => { return new ResponsePage<string>(new List<string> { "stuff", "more stuff", "even more stuff" }); };
            var pag = new PaginatedResponse<QueryOptions, string>(listFunc, options, new List<string> { "init data", "more init data"});

            Assert.AreEqual(2, pag.TotalCount);
            Assert.AreEqual(2, pag.ToList().Count);
        }

        [Test]
        public void PaginatedResponseShouldGetPage()
        {
            var options = new QueryOptions();
            Func<QueryOptions, ResponsePage<string>> listFunc = (ops) => { return new ResponsePage<string>(new List<string> { "stuff", "more stuff", "even more stuff" }); };
            var pag = new PaginatedResponse<QueryOptions, string>(listFunc, options);

            Assert.AreEqual(3, pag.TotalCount);
            Assert.AreEqual(3, pag.ToList().Count);
        }
    }
}