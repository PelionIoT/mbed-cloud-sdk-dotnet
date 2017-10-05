using NUnit.Framework;
using System;
using MbedCloudSDK.Common.Tlv;
using System.IO;
using MbedCloudSDK.Exceptions;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace MbedCloudSDK.Test.Common.Tlv
{
    [TestFixture]
    public class TlvDecoderTests
    {
        [Test]
        public void TestTypeIdentifierParsing()
        {
            byte[] array = { 0xE3, 0xA3, 0x67, 0b0001_1000 };
            using (var stream = new MemoryStream(array))
            {
                Assert.AreEqual(TypesEnum.RESOURCE_VALU, TypesHelper.GetTypeEnumValue(stream.ReadByte() & 0xFF));
                Assert.AreEqual(TypesEnum.MULT_RESOURCE, TypesHelper.GetTypeEnumValue(stream.ReadByte() & 0xFF));
                Assert.AreEqual(TypesEnum.RESOURCE_INST, TypesHelper.GetTypeEnumValue(stream.ReadByte() & 0xFF));
                Assert.AreEqual(TypesEnum.OBJECT_INSTAN, TypesHelper.GetTypeEnumValue(stream.ReadByte() & 0xFF));
            }
        }

        [Test]
        public void TestIdentifierLengthParsing()
        {
            byte[] array = { 0xE3, 0xA3, 0x67, 0b0001_1000 };
            using (var stream = new MemoryStream(array))
            {
                var tlv = new TlvDecoder();
                Assert.AreEqual(2, tlv.FindIdLength(stream.ReadByte() & 0xFF));
                Assert.AreEqual(2, tlv.FindIdLength(stream.ReadByte() & 0xFF));
                Assert.AreEqual(2, tlv.FindIdLength(stream.ReadByte() & 0xFF));
                Assert.AreEqual(1, tlv.FindIdLength(stream.ReadByte() & 0xFF));
            }
        }

        [Test]
        public void TestTypeOfLengthParsing()
        {
            byte[] array = { 0xE3, 0b0001_0000, 0b0000_1000, 0b0001_1000 };
            using (var stream = new MemoryStream(array))
            {
                Assert.AreEqual(LengthTypeEnum.OTR_BYTE, TypesHelper.GetLengthTypeEnumValue(stream.ReadByte() & 0xFF));
                Assert.AreEqual(LengthTypeEnum.TWO_BYTE, TypesHelper.GetLengthTypeEnumValue(stream.ReadByte() & 0xFF));
                Assert.AreEqual(LengthTypeEnum.ONE_BYTE, TypesHelper.GetLengthTypeEnumValue(stream.ReadByte() & 0xFF));
                Assert.AreEqual(LengthTypeEnum.TRE_BYTE, TypesHelper.GetLengthTypeEnumValue(stream.ReadByte() & 0xFF));
            }
        }

        [Test]
        public void TestSingleResourceTLVDecode()
        {
            byte[] response =
            {
                0xC8, 0x00, 0x14, 0x4F, 0x70, 0x65, 0x6E,
                0x20, 0x4D, 0x6F, 0x62, 0x69, 0x6C, 0x65, 0x20,
                0x41, 0x6C, 0x6C, 0x69, 0x61, 0x6E, 0x63,
                0x65
            };
            using (var stream = new MemoryStream(response))
            {
                var tlv = new TlvDecoder();
                var res = tlv.Decode(response.ToList(), new List<Lwm2mResource>());
                Assert.AreEqual(1, res.Count);
                var resource = res.FirstOrDefault();
                Assert.AreEqual(resource.Id, 0);
                Assert.AreEqual(resource.GetStringValue(), "Open Mobile Alliance");
            }
        }

        [Test]
        public void TestSingleObjectInstanceTLVDecode()
        {
            byte[] response =
            {
                0xC8, 0x00, 0x14, 0x4F, 0x70, 0x65, 0x6E,
                0x20, 0x4D, 0x6F, 0x62, 0x69, 0x6C, 0x65, 0x20,
                0x41, 0x6C, 0x6C, 0x69, 0x61, 0x6E, 0x63, 0x65,
                0xC8, 0x01, 0x16, 0x4C, 0x69, 0x67, 0x68, 0x74,
                0x77, 0x65, 0x69, 0x67, 0x68, 0x74, 0x20, 0x4D,
                0x32, 0x4D, 0x20, 0x43, 0x6C, 0x69, 0x65, 0x6E,
                0x74, 0xC8, 0x02, 0x09, 0x33, 0x34, 0x35, 0x30,
                0x30, 0x30, 0x31, 0x32, 0x33, 0xC3, 0x03, 0x31,
                0x2E, 0x30, 0x86, 0x06, 0x41, 0x00, 0x01, 0x41,
                0x01, 0x05, 0x88, 0x07, 0x08, 0x42, 0x00, 0x0E,
                0xD8, 0x42, 0x01, 0x13, 0x88, 0x87, 0x08, 0x41,
                0x00, 0x7D, 0x42, 0x01, 0x03, 0x84, 0xC1, 0x09,
                0x64, 0xC1, 0x0A, 0x0F, 0x83, 0x0B, 0x41, 0x00,
                0x00, 0xC4, 0x0D, 0x51, 0x82, 0x42, 0x8F, 0xC6,
                0x0E, 0x2B, 0x30, 0x32, 0x3A, 0x30, 0x30, 0xC1,
                0x10, 0x55
            };
            using (var stream = new MemoryStream(response))
            {
                var tlv = new TlvDecoder();
                var res = tlv.Decode(response.ToList(), new List<Lwm2mResource>());
                Assert.NotNull(res);
                Assert.AreEqual(13, res.Count);
            }
        }

        [Test]
        public void TestSMultipleObjectInstanceTLVDecode_A()
        {
            byte[] response =
            {
                0x08, 0x00, 0x79, 0xC8, 0x00, 0x14, 0x4F,
                0x70, 0x65, 0x6E, 0x20, 0x4D, 0x6F, 0x62, 0x69,
                0x6C, 0x65, 0x20, 0x41, 0x6C, 0x6C, 0x69, 0x61,
                0x6E, 0x63, 0x65, 0xC8, 0x01, 0x16, 0x4C, 0x69,
                0x67, 0x68, 0x74, 0x77, 0x65, 0x69, 0x67, 0x68,
                0x74, 0x20, 0x4D, 0x32, 0x4D, 0x20, 0x43, 0x6C,
                0x69, 0x65, 0x6E, 0x74, 0xC8, 0x02, 0x09, 0x33,
                0x34, 0x35, 0x30, 0x30, 0x30, 0x31, 0x32, 0x33,
                0xC3, 0x03, 0x31, 0x2E, 0x30, 0x86, 0x06, 0x41,
                0x00, 0x01, 0x41, 0x01, 0x05, 0x88, 0x07, 0x08,
                0x42, 0x00, 0x0E, 0xD8, 0x42, 0x01, 0x13, 0x88,
                0x87, 0x08, 0x41, 0x00, 0x7D, 0x42, 0x01, 0x03,
                0x84, 0xC1, 0x09, 0x64, 0xC1, 0x0A, 0x0F, 0x83,
                0x0B, 0x41, 0x00, 0x00, 0xC4, 0x0D, 0x51, 0x82,
                0x42, 0x8F, 0xC6, 0x0E, 0x2B, 0x30, 0x32, 0x3A,
                0x30, 0x30, 0xC1, 0x10, 0x55
            };
            using (var stream = new MemoryStream(response))
            {
                var tlv = new TlvDecoder();
                var res = tlv.Decode(response.ToList(), new List<Lwm2mResource>());
                Assert.AreEqual(res.Count, 1);

            }
        }

        [Test]
        public void TestSMultipleObjectInstanceTLVDecode_B()
        {
            byte[] response =
            {
                0x08, 0x00, 0x0E, 0xC1, 0x00, 0x01, 0xC1,
                0x01, 0x00, 0x83, 0x02, 0x41, 0x7F, 0x07, 0xC1,
                0x03, 0x7F, 0x08, 0x02, 0x12, 0xC1, 0x00, 0x03,
                0xC1, 0x01, 0x00, 0x87, 0x02, 0x41, 0x7F, 0x07,
                0x61, 0x01, 0x36, 0x01, 0xC1, 0x03, 0x7F
            };
            using (var stream = new MemoryStream(response))
            {
                var tlv = new TlvDecoder();
                var res = tlv.Decode(response.ToList(), new List<Lwm2mResource>());
                Assert.AreEqual(res.Count, 2);
            }
        }

        [Test]
        public void TestSMultipleObjectInstanceTLVDecode_C()
        {
            byte[] response =
            {
                0x08, 0x00, 0x0F, 0xC1, 0x00, 0x01, 0xC4,
                0x01, 0x00, 0x01, 0x51, 0x80, 0xC1, 0x06, 0x01,
                0xC1, 0x07, 0x55
            };
            using (var stream = new MemoryStream(response))
            {
                var tlv = new TlvDecoder();
                var res = tlv.Decode(response.ToList(), new List<Lwm2mResource>());
                Assert.AreEqual(1, res.Count);
                var resource = res.FirstOrDefault();
                Assert.AreEqual(resource.Id, 0);
            }
        }
    }
}