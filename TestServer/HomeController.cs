using mbedCloudSDK.AccountManagement.Api;
using mbedCloudSDK.AccountManagement.Model.Account;
using mbedCloudSDK.AccountManagement.Model.ApiKey;
using mbedCloudSDK.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using RestSharp.Contrib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace TestServer
{
    public class HomeController : ApiController
    {
        [HttpGet]
        public string Init()
        {
            return "Init";
        }

        [HttpGet]
        public IHttpActionResult TestModuleMethod(string module, string method, [FromUri] string args = "")
        {
            var config = new Config("ak_1MDE1YmM4NTQ4YzJkMDI0MjBhMDE2ZDA2MDAwMDAwMDA015d9d2cac1402420a010f13000000001GfsW837Iq7kH5wiXtdw3KoNBy2E7qvC");
            config.Host = "https://lab-api.mbedcloudintegration.net";

            var camelModule = Utils.SnakeToCamel(module);
            var camelMethod = Utils.SnakeToCamel(method);

            var argsJsonObj = new JObject();

            if (!string.IsNullOrEmpty(args))
            {
                var dict = HttpUtility.ParseQueryString(args);
                var camelDict = Utils.SnakeToCamelDict(dict);
                var argsJson = JsonConvert.SerializeObject(camelDict);
                argsJsonObj = JObject.Parse(argsJson);
            }

            var assemblyTypes = Assembly.Load("mbedCloudSDK").GetTypes();
            var moduleType = assemblyTypes.Where(t => t.Name == $"{camelModule}Api").FirstOrDefault();
            var moduleInstance = Activator.CreateInstance(moduleType, config);

            //get params for current method
            var methodInfo = moduleType.GetMethod(camelMethod);
            if(methodInfo == null)
            {
                return StatusCode(HttpStatusCode.InternalServerError);
            }
            var @params = methodInfo.GetParameters();

            var serialisedParams = new List<object>();

            foreach (var p in @params)
            {
                var paramType = p.ParameterType;

                if (paramType.IsPrimitive || paramType == typeof(String))
                {
                    var obj = argsJsonObj[p.Name.ToUpper()] as JValue;

                    if (obj != null)
                    {
                        //JValue integer type is int64, needs to be 32
                        if (paramType == typeof(int))
                        {
                            serialisedParams.Add(Convert.ToInt32(obj.Value));
                        }
                        else
                        {
                            serialisedParams.Add(obj.Value);
                        }
                    }
                }
                else if (paramType.FullName == "System.IO.Stream")
                {
                    var stream = new MemoryStream();
                    serialisedParams.Add(stream);
                }
                else
                {
                    var properties = paramType.GetProperties();                        
                    var vals = new JObject();

                    foreach (var prop in properties)
                    {
                        var propertyInst = paramType.GetProperty(prop.Name);
                        if (propertyInst != null)
                        {
                            var customAttributes = propertyInst.GetCustomAttributes(typeof(NameOverrideAttribute), true);
                            if(customAttributes.Length > 0)
                            {
                                var attribute = customAttributes[0] as NameOverrideAttribute;
                                if(argsJsonObj[attribute.Name.ToUpper()] != null)
                                {
                                    vals[propertyInst.Name] = argsJsonObj[attribute.Name.ToUpper()];
                                }
                            }
                            if (argsJsonObj[propertyInst.Name.ToUpper()] != null)
                            {
                                vals[propertyInst.Name] = argsJsonObj[propertyInst.Name.ToUpper()];
                            }
                        }
                    }

                    try
                    {
                        var obj = JsonConvert.DeserializeObject(vals.ToString(), paramType);

                        serialisedParams.Add(obj);
                    }
                    catch(Exception e)
                    {
                        return InternalServerError(e);
                    }
                }
            }

            if(serialisedParams.Count < @params.Length)
            {
                while(serialisedParams.Count < @params.Length)
                {
                    serialisedParams.Add(null);
                }
            }

            var settings = new JsonSerializerSettings();

            var contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            };

            settings.ContractResolver = contractResolver;

            try
            {

                var invokedMethod = methodInfo.Invoke(moduleInstance, serialisedParams.ToArray());

                var result = JsonConvert.SerializeObject(invokedMethod, Formatting.Indented, settings);

                return Ok(result);
            }
            catch(Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
