// <copyright file="ResponseExtensions.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Common.Extensions
{
    using System;
    using System.Text;
    using MbedCloudSDK.Common.Tlv;
    using MbedCloudSDK.Connect.Model.Notifications;

    /// <summary>
    /// ResponseExtensions
    /// </summary>
    public static class ResponseExtensions
    {
        /// <summary>
        /// Decode a base 64 payload
        /// </summary>
        /// <param name="asyncResponse">The response object</param>
        /// <returns>String of payload</returns>
        public static string DecodeBase64(this AsyncIdResponse asyncResponse)
        {
            return DecodeBase64(asyncResponse.ContentType, asyncResponse.Payload, new TlvDecoder());
        }

        /// <summary>
        /// Decode a base64 payload from notification data
        /// </summary>
        /// <param name="notificationData">the notification</param>
        /// <returns>decoded payload</returns>
        public static string DecodeBase64(this NotificationData notificationData)
        {
            return DecodeBase64(notificationData.ContentType, notificationData.Payload, new TlvDecoder());
        }

        private static string DecodeBase64(string contentType, string payload, TlvDecoder tlvDecoder)
        {
            if (!string.IsNullOrEmpty(contentType))
            {
                if (contentType.Contains("tlv"))
                {
                    payload = tlvDecoder.DecodeTlvFromString(payload);
                }
                else
                {
                    var data = Convert.FromBase64String(payload ?? "");
                    payload = Encoding.UTF8.GetString(data);
                }
            }
            else
            {
                var data = Convert.FromBase64String(payload ?? "");
                payload = Encoding.UTF8.GetString(data);
            }

            return payload;
        }
    }
}