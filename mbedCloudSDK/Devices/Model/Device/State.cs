using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace mbedCloudSDK.Devices.Model.Device
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
        Unenrolled,

        /// <summary>
        /// Enum Cloudenrolling for "cloud_enrolling"
        /// </summary>
        [EnumMember(Value = "cloud_enrolling")]
        Cloudenrolling,

        /// <summary>
        /// Enum Bootstrapped for "bootstrapped"
        /// </summary>
        [EnumMember(Value = "bootstrapped")]
        Bootstrapped,

        /// <summary>
        /// Enum Registered for "registered"
        /// </summary>
        [EnumMember(Value = "registered")]
        Registered
    }
}
