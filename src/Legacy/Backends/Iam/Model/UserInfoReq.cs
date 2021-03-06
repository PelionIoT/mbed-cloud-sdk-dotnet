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
using SwaggerDateConverter = iam.Client.SwaggerDateConverter;

namespace iam.Model
{
    /// <summary>
    /// This object represents a user in requests towards Device Management.
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
        /// <param name="Address">Address, not longer than 100 characters..</param>
        /// <param name="Email">The email address, not longer than 254 characters. (required).</param>
        /// <param name="FullName">The full name of the user, not longer than 100 characters..</param>
        /// <param name="Groups">A list of IDs of the groups this user belongs to..</param>
        /// <param name="IsGtcAccepted">A flag indicating that the General Terms and Conditions has been accepted..</param>
        /// <param name="IsMarketingAccepted">A flag indicating that receiving marketing information has been accepted..</param>
        /// <param name="Password">The password when creating a new user. It will be generated when not present in the request..</param>
        /// <param name="PhoneNumber">Phone number, not longer than 100 characters..</param>
        /// <param name="Username">A username containing alphanumerical letters and -,._@+&#x3D; characters. It must be at least 4 but not more than 30 character long..</param>
        public UserInfoReq(string Address = default(string), string Email = default(string), string FullName = default(string), List<string> Groups = default(List<string>), bool? IsGtcAccepted = default(bool?), bool? IsMarketingAccepted = default(bool?), string Password = default(string), string PhoneNumber = default(string), string Username = default(string))
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
            this.Address = Address;
            this.FullName = FullName;
            this.Groups = Groups;
            this.IsGtcAccepted = IsGtcAccepted;
            this.IsMarketingAccepted = IsMarketingAccepted;
            this.Password = Password;
            this.PhoneNumber = PhoneNumber;
            this.Username = Username;
        }
        
        /// <summary>
        /// Address, not longer than 100 characters.
        /// </summary>
        /// <value>Address, not longer than 100 characters.</value>
        [DataMember(Name="address", EmitDefaultValue=false)]
        public string Address { get; set; }

        /// <summary>
        /// The email address, not longer than 254 characters.
        /// </summary>
        /// <value>The email address, not longer than 254 characters.</value>
        [DataMember(Name="email", EmitDefaultValue=false)]
        public string Email { get; set; }

        /// <summary>
        /// The full name of the user, not longer than 100 characters.
        /// </summary>
        /// <value>The full name of the user, not longer than 100 characters.</value>
        [DataMember(Name="full_name", EmitDefaultValue=false)]
        public string FullName { get; set; }

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
        /// A flag indicating that receiving marketing information has been accepted.
        /// </summary>
        /// <value>A flag indicating that receiving marketing information has been accepted.</value>
        [DataMember(Name="is_marketing_accepted", EmitDefaultValue=false)]
        public bool? IsMarketingAccepted { get; set; }

        /// <summary>
        /// The password when creating a new user. It will be generated when not present in the request.
        /// </summary>
        /// <value>The password when creating a new user. It will be generated when not present in the request.</value>
        [DataMember(Name="password", EmitDefaultValue=false)]
        public string Password { get; set; }

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
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class UserInfoReq {\n");
            sb.Append("  Address: ").Append(Address).Append("\n");
            sb.Append("  Email: ").Append(Email).Append("\n");
            sb.Append("  FullName: ").Append(FullName).Append("\n");
            sb.Append("  Groups: ").Append(Groups).Append("\n");
            sb.Append("  IsGtcAccepted: ").Append(IsGtcAccepted).Append("\n");
            sb.Append("  IsMarketingAccepted: ").Append(IsMarketingAccepted).Append("\n");
            sb.Append("  Password: ").Append(Password).Append("\n");
            sb.Append("  PhoneNumber: ").Append(PhoneNumber).Append("\n");
            sb.Append("  Username: ").Append(Username).Append("\n");
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
            return this.Equals(input as UserInfoReq);
        }

        /// <summary>
        /// Returns true if UserInfoReq instances are equal
        /// </summary>
        /// <param name="input">Instance of UserInfoReq to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(UserInfoReq input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Address == input.Address ||
                    (this.Address != null &&
                    this.Address.Equals(input.Address))
                ) && 
                (
                    this.Email == input.Email ||
                    (this.Email != null &&
                    this.Email.Equals(input.Email))
                ) && 
                (
                    this.FullName == input.FullName ||
                    (this.FullName != null &&
                    this.FullName.Equals(input.FullName))
                ) && 
                (
                    this.Groups == input.Groups ||
                    this.Groups != null &&
                    this.Groups.SequenceEqual(input.Groups)
                ) && 
                (
                    this.IsGtcAccepted == input.IsGtcAccepted ||
                    (this.IsGtcAccepted != null &&
                    this.IsGtcAccepted.Equals(input.IsGtcAccepted))
                ) && 
                (
                    this.IsMarketingAccepted == input.IsMarketingAccepted ||
                    (this.IsMarketingAccepted != null &&
                    this.IsMarketingAccepted.Equals(input.IsMarketingAccepted))
                ) && 
                (
                    this.Password == input.Password ||
                    (this.Password != null &&
                    this.Password.Equals(input.Password))
                ) && 
                (
                    this.PhoneNumber == input.PhoneNumber ||
                    (this.PhoneNumber != null &&
                    this.PhoneNumber.Equals(input.PhoneNumber))
                ) && 
                (
                    this.Username == input.Username ||
                    (this.Username != null &&
                    this.Username.Equals(input.Username))
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
                if (this.Address != null)
                    hashCode = hashCode * 59 + this.Address.GetHashCode();
                if (this.Email != null)
                    hashCode = hashCode * 59 + this.Email.GetHashCode();
                if (this.FullName != null)
                    hashCode = hashCode * 59 + this.FullName.GetHashCode();
                if (this.Groups != null)
                    hashCode = hashCode * 59 + this.Groups.GetHashCode();
                if (this.IsGtcAccepted != null)
                    hashCode = hashCode * 59 + this.IsGtcAccepted.GetHashCode();
                if (this.IsMarketingAccepted != null)
                    hashCode = hashCode * 59 + this.IsMarketingAccepted.GetHashCode();
                if (this.Password != null)
                    hashCode = hashCode * 59 + this.Password.GetHashCode();
                if (this.PhoneNumber != null)
                    hashCode = hashCode * 59 + this.PhoneNumber.GetHashCode();
                if (this.Username != null)
                    hashCode = hashCode * 59 + this.Username.GetHashCode();
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
