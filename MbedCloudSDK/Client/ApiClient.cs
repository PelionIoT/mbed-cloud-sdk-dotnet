// <copyright file="ApiClient.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Client
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
        private readonly JsonSerializerSettings serializerSettings = new JsonSerializerSettings
        {
            ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor
        };

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
        /// Gets or sets the Configuration.
        /// </summary>
        /// <value>An instance of the Configuration.</value>
        public Configuration Configuration { get; set; }

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
            return stream is FileStream ? FileParameter.Create(name, ReadAsBytes(stream), Path.GetFileName(((FileStream)stream).Name), "multipart/form-data") : FileParameter.Create(name, ReadAsBytes(stream), "no_file_name_provided", "multipart/form-data");
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
        /// Serialize an input (model) into JSON string
        /// </summary>
        /// <param name="obj">object.</param>
        /// <returns>JSON string.</returns>
        public static string Serialize(string obj)
        {
            try
            {
                return obj;
            }
            catch (Exception e)
            {
                throw new ApiException(500, e.Message);
            }
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
        /// Deserialize the JSON string into a proper object.
        /// </summary>
        /// <param name="response">The HTTP response.</param>
        /// <param name="type">object type.</param>
        /// <returns>object representation of the JSON string.</returns>
        public object Deserialize(IRestResponse response, Type type)
        {
            var headers = response.Headers;
            if (type == typeof(byte[]))
            {
                return response.RawBytes;
            }

            if (type == typeof(Stream))
            {
                if (headers != null)
                {
                    var filePath = Path.GetTempPath();
                    var regex = new Regex(@"Content-Disposition=.*filename=['""]?([^'""\s]+)['""]?$");
                    foreach (var header in headers)
                    {
                        var match = regex.Match(header.ToString());
                        if (match.Success)
                        {
                            var fileName = filePath + SanitizeFilename(match.Groups[1].Value.Replace("\"", string.Empty).Replace("'", string.Empty));
                            File.WriteAllBytes(fileName, response.RawBytes);
                            return new FileStream(fileName, FileMode.Open);
                        }
                    }
                }

                var stream = new MemoryStream(response.RawBytes);
                return stream;
            }

            if (type.Name.StartsWith("System.Nullable`1[[System.DateTime"))
            {
                return DateTime.Parse(response.Content, null, System.Globalization.DateTimeStyles.RoundtripKind);
            }

            if (type == typeof(string) || type.Name.StartsWith("System.Nullable"))
            {
                return ConvertType(response.Content, type);
            }

            // at this point, it must be a model (json)
            try
            {
                return JsonConvert.DeserializeObject(response.Content, type, serializerSettings);
            }
            catch (Exception e)
            {
                throw new ApiException(500, e.Message);
            }
        }

        /// <summary>
        /// Intercept the request and response objects during Api call
        /// </summary>
        /// <param name="response">The RestSharp response object</param>
        public void InterceptResponse(IRestResponse response)
        {
            LastApiResponse.Add(response);
        }

        /// <summary>
        /// Convert params to key/value pairs.
        /// Use collectionFormat to properly format lists and collections.
        /// </summary>
        /// <param name="collectionFormat">The collection format.</param>
        /// <param name="name">Key name.</param>
        /// <param name="value">Value object.</param>
        /// <returns>
        /// A list of KeyValuePairs
        /// </returns>
        public IEnumerable<KeyValuePair<string, string>> ParameterToKeyValuePairs(string collectionFormat, string name, object value)
        {
            var parameters = new List<KeyValuePair<string, string>>();

            if (IsCollection(value) && collectionFormat == "multi")
            {
                var valueCollection = value as IEnumerable;
                parameters.AddRange(from object item in valueCollection select new KeyValuePair<string, string>(name, ParameterToString(item)));
            }
            else
            {
                parameters.Add(new KeyValuePair<string, string>(name, ParameterToString(value)));
            }

            return parameters;
        }

        /// <summary>
        /// If parameter is DateTime, output in a formatted string (default ISO 8601), customizable with Configuration.DateTime.
        /// If parameter is a list, join the list with ",".
        /// Otherwise just return the string.
        /// </summary>
        /// <param name="obj">The parameter (header, path, query, form).</param>
        /// <returns>Formatted string.</returns>
        public string ParameterToString(object obj)
        {
            if (obj is DateTime)
            {
                // Return a formatted date string - Can be customized with Configuration.DateTimeFormat
                // Defaults to an ISO 8601, using the known as a Round-trip date/time pattern ("o")
                // https://msdn.microsoft.com/en-us/library/az4se3k1(v=vs.110).aspx#Anchor_8
                // For example: 2009-06-15T13:45:30.0000000
                return ((DateTime)obj).ToString(Configuration.DateTimeFormat);
            }
            else if (obj is DateTimeOffset)
            {
                // Return a formatted date string - Can be customized with Configuration.DateTimeFormat
                // Defaults to an ISO 8601, using the known as a Round-trip date/time pattern ("o")
                // https://msdn.microsoft.com/en-us/library/az4se3k1(v=vs.110).aspx#Anchor_8
                // For example: 2009-06-15T13:45:30.0000000
                return ((DateTimeOffset)obj).ToString(Configuration.DateTimeFormat);
            }
            else if (obj is IList)
            {
                var flattenedString = new StringBuilder();
                foreach (var param in (IList)obj)
                {
                    if (flattenedString.Length > 0)
                    {
                        flattenedString.Append(",");
                    }

                    flattenedString.Append(param);
                }

                return flattenedString.ToString();
            }
            else
            {
                return Convert.ToString(obj);
            }
        }

        /// <summary>
        /// Serialize an input (model) into JSON string
        /// </summary>
        /// <param name="obj">object.</param>
        /// <param name="settings">todo: describe settings parameter on Serialize</param>
        /// <returns>JSON string.</returns>
        public string Serialize(object obj, JsonSerializerSettings settings)
        {
            try
            {
                settings.DateFormatString = Configuration.DateTimeFormat;
                return obj != null ? JsonConvert.SerializeObject(obj, settings) : null;
            }
            catch (Exception e)
            {
                throw new ApiException(500, e.Message);
            }
        }

        /// <summary>
        /// Check if generic object is a collection.
        /// </summary>
        /// <param name="value">value</param>
        /// <returns>True if object is a collection type</returns>
        private static bool IsCollection(object value)
        {
            return value is IList || value is ICollection;
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