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
            using (var stream = new MemoryStream())
            {
                using (var writer = new StreamWriter(stream))
                {
                    if ((value & 0xFF000000) != 0)
                    {
                        writer.Write((value & 0xFF000000) >> 24);
                        writer.Flush();
                    }

                    if ((value & 0xFFFF0000) != 0)
                    {
                        writer.Write((value & 0xFF000000) >> 16);
                        writer.Flush();
                    }

                    if ((value & 0xFFFFFF00) != 0)
                    {
                        writer.Write((value & 0xFF000000) >> 8);
                        writer.Flush();
                    }

                    writer.Write(value & 0x000000FF);
                    writer.Flush();

                    Value = stream.ToArray();
                }
            }
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
            if (Type == Lwm2mResourceTypeEnum.INT)
            {
                var val = 0;
                foreach (var element in Value)
                {
                    val = (val << 8) + (element & 0xFF);
                }

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
        public int GetHexValue()
        {
            if (Value.Length < 4)
            {
                var temp = new byte[4];
                Value.CopyTo(temp, 0);
                return BitConverter.ToInt32(temp, 0);
            }

            return BitConverter.ToInt32(Value, 0);
        }
    }
}