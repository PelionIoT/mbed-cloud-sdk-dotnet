using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Manhasset.Core.src.Generators
{
    public static class ConstructorGenerators
    {
        public static SyntaxList<MemberDeclarationSyntax> GenerateConstructors(string className)
        {
            return SyntaxFactory.List<MemberDeclarationSyntax>(
                new MemberDeclarationSyntax[]{
                    SyntaxFactory.ConstructorDeclaration(
                        SyntaxFactory.Identifier(className))
                    .WithModifiers(
                        SyntaxFactory.TokenList(
                            SyntaxFactory.Token(SyntaxKind.PublicKeyword)))
                    .WithBody(
                        SyntaxFactory.Block()),
                    SyntaxFactory.ConstructorDeclaration(
                        SyntaxFactory.Identifier(className))
                    .WithModifiers(
                        SyntaxFactory.TokenList(
                            SyntaxFactory.Token(SyntaxKind.PublicKeyword)))
                    .WithParameterList(
                        SyntaxFactory.ParameterList(
                            SyntaxFactory.SingletonSeparatedList<ParameterSyntax>(
                                SyntaxFactory.Parameter(
                                    SyntaxFactory.Identifier("config"))
                                .WithType(
                                    SyntaxFactory.IdentifierName("Config")))))
                    .WithBody(
                        SyntaxFactory.Block(
                            SyntaxFactory.SingletonList<StatementSyntax>(
                                SyntaxFactory.ExpressionStatement(
                                    SyntaxFactory.AssignmentExpression(
                                        SyntaxKind.SimpleAssignmentExpression,
                                        SyntaxFactory.IdentifierName("Config"),
                                        SyntaxFactory.IdentifierName("config"))))))});
        }
    }
}