using System;
using System.Security.Cryptography;
using System.Text;

namespace mbedCloudSDK.Common
{
    public static class ExtensionMethods
    {
        public static string Base64SHA256(this string value){
            var hasher = SHA256.Create();
            var hashValue = hasher.ComputeHash(Encoding.UTF8.GetBytes(value));
            return System.Convert.ToBase64String(hashValue);
        }
    }
}