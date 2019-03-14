using System.Linq;
using Manhasset.Core.src.Common;
using Manhasset.Core.src.Compile;
using Manhasset.Core.src.Containers;
using Manhasset.Generator.src.common;
using Manhasset.Generator.src.CustomContainers;
using Manhasset.Generator.src.extensions;
using Newtonsoft.Json.Linq;

namespace Manhasset.Generator.src.Generators
{
    public class EntityFactoryGenerator
    {
        public static void GenerateEntityFactory(JToken entities, string rootFilePath, Compilation compilation)
        {
            var entityFactory = new ClassContainer
            {
                Name = "FoundationFactory",
                Namespace = UsingKeys.FOUNDATION_FACTORY_CLASS,
                FilePath = $"{rootFilePath}/FoundationFactory.cs",
                DocString = "Foundation Factory",
            };

            entityFactory.AddUsing(nameof(UsingKeys.SDK_COMMON), UsingKeys.SDK_COMMON);
            entityFactory.AddUsing(nameof(UsingKeys.FOUNDATION), UsingKeys.FOUNDATION);

            entityFactory.AddModifier(nameof(Modifiers.PUBLIC), Modifiers.PUBLIC);
            entityFactory.AddModifier(nameof(Modifiers.PARTIAL), Modifiers.PARTIAL);

            foreach (var entity in entities.Where(e => e["methods"].Any()))
            {
                var factoryMethod = new EntityFactoryMethodContainer
                {
                    Name = $"{entity["_key"].GetStringValue().ToPascal()}Repository",
                    Returns = $"{entity["_key"].GetStringValue().ToPascal()}Repository",
                    MethodParams = new MethodParameterContainer(),
                };
                factoryMethod.AddModifier(nameof(Modifiers.PUBLIC), Modifiers.PUBLIC);
                entityFactory.AddMethod(entity["_key"].GetStringValue(), factoryMethod);
            }

            compilation.AddClass(nameof(entityFactory), entityFactory);
        }
    }
}