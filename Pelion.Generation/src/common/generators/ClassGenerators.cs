namespace Pelion.Generation.src.common.generators
{
    using System;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    public static class ClassGenerators
    {
        public static ClassDeclarationSyntax CreateClass(string name, params SyntaxToken[] modifiers)
        {
            return SyntaxFactory.ClassDeclaration(name)
                                .AddModifiers(modifiers)
                                .NormalizeWhitespace();
        }

        public static ClassDeclarationSyntax AddBaseTypes(this ClassDeclarationSyntax me, params SimpleBaseTypeSyntax[] baseTypes)
        {
            return me.AddBaseListTypes(baseTypes)
                     .NormalizeWhitespace();
        }

        public static ClassDeclarationSyntax AddField(this ClassDeclarationSyntax me, FieldDeclarationSyntax field)
        {
            return me.AddMembers(field)
                     .NormalizeWhitespace();
        }
        public static ClassDeclarationSyntax AddField(this ClassDeclarationSyntax me, TypeSyntax type, string name, params SyntaxToken[] modifiers)
        {
            var field = FieldGenerators.CreateField(type, name, modifiers);
            return me.AddMembers(field)
                     .NormalizeWhitespace();
        }

        public static ClassDeclarationSyntax AddProperty(this ClassDeclarationSyntax me, PropertyDeclarationSyntax property)
        {
            return me.AddMembers(property)
                     .NormalizeWhitespace();
        }

        public static ClassDeclarationSyntax AddProperty(this ClassDeclarationSyntax me, TypeSyntax type, string name, SyntaxToken setModifier = default(SyntaxToken))
        {
            var property = PropertyGenerators.CreateProperty(type, name, setModifier);
            return me.AddMembers(property)
                     .NormalizeWhitespace();
        }

        public static ClassDeclarationSyntax AddMethod(this ClassDeclarationSyntax me, MethodDeclarationSyntax method)
        {
            return me.AddMembers(method)
                     .NormalizeWhitespace();
        }

        // public static ClassDeclarationSyntax AddSummary(this ClassDeclarationSyntax me, string summary)
        // {
        //     var documentation = DocumentationGenerators.GenerateSummary(summary);

        //     return me.InsertTriviaBefore(me.GetLeadingTrivia().First(), SyntaxFactory.TriviaList(SyntaxFactory.Trivia(documentation)));
        // }
    }
}