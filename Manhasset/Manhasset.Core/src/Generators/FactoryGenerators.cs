using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Manhasset.Core.src.Generators
{
    public static class FactoryGenerators
    {
        public static MethodDeclarationSyntax GenerateEntityFactory(string name)
        {
            return SyntaxFactory.MethodDeclaration(
                        SyntaxFactory.IdentifierName(name),
                        SyntaxFactory.Identifier(name))
                    .WithModifiers(
                        SyntaxFactory.TokenList(
                            SyntaxFactory.Token(SyntaxKind.PublicKeyword)))
                    .WithExpressionBody(
                        SyntaxFactory.ArrowExpressionClause(
                            SyntaxFactory.ObjectCreationExpression(
                                SyntaxFactory.IdentifierName(name))
                            .WithArgumentList(
                                SyntaxFactory.ArgumentList(
                                    SyntaxFactory.SingletonSeparatedList<ArgumentSyntax>(
                                        SyntaxFactory.Argument(
                                            SyntaxFactory.BinaryExpression(
                                                SyntaxKind.CoalesceExpression,
                                                SyntaxFactory.IdentifierName("instanceConfig"),
                                                SyntaxFactory.IdentifierName("Config"))))))))
                    .WithSemicolonToken(
                        SyntaxFactory.Token(SyntaxKind.SemicolonToken));
        }
    }
}