// <copyright file="AccountManagementApi.Account.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>
namespace MbedCloudSDK.TestTag.PSK
{
    using MbedCloudSDK.Common;
    using MbedCloudSDK.Common.Extensions;

    /// <summary>
    /// PSK
    /// </summary>
    public partial class PSK : BaseModel
    {
        /// <summary>
        /// Get human readable string of this object
        /// </summary>
        /// <returns>Serialized string of object</returns>
        public override string ToString() => this.DebugDump();
    }
}