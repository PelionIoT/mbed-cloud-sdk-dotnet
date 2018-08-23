namespace Pelion.Generation.src.common.generators
{
    using System;
    using System.Collections.Generic;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    public static class PropertyGenerators
    {
        public static PropertyDeclarationSyntax CreateProperty(TypeSyntax type, string name, SyntaxToken setModifier = default(SyntaxToken))
        {
            var getAccessor = SyntaxFactory.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration)
                                           .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken));

            var setAccessor = SyntaxFactory.AccessorDeclaration(SyntaxKind.SetAccessorDeclaration)
                                           .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken));

            if (setModifier != default(SyntaxToken))
            {
                setAccessor = setAccessor.AddModifiers(setModifier);
            }

            return SyntaxFactory.PropertyDeclaration(type, name)
                                .AddModifiers(Modifiers.PublicMod)
                                .AddAccessorListAccessors(getAccessor, setAccessor);
                                //.NormalizeWhitespace();
        }

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
            //.NormalizeWhitespace();
        }

        // public static PropertyDeclarationSyntax AddSummary(this PropertyDeclarationSyntax me, string summary)
        // {
        //     var documentation = DocumentationGenerators.GenerateSummary(summary);

        //     return me.InsertTriviaBefore(me.GetLeadingTrivia().First(),  SyntaxFactory.TriviaList(SyntaxFactory.Trivia(documentation)));
        // }
    }
}