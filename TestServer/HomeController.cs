using mbedCloudSDK.AccountManagement.Api;
using mbedCloudSDK.AccountManagement.Model.Account;
using mbedCloudSDK.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp.Contrib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

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
        public string TestModuleMethod(string module, string method, [FromUri] string args = "")
        {
            try
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

                //need config obj
                var assemblyTypes = Assembly.Load("mbedCloudSDK").GetTypes();
                //AccountManagementApi access = new AccountManagementApi(config);
                //var mods = assemblyTypes.Where(t => t.Name.Contains(camelModule));
                var moduleType = assemblyTypes.Where(t => t.Name == $"{camelModule}Api").FirstOrDefault();
                var moduleInstance = Activator.CreateInstance(moduleType, config);

                //get params for current method
                var methodInfo = moduleType.GetMethod(camelMethod);
                var @params = methodInfo.GetParameters();

                var serialisedParams = new List<object>();

                foreach (var p in @params)
                {
                    var paramType = p.ParameterType;

                    if (paramType.IsPrimitive || paramType == typeof(String))
                    {
                        var obj = argsJsonObj[p.Name] as JValue;

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
                    else
                    {
                        var properties = paramType.GetProperties();
                        //var a = new Account();
                        //var b = Activator.CreateInstance(typeof(Account));
                        //var newInst = Activator.CreateInstance(paramType);
                        
                        var vals = new JObject();

                        foreach (var prop in properties)
                        {
                            var propertyInst = paramType.GetProperty(prop.Name);
                            if (propertyInst != null)
                            {
                                if (argsJsonObj[propertyInst.Name] != null)
                                {
                                    vals[propertyInst.Name] = argsJsonObj[propertyInst.Name];
                                }
                            }
                        }

                        var obj = JsonConvert.DeserializeObject(vals.ToString(), paramType);

                        serialisedParams.Add(obj);
                    }
                }

                var result = methodInfo.Invoke(moduleInstance, serialisedParams.ToArray());

                return JsonConvert.SerializeObject(result);
            }
            catch(Exception e)
            {
                return "fail";
            }

        //    var assemblyTypes = Assembly.Load("mbedCloudSDK").GetTypes();
        //    var moduleType = assemblyTypes.Where(t => t.Name == camelModule).FirstOrDefault();
        //    var moduleInstance = Activator.CreateInstance(moduleType);

        //    //var constructors = moduleType.GetType().GetConstructors()

        //    //get from args
        //    var json = "{Id:1,number:4,stringInTheMiddle:\"no\",Name:\"Username\",city:\"Cambridge\",anotherString:\"anothStr\"}";
        //    JObject jsonObj = JObject.Parse(json);

        //    //get params for current method
        //    var methodInfo = moduleType.GetMethod(camelMethod);
        //    var @params = methodInfo.GetParameters();

        //    var serialisedParams = new List<object>();

        //    foreach (var p in @params)
        //    {
        //        var paramType = p.ParameterType;

        //        if (paramType.IsPrimitive || paramType == typeof(String))
        //        {
        //            var obj = jsonObj[p.Name] as JValue;

        //            //JValue integer type is int64, needs to be 32
        //            if (paramType == typeof(int))
        //            {
        //                serialisedParams.Add(Convert.ToInt32(obj.Value));
        //            }
        //            else
        //            {
        //                serialisedParams.Add(obj.Value);
        //            }
        //        }
        //        else
        //        {
        //            var properties = paramType.GetProperties();
        //            var newInst = Activator.CreateInstance(paramType);

        //            var vals = new JObject();

        //            foreach (var prop in properties)
        //            {
        //                var propertyInst = newInst.GetType().GetProperty(prop.Name);
        //                if (propertyInst != null)
        //                {
        //                    vals[propertyInst.Name] = jsonObj[propertyInst.Name];
        //                }
        //            }

        //            var obj = JsonConvert.DeserializeObject(vals.ToString(), paramType);

        //            serialisedParams.Add(obj);
        //        }
        //    }

        //    var result = methodInfo.Invoke(moduleInstance, serialisedParams.ToArray());

        //    return $"{module} - {method}: {result}";
        }
    }
}
