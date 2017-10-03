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
            return Convert.ToString(value);
        }

        /// <summary>
        /// Combine Bytes
        /// </summary>
        /// <param name="accumalatedValue">accumalatedValue</param>
        /// <param name="currentValue">currentValue</param>
        /// <param name="index">index</param>
        /// <param name="array">array</param>
        /// <returns>Int value of bytes</returns>
        public static int CombineBytes(int accumalatedValue, int currentValue, int index, List<int> array)
        {
            var step = array.Count() - index - 1;
            return accumalatedValue + (currentValue << (8 * step));
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
        public JObject Decode(List<int> bytes, JObject result, string path = "")
        {
            if (result == null)
            {
                result = new JObject();
            }

            var @byte = bytes[0];
            var type = @byte & typeMask;
            var idLength = FindIdLength(@byte);
            var length = FindValueLength(@byte);

            var offset = 1;
            var id = bytes.Skip(offset).Take(offset + idLength).Aggregate<int, int, int>(0, (x, y, index) => CombineBytes(x, y, index, bytes));
            offset = offset + length;

            var valueLength = length;
            if ((@byte & lengthTypeMask) != TypesHelper.GetLengthTypeBinary(LengthTypeEnum.OTR_BYTE))
            {
                valueLength = bytes.Skip(offset).Take(offset + valueLength).Aggregate<int, int, int>(0, (x, y, index) => CombineBytes(x, y, index, bytes));
                offset = offset + length;
            }

            if (type == TypesHelper.GetTypeBinary(TypesEnum.MULT_RESOURCE))
            {
                Decode(bytes.Skip(offset).Take(offset + valueLength).ToList(), result, $"{path}/{id}");
            }
            else
            {
                var valueBytes = bytes.Skip(offset).Take(offset + valueLength);
                var hasZero = valueBytes.Any(b => b == 0);
                var value = hasZero ? valueBytes.Aggregate<int, int, int>(0, (x, y, index) => CombineBytes(x, y, index, bytes)).ToString() : string.Join(string.Empty, valueBytes.Select(s => GetString(s)).ToArray());
                result.Add($"{path}/{id}", value);
            }

            offset = offset + valueLength;
            Decode(bytes.Take(offset).ToList(), result, path);

            return result;
        }
    }
}