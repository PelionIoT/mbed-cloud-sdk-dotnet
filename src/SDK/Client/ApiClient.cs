// <copyright file="ApiClient.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace Mbed.Cloud.RestClient
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using Newtonsoft.Json;
    using RestSharp;

    /// <summary>
    /// API client is mainly responsible for making the HTTP call to the API backend.
    /// </summary>
    public class ApiClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiClient" /> class
        /// with default configuration.
        /// </summary>
        /// <param name="basePath">The base path.</param>
        public ApiClient(string basePath = "https://api.us-east-1.mbedcloud.com")
        {
            if (string.IsNullOrEmpty(basePath))
            {
                throw new ArgumentException("basePath cannot be empty");
            }

            RestClient = new RestClient(basePath ?? "https://api.us-east-1.mbedcloud.com");
            LastApiResponse = new List<IRestResponse>();
        }

        /// <summary>
        /// Gets or sets the LastApiResponse list.
        /// </summary>
        /// <value>An instance of the LastApiResponseList</value>
        public List<IRestResponse> LastApiResponse { get; set; }

        /// <summary>
        /// Gets or sets the RestClient.
        /// </summary>
        /// <value>An instance of the RestClient</value>
        public RestClient RestClient { get; set; }

        /// <summary>
        /// Encode string in base64 format.
        /// </summary>
        /// <param name="text">String to be encoded.</param>
        /// <returns>Encoded string.</returns>
        public static string Base64Encode(string text)
        {
            return System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(text));
        }

        /// <summary>
        /// Dynamically cast the object into target type.
        /// Ref: http://stackoverflow.com/questions/4925718/c-dynamic-runtime-cast
        /// </summary>
        /// <param name="source">object to be casted</param>
        /// <param name="dest">Target type</param>
        /// <returns>Casted object</returns>
        public static dynamic ConvertType(dynamic source, Type dest)
        {
            return Convert.ChangeType(source, dest);
        }

        /// <summary>
        /// Escape string (url-encoded).
        /// </summary>
        /// <param name="str">string to be escaped.</param>
        /// <returns>Escaped string.</returns>
        public static string EscapeString(string str)
        {
            return UrlEncode(str);
        }

        /// <summary>
        /// Create FileParameter based on Stream.
        /// </summary>
        /// <param name="name">Parameter name.</param>
        /// <param name="stream">Input stream.</param>
        /// <returns>FileParameter.</returns>
        public static FileParameter ParameterToFile(string name, Stream stream)
        {
            var contentType = "multipart/form-data";
            if (stream is FileStream fileStream)
            {
                var extension = Path.GetExtension(fileStream.Name);
                if (extension == ".png")
                {
                    contentType = "image/png";
                }

                if (extension == ".svg")
                {
                    contentType = "image/svg+xml";
                }

                if (extension == "jpeg" || extension == "jpg")
                {
                    contentType = "image/jpeg";
                }

                return FileParameter.Create(name, ReadAsBytes(stream), fileStream.Name, contentType);
            }

            return FileParameter.Create(name, ReadAsBytes(stream), "no_file_name_provided", contentType);
        }

        /// <summary>
        /// Convert stream to byte array
        /// Credit/Ref: http://stackoverflow.com/a/221941/677735
        /// </summary>
        /// <param name="input">Input stream to be converted</param>
        /// <returns>Byte array</returns>
        public static byte[] ReadAsBytes(Stream input)
        {
            var buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }

                return ms.ToArray();
            }
        }

        /// <summary>
        /// Sanitize filename by removing the path
        /// </summary>
        /// <param name="filename">Filename</param>
        /// <returns>Filename</returns>
        public static string SanitizeFilename(string filename)
        {
            var match = Regex.Match(filename, @".*[/\\](.*)$");

            return match.Success ? match.Groups[1].Value : filename;
        }

        /// <summary>
        /// Select the Accept header's value from the given accepts array:
        /// if JSON exists in the given array, use it;
        /// otherwise use all of them (joining into a string)
        /// </summary>
        /// <param name="accepts">The accepts array to select from.</param>
        /// <returns>The Accept header to use.</returns>
        public static string SelectHeaderAccept(string[] accepts)
        {
            if (accepts.Length == 0)
            {
                return "*/*";
            }

            if (accepts.Contains("application/json", StringComparer.OrdinalIgnoreCase))
            {
                return "application/json";
            }

            return string.Join(",", accepts);
        }

        /// <summary>
        /// Select the Content-Type header's value from the given content-type array:
        /// if JSON exists in the given array, use it;
        /// otherwise use the first one defined in 'consumes'
        /// </summary>
        /// <param name="contentTypes">The Content-Type array to select from.</param>
        /// <returns>The Content-Type header to use.</returns>
        public static string SelectHeaderContentType(string[] contentTypes)
        {
            if (contentTypes.Length == 0)
            {
                return null;
            }

            if (contentTypes.Contains("application/json", StringComparer.OrdinalIgnoreCase))
            {
                return "application/json";
            }

            return contentTypes[0]; // use the first content type specified in 'consumes'
        }

        /// <summary>
        /// URL encode a string
        /// Credit/Ref: https://github.com/restsharp/RestSharp/blob/master/RestSharp/Extensions/StringExtensions.cs#L50
        /// </summary>
        /// <param name="input">String to be URL encoded</param>
        /// <returns>Byte array</returns>
        public static string UrlEncode(string input)
        {
            const int maxLength = 32766;

            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            if (input.Length <= maxLength)
            {
                return Uri.EscapeDataString(input);
            }

            var sb = new StringBuilder(input.Length * 2);
            var index = 0;

            while (index < input.Length)
            {
                var length = Math.Min(input.Length - index, maxLength);
                var subString = input.Substring(index, length);

                sb.Append(Uri.EscapeDataString(subString));
                index += subString.Length;
            }

            return sb.ToString();
        }

        /// <summary>
        /// Makes the asynchronous HTTP request.
        /// </summary>
        /// <param name="path">URL path.</param>
        /// <param name="method">HTTP method.</param>
        /// <param name="queryParams">Query parameters.</param>
        /// <param name="postBody">HTTP body (POST request).</param>
        /// <param name="headerParams">Header parameters.</param>
        /// <param name="formParams">Form parameters.</param>
        /// <param name="fileParams">File parameters.</param>
        /// <param name="pathParams">Path parameters.</param>
        /// <param name="contentType">Content type.</param>
        /// <returns>The Task instance.</returns>
        public async System.Threading.Tasks.Task<object> CallApiAsync(
            string path,
            RestSharp.Method method,
            List<KeyValuePair<string, string>> queryParams,
            object postBody,
            Dictionary<string, string> headerParams,
            Dictionary<string, string> formParams,
            Dictionary<string, FileParameter> fileParams,
            Dictionary<string, string> pathParams,
            string contentType)
        {
            var request = PrepareRequest(
                path,
                method,
                queryParams,
                postBody,
                headerParams,
                formParams,
                fileParams,
                pathParams,
                contentType);
            var response = await RestClient.ExecuteTaskAsync(request);
            InterceptResponse(response);
            return response;
        }

        /// <summary>
        /// Intercept the request and response objects during Api call
        /// </summary>
        /// <param name="response">The RestSharp response object</param>
        public void InterceptResponse(IRestResponse response)
        {
            LastApiResponse.Add(response);
        }

        // Creates and sets up a RestRequest prior to a call.
        private static RestRequest PrepareRequest(
            string path,
            RestSharp.Method method,
            List<KeyValuePair<string, string>> queryParams,
            object postBody,
            Dictionary<string, string> headerParams,
            Dictionary<string, string> formParams,
            Dictionary<string, FileParameter> fileParams,
            Dictionary<string, string> pathParams,
            string contentType)
        {
            // add path parameter, if any
            foreach (var param in pathParams)
            {
                path = path.Replace("{" + param.Key + "}", param.Value);
            }

            var request = new RestRequest(path, method);

            // add header parameter, if any
            foreach (var param in headerParams)
            {
                request.AddHeader(param.Key, param.Value);
            }

            // add query parameter, if any
            foreach (var param in queryParams)
            {
                request.AddQueryParameter(param.Key, param.Value);
            }

            // add form parameter, if any
            foreach (var param in formParams)
            {
                request.AddParameter(param.Key, param.Value);
            }

            // add file parameter, if any
            foreach (var param in fileParams)
            {
                request.Files.Add(new FileParameter
                {
                    Name = param.Value.Name,
                    Writer = param.Value.Writer,
                    FileName = param.Value.FileName,
                    ContentType = param.Value.ContentType,
                    ContentLength = param.Value.ContentLength
                });
            }

            if (postBody != null)
            {
                if (postBody.GetType() == typeof(string))
                {
                    request.AddParameter("application/json", postBody, ParameterType.RequestBody);
                }
                else if (postBody.GetType() == typeof(byte[]))
                {
                    request.AddParameter(contentType, postBody, ParameterType.RequestBody);
                }
            }

            return request;
        }
    }
}