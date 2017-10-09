// <copyright file="DecodingException.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Exceptions
{
    using System;

    /// <summary>
    /// Decoding Exception
    /// </summary>
    public class DecodingException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DecodingException"/> class.
        /// </summary>
        /// <param name="message">Message</param>
        public DecodingException(string message)
         : base(message)
        {
        }
    }
}