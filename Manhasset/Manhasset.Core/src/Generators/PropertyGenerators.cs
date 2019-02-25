using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Manhasset.Core.src.Generators
{
    public static class PropertyGenerators
    {
        public static PropertyDeclarationSyntax AddAttribute(this PropertyDeclarationSyntax me, string name)
        {
            var attributes = me.AttributeLists.Add(
                SyntaxFactory.AttributeList(SyntaxFactory.SingletonSeparatedList<AttributeSyntax>(
                    SyntaxFactory.Attribute(SyntaxFactory.IdentifierName(name))
                ))
            );

            return me.WithAttributeLists(attributes);
        }

        public static PropertyDeclarationSyntax AddEnumConverterAttribute(this PropertyDeclarationSyntax me)
        {
            return me.WithAttributeLists(
            SyntaxFactory.SingletonList<AttributeListSyntax>(
                SyntaxFactory.AttributeList(
                    SyntaxFactory.SingletonSeparatedList<AttributeSyntax>(
                        SyntaxFactory.Attribute(
                            SyntaxFactory.IdentifierName("JsonConverter"))
                        .WithArgumentList(
                            SyntaxFactory.AttributeArgumentList(
                                SyntaxFactory.SingletonSeparatedList<AttributeArgumentSyntax>(
                                    SyntaxFactory.AttributeArgument(
                                        SyntaxFactory.TypeOfExpression(
                                            SyntaxFactory.IdentifierName("StringEnumConverter"))))))))));
        }
    }
}