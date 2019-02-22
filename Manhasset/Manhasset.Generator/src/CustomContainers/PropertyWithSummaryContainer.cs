using Manhasset.Core.src.Containers;
using Manhasset.Core.src.Generators;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Manhasset.Generator.src.CustomContainers
{
    public class PropertyWithSummaryContainer : PropertyContainer
    {
        public override PropertyDeclarationSyntax GetSyntax()
        {
            var syntax = base.GetSyntax();

            // add summary
            var doc = DocumentationGenerators.GenerateSummary(DocString);
            syntax = syntax.AddSummary(DocString) as PropertyDeclarationSyntax;

            return syntax;
        }
    }
}