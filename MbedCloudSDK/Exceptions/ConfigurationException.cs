// <copyright file="ConfigurationException.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Exceptions
{
    using System;

    /// <summary>
    /// ConfigurationException
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class ConfigurationException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationException"/> class.
        /// </summary>
        /// <param name="message">Message</param>
        public ConfigurationException(string message)
         : base(message)
        {
        }
    }
}