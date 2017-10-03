using NUnit.Framework;
using System;

namespace MbedCloudSDK.Test.Common.Tlv
{
    [TestFixture]
    public class TlvDecoder
    {
        [Test]
        public void TestTypeIdentifierParsing()
        {
            byte[] array = {0xE3, 0xA3, 0x67, 0b001_100};
            //Assert.Equals(TypesEnum)
        }
    }
}