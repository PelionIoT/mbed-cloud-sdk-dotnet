using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using MbedCloudSDK.Common;
using MbedCloudSDK.Common.Filter;
using MbedCloudSDK.Connect.Model.ConnectedDevice;
using MbedCloudSDK.Connect.Model.Subscription;
using MbedCloudSDK.IntegrationTests.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using TestServer;

namespace MbedCloudSDK.IntegrationTests.Services
{
    public interface IMethodRunnerService
    {
        object TestModuleMethod(Instance module, object moduleInstance, string method, Dictionary<string, object> args = null);
    }
    public class MethodRunnerService : IMethodRunnerService
    {
        public object TestModuleMethod(Instance module, object moduleInstance, string method, Dictionary<string, object> args = null)
        {
            var camelMethod = TestServer.Utils.SnakeToCamel(method);

            var argsJsonObj = new JObject();
            if (args != null)
            {
                var camelDict = TestServer.Utils.SnakeToCamelDict(args);
                var argsJson = JsonConvert.SerializeObject(camelDict, GetDateSettings());
                argsJsonObj = JObject.Parse(argsJson);
            }

            var moduleType = moduleInstance.GetType();

            //get params for current method
            var methodInfo = moduleType.GetMethods().Where(m => m.Name == camelMethod).FirstOrDefault();
            if (methodInfo == null)
            {
                throw new Exception("no method found");
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
                        return asyncConsumer.ToString();
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
                            tempJson.Add(TestServer.Utils.CamelToSnake(row.Key), row.Value);
                        }

                        return tempJson;
                    }
                    if (methodInfo.ReturnType.Name.StartsWith("PaginatedResponse"))
                    {
                        // if return type is a paginator, call all and return as data
                        return new PaginatedResult
                        {
                            Data = methodInfo.ReturnType.GetMethod("All").Invoke(invokedMethod, null),
                        };
                    }

                }
                var result = JsonConvert.SerializeObject(invokedMethod, Formatting.Indented, GetSerializerSettings());
                if (result == null || result == "null")
                {
                    return null;
                }

                return JsonConvert.DeserializeObject(result);
            }
            catch (TargetInvocationException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
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

        private JsonSerializerSettings GetSerializerSettings()
        {
            var settings = new JsonSerializerSettings()
            {
                DateFormatString = "yyyy-MM-ddTHH:mm:ss.ffffffZ",
                DateTimeZoneHandling = DateTimeZoneHandling.Utc
            };
            var contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy(),
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
                else if (paramType == typeof(DateTime))
                {
                    var val = argsJsonObj[p.Name.ToUpper()].Value<string>();
                    var isDate = DateTime.TryParseExact(val, "MM/dd/yyyy HH:mm:ss", null, DateTimeStyles.None, out DateTime dateValue);
                    if (isDate)
                    {
                        var dateWithMilli = argsJsonObj[p.Name.ToUpper()].Value<DateTime>();
                        serialisedParams.Add(dateWithMilli);
                    }
                    else
                    {
                        serialisedParams.Add(null);
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

            // if obj is nested obj
            if (obj == null)
            {
                var token = argsJsonObj[p.Name.ToUpper()] as JToken;
                if (token != null)
                    return token.ToString();
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