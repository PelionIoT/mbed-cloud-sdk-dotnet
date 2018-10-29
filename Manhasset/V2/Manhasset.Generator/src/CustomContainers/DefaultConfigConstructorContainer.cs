using Manhasset.Core.src.Containers;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Manhasset.Generator.src.CustomContainers
{
    public class DefaultConfigConstructorContainer : ConstructorContainer
    {
        public override ConstructorDeclarationSyntax GetSyntax()
        {
            return SyntaxFactory.ConstructorDeclaration(
                    SyntaxFactory.Identifier(Name))
                .WithModifiers(
                    SyntaxFactory.TokenList(
                        SyntaxFactory.Token(SyntaxKind.PublicKeyword)))
                .WithBody(
                    SyntaxFactory.Block(
                        SyntaxFactory.SingletonList<StatementSyntax>(
                            SyntaxFactory.ExpressionStatement(
                                SyntaxFactory.AssignmentExpression(
                                    SyntaxKind.SimpleAssignmentExpression,
                                    SyntaxFactory.IdentifierName("Client"),
                                    SyntaxFactory.ObjectCreationExpression(
                                        SyntaxFactory.IdentifierName("Client"))
                                    .WithArgumentList(
                                        SyntaxFactory.ArgumentList(
                                            SyntaxFactory.SingletonSeparatedList<ArgumentSyntax>(
                                                SyntaxFactory.Argument(
                                                    SyntaxFactory.IdentifierName("Config"))))))))));
        }
    }
}