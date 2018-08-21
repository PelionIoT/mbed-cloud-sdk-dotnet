using System.Linq;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json.Linq;
using Pelion.Generation.src.common.generators;

namespace Pelion.Generation.src.common
{
    public class EnumContainer
    {
        public readonly string EnumName;

        public EnumDeclarationSyntax GeneratedEnum;

        public JToken Json;

        public EnumContainer(JToken enumJson)
        {
            Json = enumJson;
            EnumName = enumJson["enum_reference"]["pascal"].Value<string>();
            GeneratedEnum = EnumGenerators.CreateEnum(EnumName, enumJson["enum"].ToList().Select(e => e.Value<string>()).ToList());
        }
    }
}