// <copyright file="ResourceValuesFilter.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Connect.Api.Subscribe.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using MbedCloudSDK.Common;
    using MbedCloudSDK.Common.Extensions;
    using MbedCloudSDK.Connect.Model.Notifications;
    using MbedCloudSDK.Connect.Model.Subscription;

    public class ResourceValuesFilterComparer : IEqualityComparer<ResourceValuesFilter>
    {
        public bool Equals(ResourceValuesFilter x, ResourceValuesFilter y)
        {
            return x.DeviceId == y.DeviceId && x.ResourcePaths.SequenceEqual(y.ResourcePaths);
        }

        public int GetHashCode(ResourceValuesFilter obj)
        {
            return obj.GetHashCode();
        }
    }
}