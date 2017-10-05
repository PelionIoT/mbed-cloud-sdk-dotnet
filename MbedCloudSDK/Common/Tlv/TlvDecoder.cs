// <copyright file="TlvDecoder.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Common.Tlv
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
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
        /// Decode
        /// </summary>
        /// <param name="bytes">bytes</param>
        /// <param name="result">result</param>
        /// <param name="path">path</param>
        /// <returns>JsonObject with decoded data</returns>
        public List<Lwm2mResource> Decode(List<byte> bytes, List<Lwm2mResource> result, string path = "")
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
            var id = bytes.Skip(offset).Take(offset).Aggregate<byte, int, int>(0, (x, y, index) => CombineBytes(x, y, index, offset - offset + 1));
            offset = offset + length;

            var valueLength = length;
            if ((byteVal & lengthTypeMask) != TypesHelper.GetLengthTypeBinary(LengthTypeEnum.OTR_BYTE))
            {
                valueLength = bytes.Skip(offset).Take(length).Aggregate<byte, int, int>(0, (x, y, index) => CombineBytes(x, y, index, length - offset + 1));
                offset = offset + length;
            }

            if (type == TypesHelper.GetTypeBinary(TypesEnum.MULT_RESOURCE))
            {
                Decode(bytes.Skip(offset).Take(valueLength).ToList(), result, $"{path}/{id}");
            }
            else
            {
                var valueBytes = bytes.Skip(offset).Take(valueLength);
                var hasZero = valueBytes.Any(b => b == 0);
                var value = hasZero ? valueBytes.Aggregate<byte, int, int>(0, (x, y, index) => CombineBytes(x, y, index, valueLength - offset + 1)).ToString() : string.Join(string.Empty, valueBytes.Select(s => GetString(s)).ToArray());
                result.Add(new Lwm2mResource(id, value));
            }

            offset = offset + valueLength;
            var bit = bytes.Skip(offset).ToList();
            Decode(bit, result, path);

            return result;
        }
    }
}