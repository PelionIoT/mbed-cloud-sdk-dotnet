using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json.Linq;
using MbedCloudSDK.Common.Extensions;
using Pelion.Generation.src.common.generators;

namespace Pelion.Generation.src.common
{
    public class ClassContainer
    {
        public readonly string ClassName;

        public ClassDeclarationSyntax GeneratedClass;

        public List<string> Usings;

        public JToken Json;

        public ClassContainer(string className, ClassDeclarationSyntax generatedClass)
        {
            ClassName = className;
            GeneratedClass = generatedClass;
            Usings = new List<string>();
        }

        public ClassContainer(string className, JToken json)
        {
            ClassName = className;
            Json = json;
            Usings = new List<string>();
        }

        public ClassContainer GenerateModelClass()
        {
            var modelClass = ClassGenerators.CreateClass(ClassName, Modifiers.PublicMod, Modifiers.PartialMod);

            modelClass = modelClass.AddSummary(ClassName) as ClassDeclarationSyntax;

            modelClass = modelClass.AddBaseTypes(BaseTypes.BaseModel);
            AddUsing(common.Usings.BaseModel);

            modelClass = GenerateProperties(modelClass);

            modelClass = GenerateMethods(modelClass);

            modelClass = modelClass.AddMethod(MethodGenerators.GenerateDebugDumpMethod()
                                                              .AddSummaryAndReturns("Get human readable string of this object", "Serialized string of object") as MethodDeclarationSyntax);
            AddUsing(common.Usings.DebugDump);

            GeneratedClass = modelClass;

            return this;
        }

        private ClassDeclarationSyntax GenerateProperties(ClassDeclarationSyntax modelClass)
        {
            var properties = Json[JsonKeys.fields];

            foreach (var item in properties)
            {
                if (item[JsonKeys.key][JsonKeys.pascal].Value<string>() != "Id")
                {
                    modelClass = modelClass.AddProperty(ParseProperty(item));
                }
            }

            return modelClass;
        }

        private ClassDeclarationSyntax GenerateMethods(ClassDeclarationSyntax modelClass)
        {
            var methods = Json[JsonKeys.methods];

            foreach (var item in methods)
            {
                Console.WriteLine("'''''''''''''''''''''''''''''''''''");
                // Console.WriteLine(item);
                Console.WriteLine($"{item["mode"].Value<string>()}-{item["method"].Value<string>()}");
                Console.WriteLine($"Mode - {item["_key"]["pascal"].Value<string>()}");
                Console.WriteLine($"Method - {item["method"].Value<string>()}");
                Console.WriteLine($"Path - {item["path"].Value<string>()}");

                var returns = ClassName;
                var methodName = item["_key"]["pascal"].Value<string>();
                var method = item["method"].Value<string>();
                var path = item["path"].Value<string>();
                var paramDict = new Dictionary<string, string>();
                var renameDict = new Dictionary<string, string>();
                var bodyDict = new Dictionary<string, string>();

                if (item["parameter_map"] != null)
                {
                    foreach (var parameter in (JObject)item["parameter_map"])
                    {
                        paramDict.Add(parameter.Key, parameter.Value.ToString().SnakeToCamel());
                        Console.WriteLine($"{parameter.Key} - {parameter.Value.ToString().SnakeToCamel()}");
                    }
                }

                if (item["field_renames"] != null)
                {
                    foreach (var rename in item["field_renames"])
                    {
                        renameDict.Add(rename["_key"]["pascal"].Value<string>(), rename["api_fieldname"].Value<string>());
                        Console.WriteLine($"{rename["_key"]["pascal"].Value<string>()} - {rename["api_fieldname"].Value<string>()}");
                    }
                }

                if (item["fields"] != null)
                {
                    foreach (var field in item["fields"])
                    {
                        //Console.WriteLine(field["in"].First);
                        if (field["in"].Value<string>() == "body")
                        {
                            Console.WriteLine($"{field["_key"]["pascal"].Value<string>()}");
                            var val = field["_key"]["pascal"].Value<string>();
                            bodyDict.Add(val, val);
                        }
                    }
                }

                Console.WriteLine("'''''''''''''''''''''''''''''''''''");

                var genMethod = MethodGenerators.GenerateCrudMethod(
                    returns: returns,
                    methodName: methodName,
                    method: method,
                    path: path,
                    renames: renameDict,
                    pathParams: paramDict,
                    bodyParams: bodyDict
                );

                AddUsingsForGet();
                modelClass = modelClass.AddMethod(genMethod);

                Console.WriteLine(genMethod.ToFullString());
            }

            return modelClass;
        }

