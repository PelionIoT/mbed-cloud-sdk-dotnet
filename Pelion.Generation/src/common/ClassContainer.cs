using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json.Linq;
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
            var modelClass = ClassGenerators.CreateClass(ClassName, Modifiers.PublicMod, Modifiers.AbstractMod);

            modelClass = modelClass.AddSummary(ClassName) as ClassDeclarationSyntax;

            modelClass = modelClass.AddBaseTypes(BaseTypes.BaseModel);
            AddUsing(common.Usings.BaseModel);

            var properties = Json[JsonKeys.fields];

            foreach (var item in properties)
            {
                if (item[JsonKeys.key].Value<string>() != "Id")
                {
                    modelClass = modelClass.AddProperty(ParseProperty(item));
                }
            }

            modelClass = modelClass.AddMethod(MethodGenerators.GenerateDebugDumpMethod()
                                                              .AddSummaryAndReturns("Get human readable string of this object", "Serialized string of object") as MethodDeclarationSyntax);
            AddUsing(common.Usings.DebugDump);

            GeneratedClass = modelClass;

            return this;
        }

        private PropertyDeclarationSyntax ParseProperty(JToken property)
        {
            var type = GetType(property["format"] ?? property["type"], property);
            var prop = PropertyGenerators.CreateProperty(type, property["_KeY"].Value<string>());
            //prop = prop.AddAttribute("JsonProperty");
            //AddUsing(common.Usings.JsonConverter);
            prop = prop.AddSummary(property[JsonKeys.description].Value<string>()) as PropertyDeclarationSyntax;
            return prop;
        }

        private TypeSyntax GetType(JToken type, JToken property)
        {
            var strType = type.Value<string>();
            switch (strType)
            {
                case "string":
                    return Types.@string;
                case "date-time":
                    AddUsing(common.Usings.System);
                    return Types.date;
                case "array":
                    AddUsing(common.Usings.Lists);
                    // TODO need more info to generate List<T>
                    return Types.List("string");
                case "boolean":
                    return Types.@bool;
                case "integer":
                case "int32":
                case "int64":
                    return Types.@int;

                default:
                    return default(TypeSyntax);
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