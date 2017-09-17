// <copyright file="NameOverrideAttribute.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

using System;

namespace MbedCloudSDK.Common
{
    public class NameOverrideAttribute : Attribute
    {
        public string Name { get; set; }
    }
}
