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
    /// This object represents a response to an update request.
    /// </summary>
    [DataContract]
    public partial class UpdatedResponse :  IEquatable<UpdatedResponse>
    { 
    
        /// <summary>
        /// entity name: 'user', 'apikey', 'group' or 'account'
        /// </summary>
        /// <value>entity name: 'user', 'apikey', 'group' or 'account'</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum _ObjectEnum {
            
            [EnumMember(Value = "user")]
            User,
            
            [EnumMember(Value = "apikey")]
            Apikey,
            
            [EnumMember(Value = "group")]
            Group,
            
            [EnumMember(Value = "account")]
            Account,
            
            [EnumMember(Value = "list")]
            List,
            
            [EnumMember(Value = "error")]
            Error
        }

    
        /// <summary>
        /// response type: success
        /// </summary>
        /// <value>response type: success</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TypeEnum {
            
            [EnumMember(Value = "success")]
            Success,
            
            [EnumMember(Value = "created")]
            Created,
            
            [EnumMember(Value = "accepted")]
            Accepted,
            
            [EnumMember(Value = "permanently_deleted")]
            PermanentlyDeleted,
            
            [EnumMember(Value = "validation_error")]
            ValidationError,
            
            [EnumMember(Value = "invalid_token")]
            InvalidToken,
            
            [EnumMember(Value = "access_denied")]
            AccessDenied,
            
            [EnumMember(Value = "account_limit_exceeded")]
            AccountLimitExceeded,
            
            [EnumMember(Value = "not_found")]
            NotFound,
            
            [EnumMember(Value = "method_not_supported")]
            MethodNotSupported,
            
            [EnumMember(Value = "duplicate")]
            Duplicate,
            
            [EnumMember(Value = "precondition_failed")]
            PreconditionFailed,
            
            [EnumMember(Value = "unsupported_media_type")]
            UnsupportedMediaType,
            
            [EnumMember(Value = "rate_limit_exceeded")]
            RateLimitExceeded,
            
            [EnumMember(Value = "internal_server_error")]
            InternalServerError,
            
            [EnumMember(Value = "system_unavailable")]
            SystemUnavailable
        }

    
        /// <summary>
        /// entity name: 'user', 'apikey', 'group' or 'account'
        /// </summary>
        /// <value>entity name: 'user', 'apikey', 'group' or 'account'</value>
        [DataMember(Name="object", EmitDefaultValue=false)]
        public _ObjectEnum? _Object { get; set; }
    
        /// <summary>
        /// response type: success
        /// </summary>
        /// <value>response type: success</value>
        [DataMember(Name="type", EmitDefaultValue=false)]
        public TypeEnum? Type { get; set; }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdatedResponse" /> class.
        /// Initializes a new instance of the <see cref="UpdatedResponse" />class.
        /// </summary>
        /// <param name="Code">response code (required).</param>
        /// <param name="_Object">entity name: &#39;user&#39;, &#39;apikey&#39;, &#39;group&#39; or &#39;account&#39; (required).</param>
        /// <param name="RequestId">request id (required).</param>
        /// <param name="Message">a human readable message with detailed info (required).</param>
        /// <param name="Type">response type: success (required).</param>
        /// <param name="Id">entity id (required).</param>

        public UpdatedResponse(int? Code = null, _ObjectEnum? _Object = null, string RequestId = null, string Message = null, TypeEnum? Type = null, string Id = null)
        {
            // to ensure "Code" is required (not null)
            if (Code == null)
            {
                throw new InvalidDataException("Code is a required property for UpdatedResponse and cannot be null");
            }
            else
            {
                this.Code = Code;
            }
            // to ensure "_Object" is required (not null)
            if (_Object == null)
            {
                throw new InvalidDataException("_Object is a required property for UpdatedResponse and cannot be null");
            }
            else
            {
                this._Object = _Object;
            }
            // to ensure "RequestId" is required (not null)
            if (RequestId == null)
            {
                throw new InvalidDataException("RequestId is a required property for UpdatedResponse and cannot be null");
            }
            else
            {
                this.RequestId = RequestId;
            }
            // to ensure "Message" is required (not null)
            if (Message == null)
            {
                throw new InvalidDataException("Message is a required property for UpdatedResponse and cannot be null");
            }
            else
            {
                this.Message = Message;
            }
            // to ensure "Type" is required (not null)
            if (Type == null)
            {
                throw new InvalidDataException("Type is a required property for UpdatedResponse and cannot be null");
            }
            else
            {
                this.Type = Type;
            }
            // to ensure "Id" is required (not null)
            if (Id == null)
            {
                throw new InvalidDataException("Id is a required property for UpdatedResponse and cannot be null");
            }
            else
            {
                this.Id = Id;
            }
            
        }
        
    
        /// <summary>
        /// response code
        /// </summary>
        /// <value>response code</value>
        [DataMember(Name="code", EmitDefaultValue=false)]
        public int? Code { get; set; }
    
        /// <summary>
        /// request id
        /// </summary>
        /// <value>request id</value>
        [DataMember(Name="request_id", EmitDefaultValue=false)]
        public string RequestId { get; set; }
    
        /// <summary>
        /// a human readable message with detailed info
        /// </summary>
        /// <value>a human readable message with detailed info</value>
        [DataMember(Name="message", EmitDefaultValue=false)]
        public string Message { get; set; }
    
        /// <summary>
        /// entity id
        /// </summary>
        /// <value>entity id</value>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public string Id { get; set; }
    
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class UpdatedResponse {\n");
            sb.Append("  Code: ").Append(Code).Append("\n");
            sb.Append("  _Object: ").Append(_Object).Append("\n");
            sb.Append("  RequestId: ").Append(RequestId).Append("\n");
            sb.Append("  Message: ").Append(Message).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            
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
            return this.Equals(obj as UpdatedResponse);
        }

        /// <summary>
        /// Returns true if UpdatedResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of UpdatedResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(UpdatedResponse other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.Code == other.Code ||
                    this.Code != null &&
                    this.Code.Equals(other.Code)
                ) && 
                (
                    this._Object == other._Object ||
                    this._Object != null &&
                    this._Object.Equals(other._Object)
                ) && 
                (
                    this.RequestId == other.RequestId ||
                    this.RequestId != null &&
                    this.RequestId.Equals(other.RequestId)
                ) && 
                (
                    this.Message == other.Message ||
                    this.Message != null &&
                    this.Message.Equals(other.Message)
                ) && 
                (
                    this.Type == other.Type ||
                    this.Type != null &&
                    this.Type.Equals(other.Type)
                ) && 
                (
                    this.Id == other.Id ||
                    this.Id != null &&
                    this.Id.Equals(other.Id)
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
                
                if (this.Code != null)
                    hash = hash * 59 + this.Code.GetHashCode();
                
                if (this._Object != null)
                    hash = hash * 59 + this._Object.GetHashCode();
                
                if (this.RequestId != null)
                    hash = hash * 59 + this.RequestId.GetHashCode();
                
                if (this.Message != null)
                    hash = hash * 59 + this.Message.GetHashCode();
                
                if (this.Type != null)
                    hash = hash * 59 + this.Type.GetHashCode();
                
                if (this.Id != null)
                    hash = hash * 59 + this.Id.GetHashCode();
                
                return hash;
            }
        }

    }
}
