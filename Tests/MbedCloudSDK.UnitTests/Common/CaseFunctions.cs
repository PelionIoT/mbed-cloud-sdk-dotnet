using MbedCloudSDK.Common.Extensions;
using NUnit.Framework;

namespace MbedCloudSDK.Test.Common
{
    [TestFixture]
    public class CaseFunctions
    {
        [Test]
        public void ShouldBeCamel()
        {
            var strng = "im_a_camel_with_humps";
            var res = strng.SnakeToCamel();
            Assert.AreEqual("ImACamelWithHumps", res);
        }

        [Test]
        public void ShouldBeLowerCamel()
        {
            var strng = "im_a_camel_with_humps";
            var res =strng.SnakeToLowerCamel();
            Assert.AreEqual("imACamelWithHumps", res);
        }

        [Test]
        public void BeginsWithUnderScore()
        {
            var strng = "_im_a_camel_with_humps";
            var res = strng.SnakeToCamel();
            Assert.AreEqual("ImACamelWithHumps", res);
        }

        [Test]
        public void EndsWithUnderScore()
        {
            var strng = "im_a_camel_with_humps_";
            var res = strng.SnakeToCamel();
            Assert.AreEqual("ImACamelWithHumps_", res);
        }

        [Test]
        public void CreatesCapitalAtEnd()
        {
            var strng = "im_a_camel_with_hump_s";
            var res = strng.SnakeToCamel();
            Assert.AreEqual("ImACamelWithHumpS", res);
        }

        [Test]
        public void PreservesCapitals()
        {
            var strng = "iM_a_caMEl_wiTh_huMPs";
            var res = strng.SnakeToCamel();
            Assert.AreEqual("IMACaMElWiThHuMPs", res);
        }

        [Test]
        public void ShouldBeSnake()
        {
            var strng = "imReallyASnake";
            var res = strng.CamelToSnake();
            Assert.AreEqual("im_really_a_snake", res);
        }

        [Test]
        public void BeginsWithCapital()
        {
            var strng = "ImReallyASnake";
            var res = strng.CamelToSnake();
            Assert.AreEqual("_im_really_a_snake", res);
        }

        [Test]
        public void EndsWithCapital()
        {
            var strng = "imReallyASnakE";
            var res = strng.CamelToSnake();
            Assert.AreEqual("im_really_a_snak_e", res);
        }

        [Test]
        public void PreservesUnderscore()
        {
            var strng = "imRe_allyA_Snake";
            var res = strng.CamelToSnake();
            Assert.AreEqual("im_re_ally_a__snake", res);
        }
    }
}