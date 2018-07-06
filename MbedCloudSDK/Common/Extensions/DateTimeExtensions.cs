// <copyright file="DateTimeExtensions.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Common.Extensions
{
    using System;

    /// <summary>
    /// DateTimeExceptions
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// To the billing month.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>string></returns>
        public static string ToBillingMonth(this DateTime input)
        {
            if (input == null)
            {
                input = DateTime.Now;
            }

            return $"{input.Year.ToString()}-{input.Month.ToString("00")}";
        }
    }
}