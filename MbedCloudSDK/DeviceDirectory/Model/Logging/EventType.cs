// <copyright file="EventType.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

using System.Runtime.Serialization;

namespace MbedCloudSDK.DeviceDirectory.Model.Logging
{
    /// <summary>
    /// Logging event type.
    /// </summary>
    public enum EventType
    {
        /// <summary>
        /// Enum DeviceDevicecreated for "update.device.device-created"
        /// </summary>
        [EnumMember(Value = "update.device.device-created")]
        DeviceDevicecreated,

        /// <summary>
        /// Enum DeviceDeviceupdated for "update.device.device-updated"
        /// </summary>
        [EnumMember(Value = "update.device.device-updated")]
        DeviceDeviceupdated,

        /// <summary>
        /// Enum DeploymentCampaigndevicemetadatacreated for "update.deployment.campaign-device-metadata-created"
        /// </summary>
        [EnumMember(Value = "update.deployment.campaign-device-metadata-created")]
        DeploymentCampaigndevicemetadatacreated,

        /// <summary>
        /// Enum DeploymentCampaigndevicemetadataupdated for "update.deployment.campaign-device-metadata-updated"
        /// </summary>
        [EnumMember(Value = "update.deployment.campaign-device-metadata-updated")]
        DeploymentCampaigndevicemetadataupdated,

        /// <summary>
        /// Enum DeploymentCampaigndevicemetadataremoved for "update.deployment.campaign-device-metadata-removed"
        /// </summary>
        [EnumMember(Value = "update.deployment.campaign-device-metadata-removed")]
        DeploymentCampaigndevicemetadataremoved,

        /// <summary>
        /// Enum ConnectorConnectordeviceFirmwareupdateState for "update.connector.connector-device.firmware-update.state"
        /// </summary>
        [EnumMember(Value = "update.connector.connector-device.firmware-update.state")]
        ConnectorConnectordeviceFirmwareupdateState,

        /// <summary>
        /// Enum ConnectorConnectordeviceFirmwareupdateResult for "update.connector.connector-device.firmware-update.result"
        /// </summary>
        [EnumMember(Value = "update.connector.connector-device.firmware-update.result")]
        ConnectorConnectordeviceFirmwareupdateResult
    }
}
