// <copyright file="NameOverrideAttribute.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Common
{
    using System;

    /// <summary>
    /// Name Override Attribute
    /// Used for occasions where there is a difference in naming between the test server and sdk
    /// </summary>
    public class NameOverrideAttribute : Attribute
    {
        /// <summary>
        /// Gets or sets name to apply to attribute
        /// </summary>
        public string Name { get; set; }
    }
}
