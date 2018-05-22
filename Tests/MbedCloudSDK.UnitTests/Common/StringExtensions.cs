using NUnit.Framework;
using MbedCloudSDK.Common.Extensions;

namespace MbedCloudSDK.UnitTests.Common
{
    [TestFixture]
    public class StringExtensions
    {
        [Test]
        public void TestNullWildcardString()
        {
            string wildcard = null;
            var match = wildcard.MatchWithWildcard("3/0/0");
            Assert.IsTrue(match);
        }

        [Test]
        public void TestEmptyWildcardString()
        {
            var wildcard = string.Empty;
            var match = wildcard.MatchWithWildcard("3/0/0");
            Assert.IsTrue(match);
        }

        [Test]
        public void TestCorrectWildcardString()
        {
            var wildcard = "3/0/0";
            var match = wildcard.MatchWithWildcard("3/0/0");
            Assert.IsTrue(match);
        }

        [Test]
        public void TestWildcardString()
        {
            var wildcard = "3/*";
            var match = wildcard.MatchWithWildcard("3/0/0");
            Assert.IsTrue(match);

            wildcard = "3/0/*";
            match = wildcard.MatchWithWildcard("3/0/0");
            Assert.IsTrue(match);

            wildcard = "3/0/*";
            match = wildcard.MatchWithWildcard("3/1/0");
            Assert.IsFalse(match);

            wildcard = "*";
            match = wildcard.MatchWithWildcard("3/1/0");
            Assert.IsTrue(match);
        }
    }
}