using mbedCloudSDK.AccountManagement.Api;
using mbedCloudSDK.AccountManagement.Model.Account;
using mbedCloudSDK.AccountManagement.Model.ApiKey;
using mbedCloudSDK.Common;
using mbedCloudSDK.Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using RestSharp.Contrib;
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

namespace TestServer
{
    public class HomeController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Init()
        {
            return Ok();
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
                return Content(HttpStatusCode.InternalServerError,new { Message = "No method found"});
            }

            var @params = GetMethodParams(methodInfo, argsJsonObj);

            try
            {
                var invokedMethod = methodInfo.Invoke(moduleInstance, @params.ToArray());

                var result = JsonConvert.SerializeObject(invokedMethod, Formatting.Indented, GetSnakeJsonSettings());

                return Ok(result);
            }
            catch(TargetInvocationException e)
            {
                if(e.InnerException.GetType() == typeof(CloudApiException))
                {
                    var exception = e.InnerException as CloudApiException;
                    if(exception.ErrorCode == 404)
                    {
                        return Content(HttpStatusCode.NotFound, exception);
                    }
                    else if(exception.ErrorCode == 400)
                    {
                        return Content(HttpStatusCode.BadRequest, exception);
                    }
                    else
                    {
                        return Content(HttpStatusCode.InternalServerError, exception);
                    }
                }
                if(e.InnerException.GetType() == typeof(statistics.Client.ApiException))
                {
                    var exception = e.InnerException as statistics.Client.ApiException;
                    if(exception.ErrorCode == 400)
                    {
                        return Content(HttpStatusCode.BadRequest, exception);
                    }else
                    {
                        return Content(HttpStatusCode.InternalServerError, exception);
                    }
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

        private List<Object> GetMethodParams(MethodInfo methodInfo, JObject argsJsonObj)
        {
            var @params = methodInfo.GetParameters();

            var serialisedParams = new List<object>();

            foreach (var p in @params)
            {
                var paramType = p.ParameterType;

                if (paramType.IsPrimitive || paramType == typeof(String))
                {
                    serialisedParams = GetParamValuePrimitive(p, paramType, argsJsonObj, serialisedParams);
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
                            vals = GetParamValue(propertyInst, argsJsonObj, vals);
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

        private JObject GetParamValue(PropertyInfo propertyInst, JObject argsJsonObj, JObject vals)
        {
            var customAttributes = propertyInst.GetCustomAttributes(typeof(NameOverrideAttribute), true);
            if (customAttributes.Length > 0)
            {
                var attribute = customAttributes[0] as NameOverrideAttribute;
                var valFromArgsAttr = argsJsonObj[attribute.Name.ToUpper()];
                if (valFromArgsAttr != null)
                {
                    vals[propertyInst.Name] = valFromArgsAttr;
                }
            }
            var valFromArgsProp = argsJsonObj[propertyInst.Name.ToUpper()];
            if (valFromArgsProp != null)
            {
                vals[propertyInst.Name] = valFromArgsProp;
            }
            return vals;
        }

        private List<object> GetParamValuePrimitive(ParameterInfo p,Type paramType, JObject argsJsonObj, List<object> serialisedParams)
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
                //JValue integer type is int64, needs to be 32
                if (paramType == typeof(int))
                {
                    serialisedParams.Add(Convert.ToInt32(obj.Value));
                }
                else
                {
                    serialisedParams.Add(obj.Value);
                }
            }else
            {
                serialisedParams.Add(null);
            }
            return serialisedParams;
        }
        
    }
}