        private void AddUsingsForGet()
        {
            AddUsing(common.Usings.Lists);
            AddUsing(common.Usings.Task);
            AddUsing(common.Usings.Client);
            AddUsing(common.Usings.Common);
            AddUsing(common.Usings.Exceptions);
            AddUsing(common.Usings.RestSharp);
        }

        private void AddUsingsForCreate()
        {
            AddUsing(common.Usings.Lists);
            AddUsing(common.Usings.Task);
            AddUsing(common.Usings.Client);
            AddUsing(common.Usings.Common);
            AddUsing(common.Usings.Exceptions);
            AddUsing(common.Usings.RestSharp);
        }

        private void AddUsingsForUpdate()
        {
            AddUsing(common.Usings.Lists);
            AddUsing(common.Usings.Task);
            AddUsing(common.Usings.Client);
            AddUsing(common.Usings.Common);
            AddUsing(common.Usings.Exceptions);
            AddUsing(common.Usings.RestSharp);
        }

        private void AddUsingsForDelete()
        {
            AddUsing(common.Usings.Lists);
            AddUsing(common.Usings.Task);
            AddUsing(common.Usings.Client);
            AddUsing(common.Usings.Common);
            AddUsing(common.Usings.Exceptions);
            AddUsing(common.Usings.RestSharp);
        }

        private PropertyDeclarationSyntax ParseProperty(JToken property)
        {
            var type = GetType(property);
            var prop = PropertyGenerators.CreateProperty(type, property[JsonKeys.key][JsonKeys.pascal].Value<string>());
            if (property["enum"] != null)
            {
                prop = prop.AddEnumConverterAttribute();
                AddUsing(common.Usings.JsonConverter);
                AddUsing(common.Usings.StringEnumConverter);
            }
            //prop = prop.AddAttribute("JsonProperty");
            //AddUsing(common.Usings.JsonConverter);
            prop = prop.AddSummary(property[JsonKeys.description].Value<string>()) as PropertyDeclarationSyntax;
            return prop;
        }

        private TypeSyntax GetType(JToken property)
        {
            if (property["enum"] != null)
            {
                return Types.CustomType(property["enum_reference"]["pascal"].Value<string>());
            }

            var type = property["format"] ?? property["type"];

            var strType = type.Value<string>();
            return _type(strType, property);

            TypeSyntax _type(string _strType, JToken _property = null)
            {
                switch (_strType)
                {
                    case "string":
                        return Types.@string;
                    case "date-time":
                        AddUsing(common.Usings.System);
                        return Types.date;
                    case "array":
                        AddUsing(common.Usings.Lists);
                        // if (_property != null)
                        // {
                        //     Console.WriteLine(property);
                        //     Console.WriteLine(property["items"]);
                        //     var item = property["items"];
                        //     if (item["type"] != null)
                        //     {
                        //         return Types.List(_type(item["type"].Value<string>()).ToString());
                        //     }
                        //     return Types.List("object");
                        // }
                        return Types.List("object");
                    case "boolean":
                        return Types.@bool;
                    case "integer":
                    case "int32":
                        return Types.@int;
                    case "int64":
                        return Types.@long;

                    default:
                        return default(TypeSyntax);
                }
            }
        }

        public void AddUsing(string @using)
        {
            if(!Usings.Any(u => u.ToString() == @using.ToString()))
            {
                Usings.Add(@using);
            }
        }

        private string GetReferenceNamespace(string entityName)
        {
            return $"Pelion.Generated.{entityName}";
        }
    }
}