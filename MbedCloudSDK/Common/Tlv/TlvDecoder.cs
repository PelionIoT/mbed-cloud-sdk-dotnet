// <copyright file="TlvDecoder.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Common.Tlv
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Text;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Tlv Decoder
    /// </summary>
    public class TlvDecoder
    {
        private int typeMask = Convert.ToInt32("11000000", 2);
        private int idLengthMask = Convert.ToInt32("00100000", 2);
        private int lengthTypeMask = Convert.ToInt32("00011000", 2);
        private int lengthMask = Convert.ToInt32("00000111", 2);

        /// <summary>
        /// Get String Value
        /// </summary>
        /// <param name="value">Int value</param>
        /// <returns>String value</returns>
        public static string GetString(int value)
        {
            var str = (char)value;
            return str.ToString();
        }

        /// <summary>
        /// Combine Bytes
        /// </summary>
        /// <param name="accumalatedValue">accumalatedValue</param>
        /// <param name="currentValue">currentValue</param>
        /// <param name="index">index</param>
        /// <param name="count">count of array</param>
        /// <returns>Int value of bytes</returns>
        public static int CombineBytes(int accumalatedValue, int currentValue, int index, int count)
        {
            var step = count - index - 1;
            var combined = accumalatedValue + (currentValue << (8 * step));
            return combined;
        }

        /// <summary>
        /// Find Id Length
        /// </summary>
        /// <param name="byteVal">Byte value</param>
        /// <returns>Id Length</returns>
        public int FindIdLength(int byteVal)
        {
            return (byteVal & idLengthMask) == idLengthMask ? 2 : 1;
        }

        /// <summary>
        /// Find Value Length
        /// </summary>
        /// <param name="byteVal">Byte value</param>
        /// <returns>Value Length</returns>
        public int FindValueLength(int byteVal)
        {
            if ((byteVal & lengthTypeMask) == TypesHelper.GetLengthTypeBinary(LengthTypeEnum.ONE_BYTE))
            {
                return 1;
            }
            else if ((byteVal & lengthTypeMask) == TypesHelper.GetLengthTypeBinary(LengthTypeEnum.TWO_BYTE))
            {
                return 2;
            }
            else if ((byteVal & lengthTypeMask) == TypesHelper.GetLengthTypeBinary(LengthTypeEnum.TRE_BYTE))
            {
                return 3;
            }
            else
            {
                return byteVal & lengthMask;
            }
        }

        /// <summary>
        /// Decode a tlv payload
        /// </summary>
        /// <param name="val">String value of payload</param>
        /// <returns>decoded string</returns>
        public string DecodeTlv(string val)
        {
            var bytes = Encoding.Unicode.GetBytes(val);
            var tlv = JObject.FromObject(Decode(bytes, new List<Lwm2mResource>()));
            return tlv.ToString();
        }

        /// <summary>
        /// Decode a tlv payload from a byte array
        /// </summary>
        /// <param name="bytes">payload byte array</param>
        /// <returns>list of resource objects</returns>
        public List<Lwm2mResource> DecodeTlv(byte[] bytes)
        {
            return Decode(bytes, new List<Lwm2mResource>());
        }

        /// <summary>
        /// Decode
        /// </summary>
        /// <param name="bytes">bytes</param>
        /// <param name="result">result</param>
        /// <param name="path">path</param>
        /// <returns>JsonObject with decoded data</returns>
        private List<Lwm2mResource> Decode(byte[] bytes, List<Lwm2mResource> result, string path = "")
        {
            if (!bytes.Any())
            {
                return result;
            }

            if (result == null)
            {
                result = new List<Lwm2mResource>();
            }

            var byteVal = bytes[0];
            var type = byteVal & typeMask;
            var idLength = FindIdLength(byteVal);
            var length = FindValueLength(byteVal);

            var offset = 1;
            var idSlice = bytes.Skip(offset).Take(offset);
            var id = idSlice.Aggregate<byte, int, int>(0, (x, y, index) => CombineBytes(x, y, index, idSlice.Count()));
            offset = offset + idLength;

            var valueLength = length;
            if ((byteVal & lengthTypeMask) != TypesHelper.GetLengthTypeBinary(LengthTypeEnum.OTR_BYTE))
            {
                var slice = bytes.Skip(offset).Take(length);
                valueLength = slice.Aggregate<byte, int, int>(0, (x, y, index) => CombineBytes(x, y, index, slice.Count()));
                offset = offset + length;
            }

            if (type == TypesHelper.GetTypeBinary(TypesEnum.MULT_RESOURCE))
            {
                Decode(bytes.Skip(offset).Take(valueLength).ToArray(), result, $"{path}/{id}");
            }
            else
            {
                var valueBytes = bytes.Skip(offset).Take(valueLength);
                var hasZero = valueBytes.Any(b => b == 0);
                var value = hasZero ? valueBytes.Aggregate<byte, int, int>(0, (x, y, index) => CombineBytes(x, y, index, valueBytes.Count())).ToString() : string.Join(string.Empty, valueBytes.Select(s => GetString(s)).ToArray());
                result.Add(new Lwm2mResource($"{path}/{id}", value));
            }

            offset = offset + valueLength;
            var bit = bytes.Skip(offset).ToArray();
            Decode(bit, result, path);

            return result;
        }
    }
}