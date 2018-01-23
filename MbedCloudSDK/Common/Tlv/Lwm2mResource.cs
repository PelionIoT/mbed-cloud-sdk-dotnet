// <copyright file="Lwm2mResource.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Common.Tlv
{
    using System;
    using System.IO;
    using System.Text;

    /// <summary>
    /// Lwm2mResource
    /// </summary>
    public class Lwm2mResource
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Lwm2mResource"/> class.
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="value">Value</param>
        public Lwm2mResource(string id, byte[] value)
        {
            Id = id;
            Value = value;
            Type = Lwm2mResourceTypeEnum.OPAQUE;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Lwm2mResource"/> class.
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="value">Value</param>
        public Lwm2mResource(string id, string value)
        {
            Id = id;
            Value = Encoding.UTF8.GetBytes(value);
            Type = Lwm2mResourceTypeEnum.STRING;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Lwm2mResource"/> class.
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="value">Value</param>
        public Lwm2mResource(string id, int value)
        {
            Id = id;
            Type = Lwm2mResourceTypeEnum.INT;
            Value = BitConverter.GetBytes(value);
        }

        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        /// <returns>Id</returns>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the value
        /// </summary>
        /// <returns>Id</returns>
        public byte[] Value { get; set; }

        /// <summary>
        /// Gets or sets the Lwm2mResourceTypeEnum
        /// </summary>
        /// <returns>Type</returns>
        public Lwm2mResourceTypeEnum Type { get; set; }

        /// <summary>
        /// Get string value
        /// </summary>
        /// <returns>string</returns>
        public string GetStringValue()
        {
            if (Type == Lwm2mResourceTypeEnum.INT || Type == Lwm2mResourceTypeEnum.OPAQUE)
            {
                var val = GetIntFromBytes(Value);
                return Convert.ToString(val);
            }
            else
            {
                return Encoding.UTF8.GetString(Value);
            }
        }

        /// <summary>
        /// Get hex string
        /// </summary>
        /// <returns>string</returns>
        public int GetIntValue()
        {
            if (Type == Lwm2mResourceTypeEnum.STRING)
            {
                try
                {
                    var val = Encoding.UTF8.GetString(Value);
                    return Convert.ToInt32(val);
                }
                catch (Exception)
                {
                    return GetIntFromBytes(Value);
                }
            }

            return GetIntFromBytes(Value);
        }

        private static int GetIntFromBytes(byte[] val)
        {
            if (val.Length < 4)
            {
                var temp = new byte[4];
                val.CopyTo(temp, 0);
                return BitConverter.ToInt32(temp, 0);
            }

            return BitConverter.ToInt32(val, 0);
        }
    }
}