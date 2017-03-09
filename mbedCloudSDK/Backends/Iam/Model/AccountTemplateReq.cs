/* 
 * IAM Identities REST API
 *
 * REST API to manage accounts, groups, users and API keys
 *
 * OpenAPI spec version: v3
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

namespace iam.Model
{
    /// <summary>
    /// This object represents an account template creation request.
    /// </summary>
    [DataContract]
    public partial class AccountTemplateReq :  IEquatable<AccountTemplateReq>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountTemplateReq" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected AccountTemplateReq() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountTemplateReq" /> class.
        /// </summary>
        /// <param name="Parent">ID of the parent template, can be null..</param>
        /// <param name="Name">Account template name. (required).</param>
        /// <param name="Limits">List of limits as name-value pairs..</param>
        /// <param name="TemplateType">Account template type..</param>
        /// <param name="Reason">Account template update reason..</param>
        /// <param name="Resources">List of resource-action-allow triplets, policies..</param>
        /// <param name="Description">Account template description..</param>
        public AccountTemplateReq(string Parent = default(string), string Name = default(string), Dictionary<string, string> Limits = default(Dictionary<string, string>), string TemplateType = default(string), string Reason = default(string), List<Policy> Resources = default(List<Policy>), string Description = default(string))
        {
            // to ensure "Name" is required (not null)
            if (Name == null)
            {
                throw new InvalidDataException("Name is a required property for AccountTemplateReq and cannot be null");
            }
            else
            {
                this.Name = Name;
            }
            this.Parent = Parent;
            this.Limits = Limits;
            this.TemplateType = TemplateType;
            this.Reason = Reason;
            this.Resources = Resources;
            this.Description = Description;
        }
        
        /// <summary>
        /// ID of the parent template, can be null.
        /// </summary>
        /// <value>ID of the parent template, can be null.</value>
        [DataMember(Name="parent", EmitDefaultValue=false)]
        public string Parent { get; set; }
        /// <summary>
        /// Account template name.
        /// </summary>
        /// <value>Account template name.</value>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }
        /// <summary>
        /// List of limits as name-value pairs.
        /// </summary>
        /// <value>List of limits as name-value pairs.</value>
        [DataMember(Name="limits", EmitDefaultValue=false)]
        public Dictionary<string, string> Limits { get; set; }
        /// <summary>
        /// Account template type.
        /// </summary>
        /// <value>Account template type.</value>
        [DataMember(Name="template_type", EmitDefaultValue=false)]
        public string TemplateType { get; set; }
        /// <summary>
        /// Account template update reason.
        /// </summary>
        /// <value>Account template update reason.</value>
        [DataMember(Name="reason", EmitDefaultValue=false)]
        public string Reason { get; set; }
        /// <summary>
        /// List of resource-action-allow triplets, policies.
        /// </summary>
        /// <value>List of resource-action-allow triplets, policies.</value>
        [DataMember(Name="resources", EmitDefaultValue=false)]
        public List<Policy> Resources { get; set; }
        /// <summary>
        /// Account template description.
        /// </summary>
        /// <value>Account template description.</value>
        [DataMember(Name="description", EmitDefaultValue=false)]
        public string Description { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class AccountTemplateReq {\n");
            sb.Append("  Parent: ").Append(Parent).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Limits: ").Append(Limits).Append("\n");
            sb.Append("  TemplateType: ").Append(TemplateType).Append("\n");
            sb.Append("  Reason: ").Append(Reason).Append("\n");
            sb.Append("  Resources: ").Append(Resources).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
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
            return this.Equals(obj as AccountTemplateReq);
        }

        /// <summary>
        /// Returns true if AccountTemplateReq instances are equal
        /// </summary>
        /// <param name="other">Instance of AccountTemplateReq to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AccountTemplateReq other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.Parent == other.Parent ||
                    this.Parent != null &&
                    this.Parent.Equals(other.Parent)
                ) && 
                (
                    this.Name == other.Name ||
                    this.Name != null &&
                    this.Name.Equals(other.Name)
                ) && 
                (
                    this.Limits == other.Limits ||
                    this.Limits != null &&
                    this.Limits.SequenceEqual(other.Limits)
                ) && 
                (
                    this.TemplateType == other.TemplateType ||
                    this.TemplateType != null &&
                    this.TemplateType.Equals(other.TemplateType)
                ) && 
                (
                    this.Reason == other.Reason ||
                    this.Reason != null &&
                    this.Reason.Equals(other.Reason)
                ) && 
                (
                    this.Resources == other.Resources ||
                    this.Resources != null &&
                    this.Resources.SequenceEqual(other.Resources)
                ) && 
                (
                    this.Description == other.Description ||
                    this.Description != null &&
                    this.Description.Equals(other.Description)
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
                if (this.Parent != null)
                    hash = hash * 59 + this.Parent.GetHashCode();
                if (this.Name != null)
                    hash = hash * 59 + this.Name.GetHashCode();
                if (this.Limits != null)
                    hash = hash * 59 + this.Limits.GetHashCode();
                if (this.TemplateType != null)
                    hash = hash * 59 + this.TemplateType.GetHashCode();
                if (this.Reason != null)
                    hash = hash * 59 + this.Reason.GetHashCode();
                if (this.Resources != null)
                    hash = hash * 59 + this.Resources.GetHashCode();
                if (this.Description != null)
                    hash = hash * 59 + this.Description.GetHashCode();
                return hash;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        { 
            yield break;
        }
    }

}
