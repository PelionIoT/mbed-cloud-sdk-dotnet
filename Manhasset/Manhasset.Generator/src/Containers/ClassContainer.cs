using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json.Linq;
using MbedCloudSDK.Common.Extensions;
using Manhasset.Core.src.Generators;
using Manhasset.Core.src.Helpers;
using Manhasset.Generator.src.Helpers;

namespace Manhasset.Generator.src.Containers
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

        public ClassContainer GenerateRenameClass(Dictionary<string, Dictionary<string, string>> renames)
        {
            var renameClass = ClassGenerators.CreateClass(ClassName, Modifiers.PublicMod, Modifiers.StaticMod);

            AddUsing(Helpers.Usings.System);
            AddUsing(Helpers.Usings.Lists);

            renameClass = renameClass.AddMembers(DictionaryGenerators.GenerateRenameDictionary(renames));

            GeneratedClass = renameClass;

            return this;
        }

        public ClassContainer GenerateModelClass()
        {
            var modelClass = ClassGenerators.CreateClass(ClassName, Modifiers.PublicMod, Modifiers.PartialMod);

            modelClass = modelClass.AddSummary(ClassName) as ClassDeclarationSyntax;

            modelClass = modelClass.WithMembers(ConstructorGenerators.GenerateConstructors(ClassName));

            modelClass = modelClass.AddBaseTypes(BaseTypes.BaseModel);
            AddUsing(Helpers.Usings.BaseModel);

            modelClass = GenerateProperties(modelClass);

            modelClass = GenerateMethods(modelClass);

            modelClass = modelClass.AddMethod(MethodGenerators.GenerateDebugDumpMethod()
                                                              .AddSummaryAndReturns("Get human readable string of this object", "Serialized string of object") as MethodDeclarationSyntax);
            AddUsing(Helpers.Usings.DebugDump);
            AddUsing(Helpers.Usings.Renames);

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
                var methodParamDict = new Dictionary<string, TypeSyntax>();
                var methodParamRequiredDict = new Dictionary<string, TypeSyntax>();
                var pathDict = new Dictionary<string, string>();
                var queryDict = new Dictionary<string, string>();
                var renameDict = new Dictionary<string, string>();
                var bodyDict = new Dictionary<string, string>();
                // FIXME should be false when solution for static methods is introduced
                var staticPaginator = false;

                var parameterRemaps = new Dictionary<string, string>();

                var paginated = (item["pagination"] != null) ? item["pagination"].Value<bool>() : false;

                if (paginated)
                {
                    AddUsing(Helpers.Usings.QueryOptions);
                }

                var foreignKey = (item["foreign_key"] != null) ? (item["foreign_key"]["entity"]["pascal"].Value<string>() != ClassName) : false;

                Console.WriteLine($"Is foreign key - {foreignKey}");

                if (foreignKey)
                {
                    returns = item["foreign_key"]["entity"]["pascal"].Value<string>();
                    AddUsing(Helpers.Usings.GetForeignKey(item["foreign_key"]["group"]["pascal"].Value<string>(), item["foreign_key"]["entity"]["pascal"].Value<string>()));

                    if (paginated)
                    {
                        staticPaginator = false;
                    }
                }

                if (item["parameter_map"] != null)
                {
                    foreach (var parameter in (JObject)item["parameter_map"])
                    {
                        parameterRemaps.Add(parameter.Value.ToString().SnakeToCamel(), parameter.Key);
                    }
                }

                if (item["fields"] != null)
                {
                    foreach (var field in item["fields"])
                    {
                        var external = (field["external_param"] != null) ? field["external_param"].Value<bool>() : false;
                        if (external)
                        {
                            var type = GetType(field);
                            var required = field["required"].Value<bool>();
                            Console.WriteLine(required);
                            if (required)
                            {
                                Console.WriteLine($"{type.ToString()} - {field["_key"]["lower_camel"].ToString()}");
                                methodParamRequiredDict.Add(field["_key"]["lower_camel"].Value<string>(), type);
                            }
                            else
                            {
                                Console.WriteLine($"{type.ToString()} - {field["_key"]["lower_camel"].ToString()}");
                                methodParamDict.Add(field["_key"]["lower_camel"].Value<string>(), type);
                            }

                            arrangeParams(field["in"].Value<string>(), field["_key"]["lower_camel"].Value<string>());
                        }
                        else
                        {
                            arrangeParams(field["in"].Value<string>(), field["_key"]["pascal"].Value<string>());
                        }

                        void arrangeParams(string location, string value)
                        {
                            switch(location)
                            {
                                case "body":
                                    bodyDict.Add(parameterRemaps.ContainsKey(value) ? parameterRemaps[value] : value, value);
                                    break;
                                case "path":
                                    pathDict.Add(parameterRemaps.ContainsKey(value) ? parameterRemaps[value] : value, value);
                                    break;
                                case "query":
                                    queryDict.Add(parameterRemaps.ContainsKey(value) ? parameterRemaps[value] : value, value);
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }

                Console.WriteLine($"static paginator - {staticPaginator}");

                Console.WriteLine("'''''''''''''''''''''''''''''''''''");

                var genMethod = MethodGenerators.GenerateCrudMethod(
                    returns: returns,
                    methodName: methodName,
                    method: method,
                    path: path,
                    renames: renameDict,
                    pathParams: pathDict,
                    bodyParams: bodyDict,
                    methodParams: methodParamDict,
                    methodParamsRequired: methodParamRequiredDict,
                    queryParams: queryDict,
                    paginated: paginated,
                    staticPaginator: staticPaginator
                );

                AddUsingsForCRUDL();
                modelClass = modelClass.AddMethod(genMethod);

                // Console.WriteLine(CodePrinter.PrintCode(genMethod));
            }

            return modelClass;
        }

        private void AddUsingsForCRUDL()
        {
            AddUsing(Helpers.Usings.Lists);
            AddUsing(Helpers.Usings.Task);
            AddUsing(Helpers.Usings.Client);
            AddUsing(Helpers.Usings.Common);
            AddUsing(Helpers.Usings.Exceptions);
            AddUsing(Helpers.Usings.RestSharp);
        }

        private PropertyDeclarationSyntax ParseProperty(JToken property)
        {
            var type = GetType(property);
            var prop = PropertyGenerators.CreateProperty(type, property[JsonKeys.key][JsonKeys.pascal].Value<string>());
            if (property["enum"] != null)
            {
                prop = prop.AddEnumConverterAttribute();
                AddUsing(Helpers.Usings.JsonConverter);
                AddUsing(Helpers.Usings.StringEnumConverter);
            }
            //prop = prop.AddAttribute("JsonProperty");
            //AddUsing(common.Usings.JsonConverter);
            if (property[JsonKeys.description] != null)
            {
                prop = prop.AddSummary(property[JsonKeys.description].Value<string>()) as PropertyDeclarationSyntax;
            }

            return prop;
        }

        private TypeSyntax GetType(JToken property)
        {
            if (property["enum"] != null)
            {
                return Types.CustomType(property["enum_reference"]["pascal"].Value<string>(), true);
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
                        AddUsing(Helpers.Usings.System);
                        return Types.date;
                    case "array":
                        AddUsing(Helpers.Usings.Lists);
                        if (_property != null)
                        {
                            var item = _property["items"];

                            if (item["foreign_key"] != null)
                            {
                                AddUsing(Helpers.Usings.GetForeignKey(item["foreign_key"]["group"]["pascal"].Value<string>(), item["foreign_key"]["entity"]["pascal"].Value<string>()));
                                return Types.List(item["foreign_key"]["entity"]["pascal"].Value<string>());
                            }

                            if (item["type"] != null)
                            {
                                return Types.List(_type(item["type"].Value<string>()).ToString());
                            }

                            return Types.List("object");
                        }
                        return Types.List("object");
                    case "boolean":
                        return Types.@bool;
                    case "integer":
                    case "int32":
                        return Types.@int;
                    case "int64":
                        return Types.@long;
                    case "object":
                        return Types.@object;

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