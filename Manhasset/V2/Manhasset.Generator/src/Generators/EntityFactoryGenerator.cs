using Manhasset.Core.src.Common;
using Manhasset.Core.src.Compile;
using Manhasset.Core.src.Containers;
using Manhasset.Generator.src.common;

namespace Manhasset.Generator.src.Generators
{
    public class EntityFactoryGenerator
    {
        public static void GenerateEntityFactory(string rootFilePath, Compilation compilation)
        {
            var entityFactory = new ClassContainer
            {
                Name = "EntityFactory",
                Namespace = "MbedCloud.SDK",
                FilePath = $"{rootFilePath}/EntityFactory.cs",
                DocString = "Entity Factory",
            };

            // // entity factory constructor
            // var entityFactoryConstructorContainer = new EntityFactoryConstructorContainer
            // {
            //     Name = "EntityFactory"
            // };

            // entityFactoryConstructorContainer.AddModifier(nameof(Modifiers.PUBLIC), Modifiers.PUBLIC);
            // entityFactory.AddConstructor(nameof(entityFactoryConstructorContainer), entityFactoryConstructorContainer);

            entityFactory.AddUsing(nameof(UsingKeys.SDK_COMMON), UsingKeys.SDK_COMMON);
            entityFactory.AddUsing(nameof(UsingKeys.ENTITIES), UsingKeys.ENTITIES);

            entityFactory.AddModifier(nameof(Modifiers.PUBLIC), Modifiers.PUBLIC);
            entityFactory.AddModifier(nameof(Modifiers.PARTIAL), Modifiers.PARTIAL);

            compilation.AddClass(nameof(entityFactory), entityFactory);
        }
    }
}