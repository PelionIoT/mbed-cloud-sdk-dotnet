using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace iam.Model
{
    /// <summary>
    /// This object represents a user in requests towards mbed Cloud.
    /// </summary>
    [DataContract]
    public partial class UserInfoReq :  IEquatable<UserInfoReq>
    { 
    
        /// <summary>
        /// Initializes a new instance of the <see cref="UserInfoReq" /> class.
        /// Initializes a new instance of the <see cref="UserInfoReq" />class.
        /// </summary>
        /// <param name="Username">A username containing alphanumerical letters and -,._@+= characters. (required).</param>
        /// <param name="PhoneNumber">Phone number..</param>
        /// <param name="Groups">A list of IDs of the groups this user belongs to..</param>
        /// <param name="IsGtcAccepted">A flag indicating that the General Terms and Conditions has been accepted. (default to false).</param>
        /// <param name="IsMarketingAccepted">A flag indicating that receiving marketing information has been accepted. (default to false).</param>
        /// <param name="FullName">The full name of the user..</param>
        /// <param name="Address">Address..</param>
        /// <param name="Password">The password when creating a new user. It will will generated when not present in the request..</param>
        /// <param name="Email">Email address. (required).</param>

        public UserInfoReq(string Username = null, string PhoneNumber = null, List<string> Groups = null, bool? IsGtcAccepted = null, bool? IsMarketingAccepted = null, string FullName = null, string Address = null, string Password = null, string Email = null)
        {
            // to ensure "Username" is required (not null)
            if (Username == null)
            {
                throw new InvalidDataException("Username is a required property for UserInfoReq and cannot be null");
            }
            else
            {
                this.Username = Username;
            }
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
            this.Groups = Groups;
            // use default value if no "IsGtcAccepted" provided
            if (IsGtcAccepted == null)
            {
                this.IsGtcAccepted = false;
            }
            else
            {
                this.IsGtcAccepted = IsGtcAccepted;
            }
            // use default value if no "IsMarketingAccepted" provided
            if (IsMarketingAccepted == null)
            {
                this.IsMarketingAccepted = false;
            }
            else
            {
                this.IsMarketingAccepted = IsMarketingAccepted;
            }
            this.FullName = FullName;
            this.Address = Address;
            this.Password = Password;
            
        }
        
    
        /// <summary>
        /// A username containing alphanumerical letters and -,._@+= characters.
        /// </summary>
        /// <value>A username containing alphanumerical letters and -,._@+= characters.</value>
        [DataMember(Name="username", EmitDefaultValue=false)]
        public string Username { get; set; }
    
        /// <summary>
        /// Phone number.
        /// </summary>
        /// <value>Phone number.</value>
        [DataMember(Name="phone_number", EmitDefaultValue=false)]
        public string PhoneNumber { get; set; }
    
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
        /// The full name of the user.
        /// </summary>
        /// <value>The full name of the user.</value>
        [DataMember(Name="full_name", EmitDefaultValue=false)]
        public string FullName { get; set; }
    
        /// <summary>
        /// Address.
        /// </summary>
        /// <value>Address.</value>
        [DataMember(Name="address", EmitDefaultValue=false)]
        public string Address { get; set; }
    
        /// <summary>
        /// The password when creating a new user. It will will generated when not present in the request.
        /// </summary>
        /// <value>The password when creating a new user. It will will generated when not present in the request.</value>
        [DataMember(Name="password", EmitDefaultValue=false)]
        public string Password { get; set; }
    
        /// <summary>
        /// Email address.
        /// </summary>
        /// <value>Email address.</value>
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
            sb.Append("  Username: ").Append(Username).Append("\n");
            sb.Append("  PhoneNumber: ").Append(PhoneNumber).Append("\n");
            sb.Append("  Groups: ").Append(Groups).Append("\n");
            sb.Append("  IsGtcAccepted: ").Append(IsGtcAccepted).Append("\n");
            sb.Append("  IsMarketingAccepted: ").Append(IsMarketingAccepted).Append("\n");
            sb.Append("  FullName: ").Append(FullName).Append("\n");
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
                    this.Username == other.Username ||
                    this.Username != null &&
                    this.Username.Equals(other.Username)
                ) && 
                (
                    this.PhoneNumber == other.PhoneNumber ||
                    this.PhoneNumber != null &&
                    this.PhoneNumber.Equals(other.PhoneNumber)
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
                    this.IsMarketingAccepted == other.IsMarketingAccepted ||
                    this.IsMarketingAccepted != null &&
                    this.IsMarketingAccepted.Equals(other.IsMarketingAccepted)
                ) && 
                (
                    this.FullName == other.FullName ||
                    this.FullName != null &&
                    this.FullName.Equals(other.FullName)
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
                
                if (this.Username != null)
                    hash = hash * 59 + this.Username.GetHashCode();
                
                if (this.PhoneNumber != null)
                    hash = hash * 59 + this.PhoneNumber.GetHashCode();
                
                if (this.Groups != null)
                    hash = hash * 59 + this.Groups.GetHashCode();
                
                if (this.IsGtcAccepted != null)
                    hash = hash * 59 + this.IsGtcAccepted.GetHashCode();
                
                if (this.IsMarketingAccepted != null)
                    hash = hash * 59 + this.IsMarketingAccepted.GetHashCode();
                
                if (this.FullName != null)
                    hash = hash * 59 + this.FullName.GetHashCode();
                
                if (this.Address != null)
                    hash = hash * 59 + this.Address.GetHashCode();
                
                if (this.Password != null)
                    hash = hash * 59 + this.Password.GetHashCode();
                
                if (this.Email != null)
                    hash = hash * 59 + this.Email.GetHashCode();
                
                return hash;
            }
        }

    }
}
