/* 
 * <auto-generated>
 * Account Management API
 *
 * API for managing accounts, users, creating API keys, uploading trusted certificates
 *
 * OpenAPI spec version: v3
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

namespace iam.Model
{
    /// <summary>
    /// This object represents a user in requests towards mbed Cloud.
    /// </summary>
    [DataContract]
    public partial class UserInfoReq :  IEquatable<UserInfoReq>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserInfoReq" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected UserInfoReq() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="UserInfoReq" /> class.
        /// </summary>
        /// <param name="PhoneNumber">Phone number, not longer than 100 characters..</param>
        /// <param name="Username">A username containing alphanumerical letters and -,._@+&#x3D; characters. It must be at least 4 but not more than 30 character long..</param>
        /// <param name="Groups">A list of IDs of the groups this user belongs to..</param>
        /// <param name="IsGtcAccepted">A flag indicating that the General Terms and Conditions has been accepted..</param>
        /// <param name="FullName">The full name of the user, not longer than 100 characters..</param>
        /// <param name="IsMarketingAccepted">A flag indicating that receiving marketing information has been accepted..</param>
        /// <param name="Address">Address, not longer than 100 characters..</param>
        /// <param name="Password">The password when creating a new user. It will be generated when not present in the request..</param>
        /// <param name="Email">The email address, not longer than 254 characters. (required).</param>
        public UserInfoReq(string PhoneNumber = default(string), string Username = default(string), List<string> Groups = default(List<string>), bool? IsGtcAccepted = default(bool?), string FullName = default(string), bool? IsMarketingAccepted = default(bool?), string Address = default(string), string Password = default(string), string Email = default(string))
        {
            // to ensure "Email" is required (not null)
            if (Email == null)
            {
                throw new InvalidDataException("Email is a required property for UserInfoReq and cannot be null");
            }
            else
            {
                this.Email = Email;
            }
            this.PhoneNumber = PhoneNumber;
            this.Username = Username;
            this.Groups = Groups;
            this.IsGtcAccepted = IsGtcAccepted;
            this.FullName = FullName;
            this.IsMarketingAccepted = IsMarketingAccepted;
            this.Address = Address;
            this.Password = Password;
        }
        
        /// <summary>
        /// Phone number, not longer than 100 characters.
        /// </summary>
        /// <value>Phone number, not longer than 100 characters.</value>
        [DataMember(Name="phone_number", EmitDefaultValue=false)]
        public string PhoneNumber { get; set; }
        /// <summary>
        /// A username containing alphanumerical letters and -,._@+&#x3D; characters. It must be at least 4 but not more than 30 character long.
        /// </summary>
        /// <value>A username containing alphanumerical letters and -,._@+&#x3D; characters. It must be at least 4 but not more than 30 character long.</value>
        [DataMember(Name="username", EmitDefaultValue=false)]
        public string Username { get; set; }
        /// <summary>
        /// A list of IDs of the groups this user belongs to.
        /// </summary>
        /// <value>A list of IDs of the groups this user belongs to.</value>
        [DataMember(Name="groups", EmitDefaultValue=false)]
        public List<string> Groups { get; set; }
        /// <summary>
        /// A flag indicating that the General Terms and Conditions has been accepted.
        /// </summary>
        /// <value>A flag indicating that the General Terms and Conditions has been accepted.</value>
        [DataMember(Name="is_gtc_accepted", EmitDefaultValue=false)]
        public bool? IsGtcAccepted { get; set; }
        /// <summary>
        /// The full name of the user, not longer than 100 characters.
        /// </summary>
        /// <value>The full name of the user, not longer than 100 characters.</value>
        [DataMember(Name="full_name", EmitDefaultValue=false)]
        public string FullName { get; set; }
        /// <summary>
        /// A flag indicating that receiving marketing information has been accepted.
        /// </summary>
        /// <value>A flag indicating that receiving marketing information has been accepted.</value>
        [DataMember(Name="is_marketing_accepted", EmitDefaultValue=false)]
        public bool? IsMarketingAccepted { get; set; }
        /// <summary>
        /// Address, not longer than 100 characters.
        /// </summary>
        /// <value>Address, not longer than 100 characters.</value>
        [DataMember(Name="address", EmitDefaultValue=false)]
        public string Address { get; set; }
        /// <summary>
        /// The password when creating a new user. It will be generated when not present in the request.
        /// </summary>
        /// <value>The password when creating a new user. It will be generated when not present in the request.</value>
        [DataMember(Name="password", EmitDefaultValue=false)]
        public string Password { get; set; }
        /// <summary>
        /// The email address, not longer than 254 characters.
        /// </summary>
        /// <value>The email address, not longer than 254 characters.</value>
        [DataMember(Name="email", EmitDefaultValue=false)]
        public string Email { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class UserInfoReq {\n");
            sb.Append("  PhoneNumber: ").Append(PhoneNumber).Append("\n");
            sb.Append("  Username: ").Append(Username).Append("\n");
            sb.Append("  Groups: ").Append(Groups).Append("\n");
            sb.Append("  IsGtcAccepted: ").Append(IsGtcAccepted).Append("\n");
            sb.Append("  FullName: ").Append(FullName).Append("\n");
            sb.Append("  IsMarketingAccepted: ").Append(IsMarketingAccepted).Append("\n");
            sb.Append("  Address: ").Append(Address).Append("\n");
            sb.Append("  Password: ").Append(Password).Append("\n");
            sb.Append("  Email: ").Append(Email).Append("\n");
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
            return this.Equals(obj as UserInfoReq);
        }

        /// <summary>
        /// Returns true if UserInfoReq instances are equal
        /// </summary>
        /// <param name="other">Instance of UserInfoReq to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(UserInfoReq other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.PhoneNumber == other.PhoneNumber ||
                    this.PhoneNumber != null &&
                    this.PhoneNumber.Equals(other.PhoneNumber)
                ) && 
                (
                    this.Username == other.Username ||
                    this.Username != null &&
                    this.Username.Equals(other.Username)
                ) && 
                (
                    this.Groups == other.Groups ||
                    this.Groups != null &&
                    this.Groups.SequenceEqual(other.Groups)
                ) && 
                (
                    this.IsGtcAccepted == other.IsGtcAccepted ||
                    this.IsGtcAccepted != null &&
                    this.IsGtcAccepted.Equals(other.IsGtcAccepted)
                ) && 
                (
                    this.FullName == other.FullName ||
                    this.FullName != null &&
                    this.FullName.Equals(other.FullName)
                ) && 
                (
                    this.IsMarketingAccepted == other.IsMarketingAccepted ||
                    this.IsMarketingAccepted != null &&
                    this.IsMarketingAccepted.Equals(other.IsMarketingAccepted)
                ) && 
                (
                    this.Address == other.Address ||
                    this.Address != null &&
                    this.Address.Equals(other.Address)
                ) && 
                (
                    this.Password == other.Password ||
                    this.Password != null &&
                    this.Password.Equals(other.Password)
                ) && 
                (
                    this.Email == other.Email ||
                    this.Email != null &&
                    this.Email.Equals(other.Email)
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
                if (this.PhoneNumber != null)
                    hash = hash * 59 + this.PhoneNumber.GetHashCode();
                if (this.Username != null)
                    hash = hash * 59 + this.Username.GetHashCode();
                if (this.Groups != null)
                    hash = hash * 59 + this.Groups.GetHashCode();
                if (this.IsGtcAccepted != null)
                    hash = hash * 59 + this.IsGtcAccepted.GetHashCode();
                if (this.FullName != null)
                    hash = hash * 59 + this.FullName.GetHashCode();
                if (this.IsMarketingAccepted != null)
                    hash = hash * 59 + this.IsMarketingAccepted.GetHashCode();
                if (this.Address != null)
                    hash = hash * 59 + this.Address.GetHashCode();
                if (this.Password != null)
                    hash = hash * 59 + this.Password.GetHashCode();
                if (this.Email != null)
                    hash = hash * 59 + this.Email.GetHashCode();
                return hash;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        { 
            yield break;
        }
    }

}
