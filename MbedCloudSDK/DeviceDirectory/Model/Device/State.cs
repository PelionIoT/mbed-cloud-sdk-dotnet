using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MbedCloudSDK.DeviceDirectory.Model.Device
{
    /// <summary>
    /// The current state of the device
    /// </summary>
    public enum State
    {
        /// <summary>
        /// Enum Unenrolled for "unenrolled"
        /// </summary>
        [EnumMember(Value = "unenrolled")]
        unenrolled,

        /// <summary>
        /// Enum Cloudenrolling for "cloud_enrolling"
        /// </summary>
        [EnumMember(Value = "cloud_enrolling")]
        cloud_enrolling,

        /// <summary>
        /// Enum Bootstrapped for "bootstrapped"
        /// </summary>
        [EnumMember(Value = "bootstrapped")]
        bootstrapped,

        /// <summary>
        /// Enum Registered for "registered"
        /// </summary>
        [EnumMember(Value = "registered")]
        registered,

        /// <summary>
        /// Enum Deregistered for "deregistered"
        /// </summary>
        [EnumMember(Value = "deregistered")]
        deregistered

    }
}
