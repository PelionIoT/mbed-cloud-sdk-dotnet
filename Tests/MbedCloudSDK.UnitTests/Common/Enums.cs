using MbedCloudSDK.Certificates.Model;
using MbedCloudSDK.Common.Extensions;
using MbedCloudSDK.Common;
using MbedCloudSDK.Common.Tlv;
using MbedCloudSDK.Update.Model.Campaign;
using NUnit.Framework;

namespace MbedCloudSDK.Test.Common.Enum
{
    [TestFixture]
    public class Enums
    {
        [Test]
        public void ParseApiEnumToSDKEnum()
        {
            var parsedEnum = iam.Model.TrustedCertificateReq.StatusEnum.ACTIVE.ParseEnum<CertificateStatus>();
            Assert.AreEqual("Active", parsedEnum.ToString());
        }

        [Test]
        public void FailedParseReturnsDefault()
        {
            object nullEnum = null;
            var defaultEnum = nullEnum.ParseEnum<CertificateStatus>();
            Assert.AreEqual(default(CertificateStatus), defaultEnum);
        }

        [Test]
        public void FailedParseWithIncorrectValueReturnsDefault()
        {
            var defaultEnum = "rubbish".ParseEnum<CertificateStatus>();
            Assert.AreEqual(default(CertificateStatus), defaultEnum);
        }

        [Test]
        public void GetEnumMemberValueFromEnum()
        {
            var enumMemberValue = MaskEnum.LENGTH_TYPE.ToString().GetEnumMemberValue(typeof(MaskEnum));
            Assert.AreEqual("00011000", enumMemberValue);
        }

        [Test]
        public void FailedEnumMemberValueConversionShouldReturnNull()
        {
            string nullEnum = null;
            var enumMemberValue = nullEnum.GetEnumMemberValue(typeof(MaskEnum));
            Assert.IsNull(enumMemberValue);
        }

        [Test]
        public void FailedEnumMemberValueConversionWithIncorrectValueShouldReturnNull()
        {
            var enumMemberValue = "rubbush".GetEnumMemberValue(typeof(MaskEnum));
            Assert.IsNull(enumMemberValue);
        }

        [Test]
        public void GetEnumFromEnumMemberValue()
        {
            var enumValue = (CampaignStateEnum)"draft".GetEnumFromEnumMemberValue(typeof(CampaignStateEnum));
            Assert.AreEqual("Draft", enumValue.ToString());
        }

        [Test]
        public void GetEnumFromEnumMemberValueWithIncorrectValueReturnsNull()
        {
            var enumValue = "rubbish".GetEnumFromEnumMemberValue(typeof(CampaignStateEnum));
            Assert.IsNull(enumValue);
        }

        [Test]
        public void FailedEnumConversionShouldReturnNull()
        {
            string nullString = null;
            var enumValue = nullString.GetEnumFromEnumMemberValue(typeof(CampaignStateEnum));
            Assert.IsNull(enumValue);
        }
    }
}