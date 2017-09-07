using mbedCloudSDK.AccountManagement.Api;
using mbedCloudSDK.AccountManagement.Model.Account;
using mbedCloudSDK.AccountManagement.Model.ApiKey;
using mbedCloudSDK.Common;
using mbedCloudSDK.Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using RestSharp.Extensions.MonoHttp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using mbedCloudSDK.Connect.Model.ConnectedDevice;
using mds.Model;

namespace TestServer
{
    public class HomeController : ApiController
    {
        private SingletonModuleInstance _moduleRepository;

        public HomeController()
        {
            _moduleRepository = new SingletonModuleInstance();
        }
        [HttpGet]
        public IHttpActionResult Init()
        {
            return Ok("Init");
        }

        [HttpGet]
        public IHttpActionResult TestModuleMethod(string module, string method, [FromUri] string args = "")
        {
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

            var moduleInstance = _moduleRepository.Create().GetModules()[camelModule];
            var moduleType = moduleInstance.GetType();

            //get params for current method
            var methodInfo = moduleType.GetMethod(camelMethod);
            if(methodInfo == null)
            {
                return Content(HttpStatusCode.InternalServerError,new { Message = "No method found"});
            }

            try
            {
                var @params = GetMethodParams(methodInfo, argsJsonObj);
                var invokedMethod = methodInfo.Invoke(moduleInstance, @params.ToArray());
                if (invokedMethod != null)
                {
                    if(invokedMethod.GetType().Name == "AsyncConsumer`1")
                    {
                        var asyncConsumer = invokedMethod as AsyncConsumer<string>;
                        return Ok(asyncConsumer.ToString());
                    }
                }
                var result = JsonConvert.SerializeObject(invokedMethod, Formatting.Indented, GetSnakeJsonSettings());
                return Ok(JsonConvert.DeserializeObject(result));
            }
            catch(TargetInvocationException e)
            {
                if(e.InnerException.GetType().GetProperty("ErrorCode") != null){
                    dynamic innerException = e.InnerException;
                    if(innerException.ErrorCode == 400){
                        return Content(HttpStatusCode.BadRequest, innerException);
                    }else if(innerException.ErrorCode == 404){
                        return Content(HttpStatusCode.NotFound, innerException);
                    }

                    return Content(HttpStatusCode.InternalServerError, innerException);
                }
                
                return Content(HttpStatusCode.InternalServerError, e.InnerException);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e);
            }
        }

        private JsonSerializerSettings GetSnakeJsonSettings()
        {
            var settings = new JsonSerializerSettings();
            var contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            };
            settings.ContractResolver = contractResolver;
            return settings;
        }

        private JsonSerializerSettings GetCamelJsonSettings()
        {
            var settings = new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            return settings;
        }

        private List<Object> GetMethodParams(MethodInfo methodInfo, JObject argsJsonObj)
        {
            var @params = methodInfo.GetParameters();
            var serialisedParams = new List<object>();
            foreach (var p in @params)
            {
                var paramType = p.ParameterType;
                if (paramType.IsPrimitive || paramType == typeof(String))
                {
                    var paramValue = GetParamValuePrimitive(p, paramType, argsJsonObj);
                    serialisedParams.Add(paramValue);
                }
                else if(paramType.IsArray){
                    // currently not generic because EndpointName is sent as device_id and as Presubscription is generated, it cannot be decorated with a name attribute to correct this.
                    var arrayType = paramType.GetElementType();
                    if(arrayType == typeof(Presubscription))
                    {
                        var stringArg = GetParamValuePrimitive(p, paramType, argsJsonObj) as string;
                        var json = JsonConvert.DeserializeObject(stringArg, typeof(JObject[])) as JObject[];
                        var presubList = new List<Presubscription>();
                        foreach (var item in json)
                        {
                            var presub = new Presubscription();
                            presub.EndpointName = item["device_id"].Value<string>();
                            var pathList = new List<ResourcePath>();
                            foreach (var path in item["resource_paths"])
                            {
                                pathList.Add(new ResourcePath());
                            }
                            presub.ResourcePath = pathList;
                            presubList.Add(presub);
                        }
                        serialisedParams.Add(presubList.ToArray());
                    }
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
                            var paramValue = GetParamValue(propertyInst, argsJsonObj);
                            vals[propertyInst.Name] = paramValue;
                        }
                    }
                    try
                    {
                        var obj = JsonConvert.DeserializeObject(vals.ToString(), paramType);
                        serialisedParams.Add(obj);
                    }
                    catch(JsonReaderException e)
                    {
                        serialisedParams.Add(null);
                    }
                }
            }

            if (serialisedParams.Count < @params.Length)
            {
                while (serialisedParams.Count < @params.Length)
                {
                    serialisedParams.Add(null);
                }
            }
            return serialisedParams;
        }

        private JToken GetParamValue(PropertyInfo propertyInst, JObject argsJsonObj)
        {
            var customAttributes = propertyInst.GetCustomAttributes(typeof(NameOverrideAttribute), true);
            if (customAttributes.Length > 0)
            {
                var attribute = customAttributes[0] as NameOverrideAttribute;
                var valFromArgsAttr = argsJsonObj[attribute.Name.ToUpper()];
                if (valFromArgsAttr != null)
                {
                    return valFromArgsAttr;
                }
            }
            var valFromArgsProp = argsJsonObj[propertyInst.Name.ToUpper()];
            if (valFromArgsProp != null)
            {
                return valFromArgsProp;
            }

            return null;
        }

        private object GetParamValuePrimitive(ParameterInfo p,Type paramType, JObject argsJsonObj)
        {
            JValue obj;
            var customParamAttributes = p.GetCustomAttributes(typeof(NameOverrideAttribute), true);
            if (customParamAttributes.Length > 0)
            {
                var attribute = customParamAttributes[0] as NameOverrideAttribute;
                var valFromAttr = argsJsonObj[attribute.Name.ToUpper()];
                if (valFromAttr != null)
                {
                    obj = valFromAttr as JValue;
                }else
                {
                    obj = null;
                }
            }
            else
            {
                obj = argsJsonObj[p.Name.ToUpper()] as JValue;
            }

            if (obj != null)
            {
                if (paramType == typeof(int))
                {
                    return Convert.ToInt32(obj.Value);
                }
                else
                {
                    return obj.Value;
                }
            }else
            {
                return null;
            }
        }
    }
}