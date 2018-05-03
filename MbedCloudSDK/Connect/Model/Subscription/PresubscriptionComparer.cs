// <copyright file="Presubscription.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Connect.Model.Subscription
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using MbedCloudSDK.Common.Extensions;
    using MbedCloudSDK.Connect.Model.Notifications;

    public class PresubscriptionComparer : IEqualityComparer<Presubscription>
    {
        public bool Equals(Presubscription x, Presubscription y)
        {
            return x.DeviceId == y.DeviceId && x.ResourcePaths.SequenceEqual(y.ResourcePaths);
        }

        public int GetHashCode(Presubscription obj)
        {
            Console.WriteLine(obj.GetHashCode());
            return obj.GetHashCode();
        }
    }
}