using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MbedCloudSDK.AccountManagement.Api;
using MbedCloudSDK.AccountManagement.Model.Account;
using MbedCloudSDK.AccountManagement.Model.ApiKey;
using MbedCloudSDK.Common;
using MbedCloudSDK.Common.Filter;
using MbedCloudSDK.Connect.Model.ConnectedDevice;
using MbedCloudSDK.Connect.Model.Subscription;
using MbedCloudSDK.Exceptions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace TestServer
{
    public class HomeController : Controller
    {
        private SingletonModuleInstance _moduleRepository;
        private IApplicationLifetime _life;

        public HomeController(IApplicationLifetime life)
        {
            _moduleRepository = new SingletonModuleInstance();
            _life = life;
        }

        [HttpGet]
        public IActionResult Init()
        {
            _moduleRepository.Create();
            return Ok("Init");
        }

        [HttpGet]
        public string Exit()
        {
            _moduleRepository.Create().StopNotifications();
            Console.WriteLine("Finished...");
            _life.StopApplication();
            return "bye";
        }

        [HttpGet]
        public IActionResult TestModuleMethod(string module, string method, [FromQuery] string args = "")
        {
            var camelModule = Utils.SnakeToCamel(module);
            var camelMethod = Utils.SnakeToCamel(method);

            var argsJsonObj = new JObject();
            if (!string.IsNullOrEmpty(args))
            {
                var dict = Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(args);
                var camelDict = Utils.SnakeToCamelDict(dict);
                var argsJson = JsonConvert.SerializeObject(camelDict, GetDateSettings());
                argsJsonObj = JObject.Parse(argsJson);
            }

            var moduleInstance = _moduleRepository.Create().GetModules()[camelModule];
            var moduleType = moduleInstance.GetType();

            //get params for current method
            var methodInfo = moduleType.GetMethod(camelMethod);
            if (methodInfo == null)
            {
                Response.StatusCode = 500;
                return Json("No method found");
            }

            try
            {
                var @params = GetMethodParams(methodInfo, argsJsonObj);
                var invokedMethod = methodInfo.Invoke(moduleInstance, @params.ToArray());
                if (invokedMethod != null)
                {
                    if (invokedMethod.GetType() == typeof(AsyncConsumer<string>))
                    {
                        var asyncConsumer = invokedMethod as AsyncConsumer<string>;
                        return Ok(asyncConsumer.ToString());
                    }
                    if (invokedMethod.GetType().GetProperties().Select(p => p.Name).Contains("DeviceFilter"))
                    {
                        var returnedJson = JObject.FromObject(invokedMethod);
                        var tempJson = new JObject();

                        var deviceFilter = returnedJson["DeviceFilter"];
                        returnedJson.Remove("DeviceFilter");
                        returnedJson.Add("DeviceFilter", JObject.FromObject(deviceFilter["FilterJson"]));

                        foreach (var row in returnedJson)
                        {
                            tempJson.Add(Utils.CamelToSnake(row.Key), row.Value);
                        }

                        return Ok(tempJson);
                    }

                }
                var result = JsonConvert.SerializeObject(invokedMethod, Formatting.Indented, GetSnakeJsonSettings());
                if (result == null || result == "null")
                {
                    return Ok(new object());
                }

                return Ok(JsonConvert.DeserializeObject(result));
            }
            catch (TargetInvocationException e)
            {
                if (e.InnerException.GetType().GetProperty("ErrorCode") != null)
                {
                    dynamic innerException = e.InnerException;
                    if (innerException.ErrorCode == 400)
                    {
                        return BadRequest(innerException);
                    }
                    else if (innerException.ErrorCode == 404)
                    {
                        return NotFound(innerException);
                    }

                    Response.StatusCode = 500;
                    return Json(innerException);
                }

                Response.StatusCode = 500;
                return Json(e.InnerException.Message);
            }
            catch (Exception e)
            {
                Response.StatusCode = 500;
                return Json(e.Message);
            }
        }

        private JsonSerializerSettings GetDateSettings()
        {
            var settings = new JsonSerializerSettings()
            {
                DateFormatString = "yyyy-MM-ddTHH:mm:ss.ffffffZ",
                DateTimeZoneHandling = DateTimeZoneHandling.Utc
            };
            return settings;
        }

        private JsonSerializerSettings GetSnakeJsonSettings()
        {
            var settings = new JsonSerializerSettings()
            {
                DateFormatString = "yyyy-MM-ddTHH:mm:ss.ffffffZ",
                DateTimeZoneHandling = DateTimeZoneHandling.Utc
            };
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
                else if (paramType.IsArray)
                {
                    // currently not generic because EndpointName is sent as device_id and as Presubscription is generated, it cannot be decorated with a name attribute to correct this.
                    var arrayType = paramType.GetElementType();
                    if (arrayType == typeof(Presubscription))
                    {
                        var stringArg = GetParamValuePrimitive(p, paramType, argsJsonObj) as string;
                        var json = JsonConvert.DeserializeObject(stringArg, typeof(JObject[])) as JObject[];
                        var presubList = new List<Presubscription>();
                        foreach (var item in json)
                        {
                            var presub = new Presubscription();
                            presub.DeviceId = item["device_id"].Value<string>();
                            var pathList = new List<string>();
                            foreach (var path in item["resource_paths"])
                            {
                                pathList.Add(path.Value<string>());
                            }
                            presub.ResourcePaths = pathList;
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
                            if (propertyInst.PropertyType.Name == "Filter")
                            {
                                var filterJson = GetParamValue(propertyInst, argsJsonObj);
                                var filterJsonString = filterJson != null ? filterJson.ToString() : "";
                                if (filterJsonString.Contains("filter_string"))
                                {
                                    var filterJsonObj = JsonConvert.DeserializeObject(filterJsonString) as JObject;
                                    var dict = filterJsonObj["filter_json"].ToString();
                                    var obj = JToken.FromObject(new Filter(dict, string.IsNullOrEmpty(dict)));
                                    vals[propertyInst.Name] = obj;
                                }
                                else
                                {
                                    var filterJToken = JToken.FromObject(new Filter(filterJsonString, string.IsNullOrEmpty(filterJsonString)));
                                    vals[propertyInst.Name] = filterJToken;
                                }
                            }
                            else if (propertyInst.PropertyType == typeof(List<string>))
                            {
                                var paramValue = GetParamValue(propertyInst, argsJsonObj);
                                if (paramValue != null)
                                {
                                    var list = JsonConvert.DeserializeObject<List<string>>(paramValue.ToString());
                                    vals[propertyInst.Name] = JToken.FromObject(list);
                                }
                                else
                                {
                                    vals[propertyInst.Name] = paramValue;
                                }
                            }
                            else
                            {
                                var paramValue = GetParamValue(propertyInst, argsJsonObj);
                                vals[propertyInst.Name] = paramValue;
                            }
                        }
                    }
                    try
                    {
                        var obj = JsonConvert.DeserializeObject(vals.ToString(), paramType);
                        serialisedParams.Add(obj);
                    }
                    catch (JsonReaderException)
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

        private object GetParamValuePrimitive(ParameterInfo p, Type paramType, JObject argsJsonObj)
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
                }
                else
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
            }
            else
            {
                return null;
            }
        }
    }
}