// <copyright file="DeliveryMethod.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Connect.Model.Enums
{
    /// <summary>
    /// DeliveryMethod
    /// </summary>
    public enum DeliveryMethod
    {
        /// <summary>
        /// Notifications are fetched via long polling
        /// </summary>
        CLIENT_INITIATED,

        /// <summary>
        /// Notifications arrive via a webhook
        /// </summary>
        SERVER_INITIATED,
    }
}