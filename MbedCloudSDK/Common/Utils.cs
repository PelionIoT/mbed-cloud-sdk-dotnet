// <copyright file="Utils.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Common
{
    using System;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Text;
    using MbedCloudSDK.Common.Tlv;
    using MbedCloudSDK.Connect.Model.Notifications;
    using MbedCloudSDK.Exceptions;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Utils
    /// A set of utility functions
    /// </summary>
    internal static class Utils
    {
        /// <summary>
        /// Handles the not found.
        /// </summary>
        /// <typeparam name="T">Return type</typeparam>
        /// <typeparam name="E">The exception type</typeparam>
        /// <param name="e">The exception.</param>
        /// <returns>Return type</returns>
        /// <exception cref="CloudApiException">The exception</exception>
        public static T HandleNotFound<T, E>(dynamic e)
         where E : Exception
        {
            if (e.ErrorCode == 404)
            {
                return default;
            }

            throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
        }
    }
}