using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbedCloudSDK.Development.Model
{
    /// <summary>
    /// Represents Developer Certificate from Development API.
    /// </summary>
    public class DeveloperCertificate
    {
        /// <summary>
        /// UTC time of the entity creation.
        /// </summary>
        /// <value>UTC time of the entity creation.</value>
        public string CreatedAt { get; set; }
        
        /// <summary>
        /// The developer certificate public key in raw format (65 bytes), Base64 encoded, NIST P-256 curve.
        /// </summary>
        /// <value>The developer certificate public key in raw format (65 bytes), Base64 encoded, NIST P-256 curve.</value>
        public string PubKey { get; set; }

        /// <summary>
        /// Entity ID.
        /// </summary>
        /// <value>Entity ID.</value>
        public string Id { get; set; }

        /// <summary>
        /// Create new instance of DeveloperCertificate
        /// </summary>
        /// <param name="options"></param>
        public DeveloperCertificate(IDictionary<string, object> options = null)
        {
            if (options != null)
            {
                foreach (KeyValuePair<string, object> item in options)
                {
                    var property = this.GetType().GetProperty(item.Key);
                    if (property != null)
                    {
                        property.SetValue(this, item.Value, null);
                    }
                }
            }
        }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class DeveloperCertificate {\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
            sb.Append("  PubKey: ").Append(PubKey).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Map to Developer certificate object.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static DeveloperCertificate Map(developer_certificate.Model.DeveloperCertificate data)
        {
            DeveloperCertificate certificate = new DeveloperCertificate();
            certificate.CreatedAt = data.CreatedAt;
            certificate.Id = data.Id;
            certificate.PubKey = data.PubKey;
            return certificate;
        }
    }
}
