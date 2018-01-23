using MbedCloudSDK.Common;
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
            var res = Utils.SnakeToCamel(strng);
            Assert.AreEqual("ImACamelWithHumps", res);
        }

        [Test]
        public void ShouldBeLowerCamel()
        {
            var strng = "im_a_camel_with_humps";
            var res = Utils.SnakeToLowerCamel(strng);
            Assert.AreEqual("imACamelWithHumps", res);
        }

        [Test]
        public void BeginsWithUnderScore()
        {
            var strng = "_im_a_camel_with_humps";
            var res = Utils.SnakeToCamel(strng);
            Assert.AreEqual("ImACamelWithHumps", res);
        }

        [Test]
        public void EndsWithUnderScore()
        {
            var strng = "im_a_camel_with_humps_";
            var res = Utils.SnakeToCamel(strng);
            Assert.AreEqual("ImACamelWithHumps_", res);
        }

        [Test]
        public void CreatesCapitalAtEnd()
        {
            var strng = "im_a_camel_with_hump_s";
            var res = Utils.SnakeToCamel(strng);
            Assert.AreEqual("ImACamelWithHumpS", res);
        }

        [Test]
        public void PreservesCapitals()
        {
            var strng = "iM_a_caMEl_wiTh_huMPs";
            var res = Utils.SnakeToCamel(strng);
            Assert.AreEqual("IMACaMElWiThHuMPs", res);
        }

        [Test]
        public void ShouldBeSnake()
        {
            var strng = "imReallyASnake";
            var res = Utils.CamelToSnake(strng);
            Assert.AreEqual("im_really_a_snake", res);
        }

        [Test]
        public void BeginsWithCapital()
        {
            var strng = "ImReallyASnake";
            var res = Utils.CamelToSnake(strng);
            Assert.AreEqual("_im_really_a_snake", res);
        }

        [Test]
        public void EndsWithCapital()
        {
            var strng = "imReallyASnakE";
            var res = Utils.CamelToSnake(strng);
            Assert.AreEqual("im_really_a_snak_e", res);
        }

        [Test]
        public void PreservesUnderscore()
        {
            var strng = "imRe_allyA_Snake";
            var res = Utils.CamelToSnake(strng);
            Assert.AreEqual("im_re_ally_a__snake", res);
        }
    }
}