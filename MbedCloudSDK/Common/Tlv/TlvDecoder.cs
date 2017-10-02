using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Newtonsoft.Json.Linq;

namespace MbedCloudSDK.Common.Tlv
{
    public class TlvDecoder
    {
        private int TypeMask = Convert.ToInt32("11000000", 2);
        private int IdLengthMask = Convert.ToInt32("00100000", 2);
        private int LengthTypeMask = Convert.ToInt32("00011000", 2);
        private int LengthMask = Convert.ToInt32("00000111", 2);
        private int aggCount = 0;

        public int FindIdLength(int @byte)
        {
            return (@byte & IdLengthMask) == IdLengthMask ? 2 : 1;
        }

        public int FindValueLength(int @byte)
        {
            if((@byte & LengthTypeMask) == TypesHelper.GetLengthTypeBinary(LengthType.ONE_BYTE))
            {
                return 1;
            }
            else if ((@byte & LengthTypeMask) == TypesHelper.GetLengthTypeBinary(LengthType.TWO_BYTE))
            {
                return 2;
            }
            else if ((@byte & LengthTypeMask) == TypesHelper.GetLengthTypeBinary(LengthType.TRE_BYTE))
            {
                return 3;
            }
            else
            {
                return (@byte & LengthMask);
            }
        }

        public string GetString(int value)
        {
            return Convert.ToString(value);
        }

        public int CombineBytes(int accumalatedValue, int currentValue, int index, List<int> array)
        {
            var step = array.Count() - aggCount - 1;
            aggCount += 1;
            return accumalatedValue + (currentValue << (8 * step));
        }

        public JObject decode(List<int> bytes, JObject result, string path = "")
        {
            if (result == null)
            {
                result = new JObject();
            }

            var @byte = bytes[0];
            var type = @byte & TypeMask;
            var IdLength = FindIdLength(@byte);
            var Length = FindValueLength(@byte);

            var offset = 1;
            var id = bytes.Skip(offset).Take(offset + IdLength).Aggregate(0, (x, y, index) => CombineBytes(x, y, index, bytes));
            offset = offset + Length;

            var ValueLength = Length;
            if((@byte & LengthTypeMask) != TypesHelper.GetLengthTypeBinary(LengthType.OTR_BYTE))
            {
                aggCount = 0;
                ValueLength = bytes.Skip(offset).Take(offset + ValueLength).Aggregate(0, (x, y, index) => CombineBytes(x, y, index, bytes));
                offset = offset + Length;
            }

            if(type == TypesHelper.GetTypeBinary(Types.MULT_RESOURCE))
            {
                decode(bytes.Skip(offset).Take(offset + ValueLength).ToList(), result, $"{path}/{id}");
            }
            else
            {
                var ValueBytes = bytes.Skip(offset).Take(offset + ValueLength);
                var HasZero = ValueBytes.Any(b => b == 0);
                aggCount = 0;
                var value = HasZero ? ValueBytes.Aggregate(0, (x, y, index) => CombineBytes(x, y, index, bytes)).ToString() : String.Join(String.Empty, ValueBytes.Select(s => GetString(s)).ToArray());
                result.Add($"{path}/{id}", value);
            }

            offset = offset + ValueLength;
            decode(bytes.Take(offset).ToList(), result, path);

            return result;
        }
    }

    public enum Types
    {
        [EnumMember(Value = "00000000")]
        OBJECT_INSTAN,
        [EnumMember(Value = "01000000")]
        RESOURCE_INST,
        [EnumMember(Value = "10000000")]
        MULT_RESOURCE,
        [EnumMember(Value = "11000000")]
        RESOURCE_VALU
    }

    public static class TypesHelper
    {
        public static int GetTypeBinary(Types value)
        {
            var enumValue = Utils.GetEnumMemberValue(typeof(Types), Convert.ToString(value));
            return Convert.ToInt32(enumValue, 2);
        }

        public static int GetLengthTypeBinary(LengthType value)
        {
            var enumValue = Utils.GetEnumMemberValue(typeof(LengthType), Convert.ToString(value));
            return Convert.ToInt32(enumValue, 2);
        }
    }

    public enum LengthType
    {
        [EnumMember(Value = "00001000")]
        ONE_BYTE,
        [EnumMember(Value = "00010000")]
        TWO_BYTE,
        [EnumMember(Value = "00011000")]
        TRE_BYTE,
        [EnumMember(Value = "00000000")]
        OTR_BYTE
    }

    public static class EnumerableExtensions
    {
        public static TAccumulate Aggregate<TSource, TAccumulate, TResult>(
        this IEnumerable<TSource> source,
        TAccumulate seed,
        Func<TAccumulate, TSource, int, TAccumulate> func)
        {
            //if (source == null) throw Error.ArgumentNull("source");
            //if (func == null) throw Error.ArgumentNull("func");
            //if (resultSelector == null) throw Error.ArgumentNull("resultSelector");
            var index = 0;
            var result = seed;
            foreach (TSource element in source)
            {
                result = func(result, element, index);
                index += 1;
            }
            return result;
        }
    }
}