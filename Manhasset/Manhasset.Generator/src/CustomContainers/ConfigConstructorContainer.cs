using Manhasset.Core.src.Containers;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Manhasset.Generator.src.CustomContainers
{
    public class ConfigConstructorContainer : ConstructorContainer
    {
        public override ConstructorDeclarationSyntax GetSyntax()
        {
            return SyntaxFactory.ConstructorDeclaration(
                    SyntaxFactory.Identifier(Name))
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
                        SyntaxFactory.ExpressionStatement(
                            SyntaxFactory.AssignmentExpression(
                                SyntaxKind.SimpleAssignmentExpression,
                                SyntaxFactory.IdentifierName("Config"),
                                SyntaxFactory.IdentifierName("config"))),
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
                                                SyntaxFactory.IdentifierName("Config")))))))));
        }
    }
}