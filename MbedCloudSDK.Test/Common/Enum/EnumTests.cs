using MbedCloudSDK.Certificates.Model;
using MbedCloudSDK.Common;
using MbedCloudSDK.Common.Tlv;
using MbedCloudSDK.Update.Model.Campaign;
using NUnit.Framework;

namespace MbedCloudSDK.Test.Common.Enum
{
    [TestFixture]
    public class EnumTests
    {
        [Test]
        public void ParseApiEnumToSDKEnum()
        {
            var parsedEnum = Utils.ParseEnum<CertificateStatus>(iam.Model.TrustedCertificateReq.StatusEnum.ACTIVE);
            Assert.AreEqual("Active", parsedEnum.ToString());
        }

        [Test]
        public void FailedParseReturnsDefault()
        {
            var defaultEnum = Utils.ParseEnum<CertificateStatus>(null);
            Assert.AreEqual(default(CertificateStatus), defaultEnum);
        }

        [Test]
        public void GetEnumMemberValueFromEnum()
        {
            var enumMemberValue = Utils.GetEnumMemberValue(typeof(MaskEnum), MaskEnum.LENGTH_TYPE.ToString());
            Assert.AreEqual("00011000", enumMemberValue);
        }

        [Test]
        public void FailedEnumMemberValueConversionShouldReturnNull()
        {
            var enumMemberValue = Utils.GetEnumMemberValue(typeof(MaskEnum), null);
            Assert.IsNull(enumMemberValue);
        }

        [Test]
        public void GetEnumFromEnumMemberValue()
        {
            var enumValue = (CampaignStateEnum)Utils.GetEnumFromEnumMemberValue(typeof(CampaignStateEnum), "draft");
            Assert.AreEqual("Draft", enumValue.ToString());
        }

        [Test]
        public void FailedEnumConversionShouldReturnNull()
        {
            var enumValue = Utils.GetEnumFromEnumMemberValue(typeof(CampaignStateEnum), null);
            Assert.IsNull(enumValue);
        }
    }
}