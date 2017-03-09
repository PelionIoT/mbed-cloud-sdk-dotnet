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
    /// This object represents a policy. Either the feature or the resource must be specified.
    /// </summary>
    [DataContract]
    public partial class Policy :  IEquatable<Policy>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Policy" /> class.
        /// </summary>
        /// <param name="Action">Comma separated list of actions, empty string represents all actions..</param>
        /// <param name="Resource">Resource that is protected by this policy..</param>
        /// <param name="Feature">Feature name corresponding to this policy..</param>
        /// <param name="Allow">True or false controlling whether an action is allowed or not..</param>
        public Policy(string Action = default(string), string Resource = default(string), string Feature = default(string), bool? Allow = default(bool?))
        {
            this.Action = Action;
            this.Resource = Resource;
            this.Feature = Feature;
            this.Allow = Allow;
        }
        
        /// <summary>
        /// Comma separated list of actions, empty string represents all actions.
        /// </summary>
        /// <value>Comma separated list of actions, empty string represents all actions.</value>
        [DataMember(Name="action", EmitDefaultValue=false)]
        public string Action { get; set; }
        /// <summary>
        /// Resource that is protected by this policy.
        /// </summary>
        /// <value>Resource that is protected by this policy.</value>
        [DataMember(Name="resource", EmitDefaultValue=false)]
        public string Resource { get; set; }
        /// <summary>
        /// Feature name corresponding to this policy.
        /// </summary>
        /// <value>Feature name corresponding to this policy.</value>
        [DataMember(Name="feature", EmitDefaultValue=false)]
        public string Feature { get; set; }
        /// <summary>
        /// True or false controlling whether an action is allowed or not.
        /// </summary>
        /// <value>True or false controlling whether an action is allowed or not.</value>
        [DataMember(Name="allow", EmitDefaultValue=false)]
        public bool? Allow { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Policy {\n");
            sb.Append("  Action: ").Append(Action).Append("\n");
            sb.Append("  Resource: ").Append(Resource).Append("\n");
            sb.Append("  Feature: ").Append(Feature).Append("\n");
            sb.Append("  Allow: ").Append(Allow).Append("\n");
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
            return this.Equals(obj as Policy);
        }

        /// <summary>
        /// Returns true if Policy instances are equal
        /// </summary>
        /// <param name="other">Instance of Policy to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Policy other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.Action == other.Action ||
                    this.Action != null &&
                    this.Action.Equals(other.Action)
                ) && 
                (
                    this.Resource == other.Resource ||
                    this.Resource != null &&
                    this.Resource.Equals(other.Resource)
                ) && 
                (
                    this.Feature == other.Feature ||
                    this.Feature != null &&
                    this.Feature.Equals(other.Feature)
                ) && 
                (
                    this.Allow == other.Allow ||
                    this.Allow != null &&
                    this.Allow.Equals(other.Allow)
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
                if (this.Action != null)
                    hash = hash * 59 + this.Action.GetHashCode();
                if (this.Resource != null)
                    hash = hash * 59 + this.Resource.GetHashCode();
                if (this.Feature != null)
                    hash = hash * 59 + this.Feature.GetHashCode();
                if (this.Allow != null)
                    hash = hash * 59 + this.Allow.GetHashCode();
                return hash;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        { 
            yield break;
        }
    }

}
