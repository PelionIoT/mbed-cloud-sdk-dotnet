using NUnit.Framework;
using System;
using MbedCloudSDK.Common.Tlv;
using System.IO;
using MbedCloudSDK.Exceptions;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using MbedCloudSDK.Common;
using MbedCloudSDK.Common.Extensions;
using MbedCloudSDK.Connect.Model.Notifications;
using Newtonsoft.Json;

namespace MbedCloudSDK.Test.Common.Tlv
{
    [TestFixture]
    public class TlvDecoder
    {
        [Test]
        public void CreateNewLwm2mResourceWithInt()
        {
            var lwm2m = new Lwm2mResource("/0", 50);
            Assert.AreEqual(50, lwm2m.GetIntValue());
            Assert.AreEqual("50", lwm2m.GetStringValue());
        }

        [Test]
        public void CreateNewLwm2mResourceWithBytes()
        {
            var lwm2m = new Lwm2mResource("/0", new byte[] { 50 });
            Assert.AreEqual(50, lwm2m.GetIntValue());
            Assert.AreEqual("50", lwm2m.GetStringValue());
        }

        [Test]
        public void CreateNewLwm2mResourceWithString()
        {
            var lwm2m = new Lwm2mResource("/0", "50");
            Assert.AreEqual(50, lwm2m.GetIntValue());
            Assert.AreEqual("50", lwm2m.GetStringValue());
        }

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
                var tlv = new MbedCloudSDK.Common.Tlv.TlvDecoder();
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
        public void InvalidLengthTypeThrowsException()
        {
            // Assert.That(() => TypesHelper.GetLengthTypeEnumValue(42 & 0xFF), Throws.Exception.TypeOf<DecodingException>());
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
                var tlv = new MbedCloudSDK.Common.Tlv.TlvDecoder();
                var res = tlv.DecodeTlvFromBytes(response);
                Assert.AreEqual(1, res.Count);
                var resource = res.FirstOrDefault();
                Assert.AreEqual("/0", resource.Id);
                Assert.AreEqual("Open Mobile Alliance", resource.GetStringValue());
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
                var tlv = new MbedCloudSDK.Common.Tlv.TlvDecoder();
                var res = tlv.DecodeTlvFromBytes(response);
                Assert.NotNull(res);
                Assert.AreEqual(16, res.Count);
                Assert.AreEqual(res[0].GetStringValue(), "Open Mobile Alliance");
                Assert.AreEqual(res[1].GetStringValue(), "Lightweight M2M Client");
                Assert.AreEqual(res[2].GetStringValue(), "345000123");
                Assert.AreEqual(res[3].GetStringValue(), "1.0");
                Assert.AreEqual(res[4].GetIntValue(), 1);
                Assert.AreEqual(res[5].GetIntValue(), 5);
                Assert.AreEqual(res[6].GetStringValue(), "Ø");
                Assert.AreEqual(res[8].GetStringValue(), "}");
                Assert.AreEqual(res[10].GetStringValue(), "d");
                Assert.AreEqual(res[11].GetIntValue(), 15);
                Assert.AreEqual(res[12].GetStringValue(), "0");
                Assert.AreEqual(res[14].GetStringValue(), "+02:00");
                Assert.AreEqual(res[15].GetStringValue(), "U");
            }
        }

        [Test]
        public void ShouldDecodeNothing()
        {
            var res = new AsyncIdResponse
            {
                Payload = string.Empty,
                ContentType = "tlv",
            };

            var payload = res.DecodeBase64();
            Assert.AreEqual("{}", payload);
        }

        [Test]
        public void ShouldDecodeSimple()
        {
            var res = new AsyncIdResponse
            {
                Payload = "AAA=",
                ContentType = "tlv",
            };

            var payload = res.DecodeBase64();
            Assert.AreEqual("{\"/0\": \"\"}", payload);
        }

        [Test]
        public void ShouldDecodeSimpleWithNoContentType()
        {
            var res = new AsyncIdResponse
            {
                Payload = "dGVzdA==",
            };

            var payload = res.DecodeBase64();
            Assert.AreEqual("test", payload);
        }

        [Test]
        public void ShouldDecodeSimpleNotification()
        {
            var res = new NotificationData
            {
                Payload = "AAA=",
                ContentType = "tlv",
            };

            var payload = res.DecodeBase64();
            Assert.AreEqual("{\"/0\": \"\"}", payload);
        }

        [Test]
        public void ShouldDecodeComplex()
        {
            var res = new AsyncIdResponse
            {
                Payload = "iAsLSAAIAAAAAAAAAADBEFXIABAAAAAAAAAAAAAAAAAAAAAAyAEQAAAAAAAAAAAAAAAAAAAAAMECMMgRD2Rldl9kZXZpY2VfdHlwZcgSFGRldl9oYXJkd2FyZV92ZXJzaW9uyBUIAAAAAAAAAADIDQgAAAAAWdH0Bw==",
                ContentType = "tlv",
            };

            var payload = res.DecodeBase64();
            Assert.AreEqual("{\"/11/0\": \"0\",\"/16\": \"U\",\"/0\": \"0\",\"/1\": \"0\",\"/2\": \"0\",\"/17\": \"dev_device_type\",\"/18\": \"dev_hardware_version\",\"/21\": \"0\",\"/13\": \"1506931719\"}", payload);
        }

        [Test]
        public void ShouldDecodePlainPayload()
        {
            var res = new AsyncIdResponse
            {
                Payload = "dGVzdA==",
                ContentType = "json",
            };

            var payload = res.DecodeBase64();
            Assert.AreEqual("test", payload);
        }

        [Test]
        public void ShouldSerializeNotification()
        {
            var notificationString = "{\"notifications\": [{\"ct\": \"text/plain\",\"ep\": \"015f77b2364200000000000100100027\",\"max-age\": 60,\"path\": \"/5002/0/1\",\"payload\": \"MTM3ODI=\"}]}";
            var notificationJson = JsonConvert.DeserializeObject<NotificationMessage>(notificationString);
        }
    }
}