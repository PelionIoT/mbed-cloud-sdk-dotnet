/* 
 * <auto-generated>
 * Device Directory API
 *
 * This is the API Documentation for the Mbed Device Directory service.
 *
 * OpenAPI spec version: 3
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 * </auto-generated>
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
using SwaggerDateConverter = device_directory.Client.SwaggerDateConverter;

namespace device_directory.Model
{
    /// <summary>
    /// DeviceInNinFilter
    /// </summary>
    [DataContract]
    public partial class DeviceInNinFilter :  IEquatable<DeviceInNinFilter>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceInNinFilter" /> class.
        /// </summary>
        /// <param name="AccountId">AccountId.</param>
        /// <param name="AutoUpdate">AutoUpdate.</param>
        /// <param name="BootstrapExpirationDate">BootstrapExpirationDate.</param>
        /// <param name="BootstrappedTimestamp">BootstrappedTimestamp.</param>
        /// <param name="CaId">CaId.</param>
        /// <param name="ConnectorExpirationDate">ConnectorExpirationDate.</param>
        /// <param name="CreatedAt">CreatedAt.</param>
        /// <param name="CustomAttributes">CustomAttributes.</param>
        /// <param name="DeployedState">DeployedState.</param>
        /// <param name="Deployment">Deployment.</param>
        /// <param name="Description">Description.</param>
        /// <param name="DeviceClass">DeviceClass.</param>
        /// <param name="DeviceExecutionMode">DeviceExecutionMode.</param>
        /// <param name="DeviceKey">DeviceKey.</param>
        /// <param name="EndpointName">EndpointName.</param>
        /// <param name="EndpointType">EndpointType.</param>
        /// <param name="EnrolmentListTimestamp">EnrolmentListTimestamp.</param>
        /// <param name="Etag">Etag.</param>
        /// <param name="FirmwareChecksum">FirmwareChecksum.</param>
        /// <param name="HostGateway">HostGateway.</param>
        /// <param name="Id">Id.</param>
        /// <param name="Manifest">Manifest.</param>
        /// <param name="ManifestTimestamp">ManifestTimestamp.</param>
        /// <param name="Mechanism">Mechanism.</param>
        /// <param name="MechanismUrl">MechanismUrl.</param>
        /// <param name="Name">Name.</param>
        /// <param name="SerialNumber">SerialNumber.</param>
        /// <param name="State">State.</param>
        /// <param name="UpdatedAt">UpdatedAt.</param>
        /// <param name="VendorId">VendorId.</param>
        public DeviceInNinFilter(string AccountId = default(string), bool? AutoUpdate = default(bool?), DateTime? BootstrapExpirationDate = default(DateTime?), DateTime? BootstrappedTimestamp = default(DateTime?), string CaId = default(string), DateTime? ConnectorExpirationDate = default(DateTime?), DateTime? CreatedAt = default(DateTime?), Dictionary<string, string> CustomAttributes = default(Dictionary<string, string>), string DeployedState = default(string), string Deployment = default(string), string Description = default(string), string DeviceClass = default(string), int? DeviceExecutionMode = default(int?), string DeviceKey = default(string), string EndpointName = default(string), string EndpointType = default(string), DateTime? EnrolmentListTimestamp = default(DateTime?), DateTime? Etag = default(DateTime?), string FirmwareChecksum = default(string), string HostGateway = default(string), string Id = default(string), string Manifest = default(string), DateTime? ManifestTimestamp = default(DateTime?), string Mechanism = default(string), string MechanismUrl = default(string), string Name = default(string), string SerialNumber = default(string), string State = default(string), DateTime? UpdatedAt = default(DateTime?), string VendorId = default(string))
        {
            this.AccountId = AccountId;
            this.AutoUpdate = AutoUpdate;
            this.BootstrapExpirationDate = BootstrapExpirationDate;
            this.BootstrappedTimestamp = BootstrappedTimestamp;
            this.CaId = CaId;
            this.ConnectorExpirationDate = ConnectorExpirationDate;
            this.CreatedAt = CreatedAt;
            this.CustomAttributes = CustomAttributes;
            this.DeployedState = DeployedState;
            this.Deployment = Deployment;
            this.Description = Description;
            this.DeviceClass = DeviceClass;
            this.DeviceExecutionMode = DeviceExecutionMode;
            this.DeviceKey = DeviceKey;
            this.EndpointName = EndpointName;
            this.EndpointType = EndpointType;
            this.EnrolmentListTimestamp = EnrolmentListTimestamp;
            this.Etag = Etag;
            this.FirmwareChecksum = FirmwareChecksum;
            this.HostGateway = HostGateway;
            this.Id = Id;
            this.Manifest = Manifest;
            this.ManifestTimestamp = ManifestTimestamp;
            this.Mechanism = Mechanism;
            this.MechanismUrl = MechanismUrl;
            this.Name = Name;
            this.SerialNumber = SerialNumber;
            this.State = State;
            this.UpdatedAt = UpdatedAt;
            this.VendorId = VendorId;
        }
        
        /// <summary>
        /// Gets or Sets AccountId
        /// </summary>
        [DataMember(Name="account_id", EmitDefaultValue=false)]
        public string AccountId { get; set; }

        /// <summary>
        /// Gets or Sets AutoUpdate
        /// </summary>
        [DataMember(Name="auto_update", EmitDefaultValue=false)]
        public bool? AutoUpdate { get; set; }

        /// <summary>
        /// Gets or Sets BootstrapExpirationDate
        /// </summary>
        [DataMember(Name="bootstrap_expiration_date", EmitDefaultValue=false)]
        public DateTime? BootstrapExpirationDate { get; set; }

        /// <summary>
        /// Gets or Sets BootstrappedTimestamp
        /// </summary>
        [DataMember(Name="bootstrapped_timestamp", EmitDefaultValue=false)]
        public DateTime? BootstrappedTimestamp { get; set; }

        /// <summary>
        /// Gets or Sets CaId
        /// </summary>
        [DataMember(Name="ca_id", EmitDefaultValue=false)]
        public string CaId { get; set; }

        /// <summary>
        /// Gets or Sets ConnectorExpirationDate
        /// </summary>
        [DataMember(Name="connector_expiration_date", EmitDefaultValue=false)]
        public DateTime? ConnectorExpirationDate { get; set; }

        /// <summary>
        /// Gets or Sets CreatedAt
        /// </summary>
        [DataMember(Name="created_at", EmitDefaultValue=false)]
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Gets or Sets CustomAttributes
        /// </summary>
        [DataMember(Name="custom_attributes", EmitDefaultValue=false)]
        public Dictionary<string, string> CustomAttributes { get; set; }

        /// <summary>
        /// Gets or Sets DeployedState
        /// </summary>
        [DataMember(Name="deployed_state", EmitDefaultValue=false)]
        public string DeployedState { get; set; }

        /// <summary>
        /// Gets or Sets Deployment
        /// </summary>
        [DataMember(Name="deployment", EmitDefaultValue=false)]
        public string Deployment { get; set; }

        /// <summary>
        /// Gets or Sets Description
        /// </summary>
        [DataMember(Name="description", EmitDefaultValue=false)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets DeviceClass
        /// </summary>
        [DataMember(Name="device_class", EmitDefaultValue=false)]
        public string DeviceClass { get; set; }

        /// <summary>
        /// Gets or Sets DeviceExecutionMode
        /// </summary>
        [DataMember(Name="device_execution_mode", EmitDefaultValue=false)]
        public int? DeviceExecutionMode { get; set; }

        /// <summary>
        /// Gets or Sets DeviceKey
        /// </summary>
        [DataMember(Name="device_key", EmitDefaultValue=false)]
        public string DeviceKey { get; set; }

        /// <summary>
        /// Gets or Sets EndpointName
        /// </summary>
        [DataMember(Name="endpoint_name", EmitDefaultValue=false)]
        public string EndpointName { get; set; }

        /// <summary>
        /// Gets or Sets EndpointType
        /// </summary>
        [DataMember(Name="endpoint_type", EmitDefaultValue=false)]
        public string EndpointType { get; set; }

        /// <summary>
        /// Gets or Sets EnrolmentListTimestamp
        /// </summary>
        [DataMember(Name="enrolment_list_timestamp", EmitDefaultValue=false)]
        public DateTime? EnrolmentListTimestamp { get; set; }

        /// <summary>
        /// Gets or Sets Etag
        /// </summary>
        [DataMember(Name="etag", EmitDefaultValue=false)]
        public DateTime? Etag { get; set; }

        /// <summary>
        /// Gets or Sets FirmwareChecksum
        /// </summary>
        [DataMember(Name="firmware_checksum", EmitDefaultValue=false)]
        public string FirmwareChecksum { get; set; }

        /// <summary>
        /// Gets or Sets HostGateway
        /// </summary>
        [DataMember(Name="host_gateway", EmitDefaultValue=false)]
        public string HostGateway { get; set; }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets Manifest
        /// </summary>
        [DataMember(Name="manifest", EmitDefaultValue=false)]
        public string Manifest { get; set; }

        /// <summary>
        /// Gets or Sets ManifestTimestamp
        /// </summary>
        [DataMember(Name="manifest_timestamp", EmitDefaultValue=false)]
        public DateTime? ManifestTimestamp { get; set; }

        /// <summary>
        /// Gets or Sets Mechanism
        /// </summary>
        [DataMember(Name="mechanism", EmitDefaultValue=false)]
        public string Mechanism { get; set; }

        /// <summary>
        /// Gets or Sets MechanismUrl
        /// </summary>
        [DataMember(Name="mechanism_url", EmitDefaultValue=false)]
        public string MechanismUrl { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets SerialNumber
        /// </summary>
        [DataMember(Name="serial_number", EmitDefaultValue=false)]
        public string SerialNumber { get; set; }

        /// <summary>
        /// Gets or Sets State
        /// </summary>
        [DataMember(Name="state", EmitDefaultValue=false)]
        public string State { get; set; }

        /// <summary>
        /// Gets or Sets UpdatedAt
        /// </summary>
        [DataMember(Name="updated_at", EmitDefaultValue=false)]
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Gets or Sets VendorId
        /// </summary>
        [DataMember(Name="vendor_id", EmitDefaultValue=false)]
        public string VendorId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class DeviceInNinFilter {\n");
            sb.Append("  AccountId: ").Append(AccountId).Append("\n");
            sb.Append("  AutoUpdate: ").Append(AutoUpdate).Append("\n");
            sb.Append("  BootstrapExpirationDate: ").Append(BootstrapExpirationDate).Append("\n");
            sb.Append("  BootstrappedTimestamp: ").Append(BootstrappedTimestamp).Append("\n");
            sb.Append("  CaId: ").Append(CaId).Append("\n");
            sb.Append("  ConnectorExpirationDate: ").Append(ConnectorExpirationDate).Append("\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
            sb.Append("  CustomAttributes: ").Append(CustomAttributes).Append("\n");
            sb.Append("  DeployedState: ").Append(DeployedState).Append("\n");
            sb.Append("  Deployment: ").Append(Deployment).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  DeviceClass: ").Append(DeviceClass).Append("\n");
            sb.Append("  DeviceExecutionMode: ").Append(DeviceExecutionMode).Append("\n");
            sb.Append("  DeviceKey: ").Append(DeviceKey).Append("\n");
            sb.Append("  EndpointName: ").Append(EndpointName).Append("\n");
            sb.Append("  EndpointType: ").Append(EndpointType).Append("\n");
            sb.Append("  EnrolmentListTimestamp: ").Append(EnrolmentListTimestamp).Append("\n");
            sb.Append("  Etag: ").Append(Etag).Append("\n");
            sb.Append("  FirmwareChecksum: ").Append(FirmwareChecksum).Append("\n");
            sb.Append("  HostGateway: ").Append(HostGateway).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Manifest: ").Append(Manifest).Append("\n");
            sb.Append("  ManifestTimestamp: ").Append(ManifestTimestamp).Append("\n");
            sb.Append("  Mechanism: ").Append(Mechanism).Append("\n");
            sb.Append("  MechanismUrl: ").Append(MechanismUrl).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  SerialNumber: ").Append(SerialNumber).Append("\n");
            sb.Append("  State: ").Append(State).Append("\n");
            sb.Append("  UpdatedAt: ").Append(UpdatedAt).Append("\n");
            sb.Append("  VendorId: ").Append(VendorId).Append("\n");
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
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as DeviceInNinFilter);
        }

        /// <summary>
        /// Returns true if DeviceInNinFilter instances are equal
        /// </summary>
        /// <param name="input">Instance of DeviceInNinFilter to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DeviceInNinFilter input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.AccountId == input.AccountId ||
                    (this.AccountId != null &&
                    this.AccountId.Equals(input.AccountId))
                ) && 
                (
                    this.AutoUpdate == input.AutoUpdate ||
                    (this.AutoUpdate != null &&
                    this.AutoUpdate.Equals(input.AutoUpdate))
                ) && 
                (
                    this.BootstrapExpirationDate == input.BootstrapExpirationDate ||
                    (this.BootstrapExpirationDate != null &&
                    this.BootstrapExpirationDate.Equals(input.BootstrapExpirationDate))
                ) && 
                (
                    this.BootstrappedTimestamp == input.BootstrappedTimestamp ||
                    (this.BootstrappedTimestamp != null &&
                    this.BootstrappedTimestamp.Equals(input.BootstrappedTimestamp))
                ) && 
                (
                    this.CaId == input.CaId ||
                    (this.CaId != null &&
                    this.CaId.Equals(input.CaId))
                ) && 
                (
                    this.ConnectorExpirationDate == input.ConnectorExpirationDate ||
                    (this.ConnectorExpirationDate != null &&
                    this.ConnectorExpirationDate.Equals(input.ConnectorExpirationDate))
                ) && 
                (
                    this.CreatedAt == input.CreatedAt ||
                    (this.CreatedAt != null &&
                    this.CreatedAt.Equals(input.CreatedAt))
                ) && 
                (
                    this.CustomAttributes == input.CustomAttributes ||
                    this.CustomAttributes != null &&
                    this.CustomAttributes.SequenceEqual(input.CustomAttributes)
                ) && 
                (
                    this.DeployedState == input.DeployedState ||
                    (this.DeployedState != null &&
                    this.DeployedState.Equals(input.DeployedState))
                ) && 
                (
                    this.Deployment == input.Deployment ||
                    (this.Deployment != null &&
                    this.Deployment.Equals(input.Deployment))
                ) && 
                (
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
                ) && 
                (
                    this.DeviceClass == input.DeviceClass ||
                    (this.DeviceClass != null &&
                    this.DeviceClass.Equals(input.DeviceClass))
                ) && 
                (
                    this.DeviceExecutionMode == input.DeviceExecutionMode ||
                    (this.DeviceExecutionMode != null &&
                    this.DeviceExecutionMode.Equals(input.DeviceExecutionMode))
                ) && 
                (
                    this.DeviceKey == input.DeviceKey ||
                    (this.DeviceKey != null &&
                    this.DeviceKey.Equals(input.DeviceKey))
                ) && 
                (
                    this.EndpointName == input.EndpointName ||
                    (this.EndpointName != null &&
                    this.EndpointName.Equals(input.EndpointName))
                ) && 
                (
                    this.EndpointType == input.EndpointType ||
                    (this.EndpointType != null &&
                    this.EndpointType.Equals(input.EndpointType))
                ) && 
                (
                    this.EnrolmentListTimestamp == input.EnrolmentListTimestamp ||
                    (this.EnrolmentListTimestamp != null &&
                    this.EnrolmentListTimestamp.Equals(input.EnrolmentListTimestamp))
                ) && 
                (
                    this.Etag == input.Etag ||
                    (this.Etag != null &&
                    this.Etag.Equals(input.Etag))
                ) && 
                (
                    this.FirmwareChecksum == input.FirmwareChecksum ||
                    (this.FirmwareChecksum != null &&
                    this.FirmwareChecksum.Equals(input.FirmwareChecksum))
                ) && 
                (
                    this.HostGateway == input.HostGateway ||
                    (this.HostGateway != null &&
                    this.HostGateway.Equals(input.HostGateway))
                ) && 
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
                ) && 
                (
                    this.Manifest == input.Manifest ||
                    (this.Manifest != null &&
                    this.Manifest.Equals(input.Manifest))
                ) && 
                (
                    this.ManifestTimestamp == input.ManifestTimestamp ||
                    (this.ManifestTimestamp != null &&
                    this.ManifestTimestamp.Equals(input.ManifestTimestamp))
                ) && 
                (
                    this.Mechanism == input.Mechanism ||
                    (this.Mechanism != null &&
                    this.Mechanism.Equals(input.Mechanism))
                ) && 
                (
                    this.MechanismUrl == input.MechanismUrl ||
                    (this.MechanismUrl != null &&
                    this.MechanismUrl.Equals(input.MechanismUrl))
                ) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.SerialNumber == input.SerialNumber ||
                    (this.SerialNumber != null &&
                    this.SerialNumber.Equals(input.SerialNumber))
                ) && 
                (
                    this.State == input.State ||
                    (this.State != null &&
                    this.State.Equals(input.State))
                ) && 
                (
                    this.UpdatedAt == input.UpdatedAt ||
                    (this.UpdatedAt != null &&
                    this.UpdatedAt.Equals(input.UpdatedAt))
                ) && 
                (
                    this.VendorId == input.VendorId ||
                    (this.VendorId != null &&
                    this.VendorId.Equals(input.VendorId))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.AccountId != null)
                    hashCode = hashCode * 59 + this.AccountId.GetHashCode();
                if (this.AutoUpdate != null)
                    hashCode = hashCode * 59 + this.AutoUpdate.GetHashCode();
                if (this.BootstrapExpirationDate != null)
                    hashCode = hashCode * 59 + this.BootstrapExpirationDate.GetHashCode();
                if (this.BootstrappedTimestamp != null)
                    hashCode = hashCode * 59 + this.BootstrappedTimestamp.GetHashCode();
                if (this.CaId != null)
                    hashCode = hashCode * 59 + this.CaId.GetHashCode();
                if (this.ConnectorExpirationDate != null)
                    hashCode = hashCode * 59 + this.ConnectorExpirationDate.GetHashCode();
                if (this.CreatedAt != null)
                    hashCode = hashCode * 59 + this.CreatedAt.GetHashCode();
                if (this.CustomAttributes != null)
                    hashCode = hashCode * 59 + this.CustomAttributes.GetHashCode();
                if (this.DeployedState != null)
                    hashCode = hashCode * 59 + this.DeployedState.GetHashCode();
                if (this.Deployment != null)
                    hashCode = hashCode * 59 + this.Deployment.GetHashCode();
                if (this.Description != null)
                    hashCode = hashCode * 59 + this.Description.GetHashCode();
                if (this.DeviceClass != null)
                    hashCode = hashCode * 59 + this.DeviceClass.GetHashCode();
                if (this.DeviceExecutionMode != null)
                    hashCode = hashCode * 59 + this.DeviceExecutionMode.GetHashCode();
                if (this.DeviceKey != null)
                    hashCode = hashCode * 59 + this.DeviceKey.GetHashCode();
                if (this.EndpointName != null)
                    hashCode = hashCode * 59 + this.EndpointName.GetHashCode();
                if (this.EndpointType != null)
                    hashCode = hashCode * 59 + this.EndpointType.GetHashCode();
                if (this.EnrolmentListTimestamp != null)
                    hashCode = hashCode * 59 + this.EnrolmentListTimestamp.GetHashCode();
                if (this.Etag != null)
                    hashCode = hashCode * 59 + this.Etag.GetHashCode();
                if (this.FirmwareChecksum != null)
                    hashCode = hashCode * 59 + this.FirmwareChecksum.GetHashCode();
                if (this.HostGateway != null)
                    hashCode = hashCode * 59 + this.HostGateway.GetHashCode();
                if (this.Id != null)
                    hashCode = hashCode * 59 + this.Id.GetHashCode();
                if (this.Manifest != null)
                    hashCode = hashCode * 59 + this.Manifest.GetHashCode();
                if (this.ManifestTimestamp != null)
                    hashCode = hashCode * 59 + this.ManifestTimestamp.GetHashCode();
                if (this.Mechanism != null)
                    hashCode = hashCode * 59 + this.Mechanism.GetHashCode();
                if (this.MechanismUrl != null)
                    hashCode = hashCode * 59 + this.MechanismUrl.GetHashCode();
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.SerialNumber != null)
                    hashCode = hashCode * 59 + this.SerialNumber.GetHashCode();
                if (this.State != null)
                    hashCode = hashCode * 59 + this.State.GetHashCode();
                if (this.UpdatedAt != null)
                    hashCode = hashCode * 59 + this.UpdatedAt.GetHashCode();
                if (this.VendorId != null)
                    hashCode = hashCode * 59 + this.VendorId.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}
