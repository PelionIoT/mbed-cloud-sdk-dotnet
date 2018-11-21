namespace Manhasset.Core.src.Generators
{
    using System;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    public static class FieldGenerators
    {
        public static FieldDeclarationSyntax CreateField(TypeSyntax type, string name, params SyntaxToken[] modifiers)
        {
            var variableDeclaration = SyntaxFactory.VariableDeclaration(type)
                                      .AddVariables(SyntaxFactory.VariableDeclarator(name));

            // use variable to create field private bool cancelled
            return SyntaxFactory.FieldDeclaration(variableDeclaration)
                                .AddModifiers(modifiers);
                                //.NormalizeWhitespace();
        }
    }
}