/* 
 * Device Directory API
 *
 * This is the API Documentation for the mbed device directory update service.
 *
 * OpenAPI spec version: 3
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace device_directory.Model
{
    /// <summary>
    /// DeviceDataPatchRequest
    /// </summary>
    [DataContract]
    public partial class DeviceDataPatchRequest :  IEquatable<DeviceDataPatchRequest>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceDataPatchRequest" /> class.
        /// </summary>
        /// <param name="Description">The description of the device..</param>
        /// <param name="EndpointName">The endpoint name given to the device..</param>
        /// <param name="AutoUpdate">DEPRECATED Mark this device for auto firmware update..</param>
        /// <param name="HostGateway">The endpoint_name of the host gateway, if appropriate..</param>
        /// <param name="_Object">The API resource entity..</param>
        /// <param name="CustomAttributes">Custom attributes(key/value). Up to 5 attributes.</param>
        /// <param name="DeviceKey">Fingerprint of the device certificate..</param>
        /// <param name="EndpointType">The endpoint type of the device - e.g. if the device is a gateway..</param>
        /// <param name="CaId">ID of the issuer of the certificate..</param>
        /// <param name="Name">The name of the device..</param>
        public DeviceDataPatchRequest(string Description = default(string), string EndpointName = default(string), bool? AutoUpdate = default(bool?), string HostGateway = default(string), string _Object = default(string), Dictionary<string, string> CustomAttributes = default(Dictionary<string, string>), string DeviceKey = default(string), string EndpointType = default(string), string CaId = default(string), string Name = default(string))
        {
            this.Description = Description;
            this.EndpointName = EndpointName;
            this.AutoUpdate = AutoUpdate;
            this.HostGateway = HostGateway;
            this._Object = _Object;
            this.CustomAttributes = CustomAttributes;
            this.DeviceKey = DeviceKey;
            this.EndpointType = EndpointType;
            this.CaId = CaId;
            this.Name = Name;
        }
        
        /// <summary>
        /// The description of the device.
        /// </summary>
        /// <value>The description of the device.</value>
        [DataMember(Name="description", EmitDefaultValue=false)]
        public string Description { get; set; }
        /// <summary>
        /// The endpoint name given to the device.
        /// </summary>
        /// <value>The endpoint name given to the device.</value>
        [DataMember(Name="endpoint_name", EmitDefaultValue=false)]
        public string EndpointName { get; set; }
        /// <summary>
        /// DEPRECATED Mark this device for auto firmware update.
        /// </summary>
        /// <value>DEPRECATED Mark this device for auto firmware update.</value>
        [DataMember(Name="auto_update", EmitDefaultValue=false)]
        public bool? AutoUpdate { get; set; }
        /// <summary>
        /// The endpoint_name of the host gateway, if appropriate.
        /// </summary>
        /// <value>The endpoint_name of the host gateway, if appropriate.</value>
        [DataMember(Name="host_gateway", EmitDefaultValue=false)]
        public string HostGateway { get; set; }
        /// <summary>
        /// The API resource entity.
        /// </summary>
        /// <value>The API resource entity.</value>
        [DataMember(Name="object", EmitDefaultValue=false)]
        public string _Object { get; set; }
        /// <summary>
        /// Custom attributes(key/value). Up to 5 attributes
        /// </summary>
        /// <value>Custom attributes(key/value). Up to 5 attributes</value>
        [DataMember(Name="custom_attributes", EmitDefaultValue=false)]
        public Dictionary<string, string> CustomAttributes { get; set; }
        /// <summary>
        /// Fingerprint of the device certificate.
        /// </summary>
        /// <value>Fingerprint of the device certificate.</value>
        [DataMember(Name="device_key", EmitDefaultValue=false)]
        public string DeviceKey { get; set; }
        /// <summary>
        /// The endpoint type of the device - e.g. if the device is a gateway.
        /// </summary>
        /// <value>The endpoint type of the device - e.g. if the device is a gateway.</value>
        [DataMember(Name="endpoint_type", EmitDefaultValue=false)]
        public string EndpointType { get; set; }
        /// <summary>
        /// ID of the issuer of the certificate.
        /// </summary>
        /// <value>ID of the issuer of the certificate.</value>
        [DataMember(Name="ca_id", EmitDefaultValue=false)]
        public string CaId { get; set; }
        /// <summary>
        /// The name of the device.
        /// </summary>
        /// <value>The name of the device.</value>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class DeviceDataPatchRequest {\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  EndpointName: ").Append(EndpointName).Append("\n");
            sb.Append("  AutoUpdate: ").Append(AutoUpdate).Append("\n");
            sb.Append("  HostGateway: ").Append(HostGateway).Append("\n");
            sb.Append("  _Object: ").Append(_Object).Append("\n");
            sb.Append("  CustomAttributes: ").Append(CustomAttributes).Append("\n");
            sb.Append("  DeviceKey: ").Append(DeviceKey).Append("\n");
            sb.Append("  EndpointType: ").Append(EndpointType).Append("\n");
            sb.Append("  CaId: ").Append(CaId).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            return this.Equals(obj as DeviceDataPatchRequest);
        }

        /// <summary>
        /// Returns true if DeviceDataPatchRequest instances are equal
        /// </summary>
        /// <param name="other">Instance of DeviceDataPatchRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DeviceDataPatchRequest other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.Description == other.Description ||
                    this.Description != null &&
                    this.Description.Equals(other.Description)
                ) && 
                (
                    this.EndpointName == other.EndpointName ||
                    this.EndpointName != null &&
                    this.EndpointName.Equals(other.EndpointName)
                ) && 
                (
                    this.AutoUpdate == other.AutoUpdate ||
                    this.AutoUpdate != null &&
                    this.AutoUpdate.Equals(other.AutoUpdate)
                ) && 
                (
                    this.HostGateway == other.HostGateway ||
                    this.HostGateway != null &&
                    this.HostGateway.Equals(other.HostGateway)
                ) && 
                (
                    this._Object == other._Object ||
                    this._Object != null &&
                    this._Object.Equals(other._Object)
                ) && 
                (
                    this.CustomAttributes == other.CustomAttributes ||
                    this.CustomAttributes != null &&
                    this.CustomAttributes.SequenceEqual(other.CustomAttributes)
                ) && 
                (
                    this.DeviceKey == other.DeviceKey ||
                    this.DeviceKey != null &&
                    this.DeviceKey.Equals(other.DeviceKey)
                ) && 
                (
                    this.EndpointType == other.EndpointType ||
                    this.EndpointType != null &&
                    this.EndpointType.Equals(other.EndpointType)
                ) && 
                (
                    this.CaId == other.CaId ||
                    this.CaId != null &&
                    this.CaId.Equals(other.CaId)
                ) && 
                (
                    this.Name == other.Name ||
                    this.Name != null &&
                    this.Name.Equals(other.Name)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            // credit: http://stackoverflow.com/a/263416/677735
            unchecked // Overflow is fine, just wrap
            {
                int hash = 41;
                // Suitable nullity checks etc, of course :)
                if (this.Description != null)
                    hash = hash * 59 + this.Description.GetHashCode();
                if (this.EndpointName != null)
                    hash = hash * 59 + this.EndpointName.GetHashCode();
                if (this.AutoUpdate != null)
                    hash = hash * 59 + this.AutoUpdate.GetHashCode();
                if (this.HostGateway != null)
                    hash = hash * 59 + this.HostGateway.GetHashCode();
                if (this._Object != null)
                    hash = hash * 59 + this._Object.GetHashCode();
                if (this.CustomAttributes != null)
                    hash = hash * 59 + this.CustomAttributes.GetHashCode();
                if (this.DeviceKey != null)
                    hash = hash * 59 + this.DeviceKey.GetHashCode();
                if (this.EndpointType != null)
                    hash = hash * 59 + this.EndpointType.GetHashCode();
                if (this.CaId != null)
                    hash = hash * 59 + this.CaId.GetHashCode();
                if (this.Name != null)
                    hash = hash * 59 + this.Name.GetHashCode();
                return hash;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        { 
            // EndpointName (string) maxLength
            if(this.EndpointName != null && this.EndpointName.Length > 64)
            {
                yield return new ValidationResult("Invalid value for EndpointName, length must be less than 64.", new [] { "EndpointName" });
            }

            // DeviceKey (string) maxLength
            if(this.DeviceKey != null && this.DeviceKey.Length > 512)
            {
                yield return new ValidationResult("Invalid value for DeviceKey, length must be less than 512.", new [] { "DeviceKey" });
            }

            // EndpointType (string) maxLength
            if(this.EndpointType != null && this.EndpointType.Length > 64)
            {
                yield return new ValidationResult("Invalid value for EndpointType, length must be less than 64.", new [] { "EndpointType" });
            }

            // CaId (string) maxLength
            if(this.CaId != null && this.CaId.Length > 500)
            {
                yield return new ValidationResult("Invalid value for CaId, length must be less than 500.", new [] { "CaId" });
            }

            // Name (string) maxLength
            if(this.Name != null && this.Name.Length > 128)
            {
                yield return new ValidationResult("Invalid value for Name, length must be less than 128.", new [] { "Name" });
            }

            yield break;
        }
    }

}
