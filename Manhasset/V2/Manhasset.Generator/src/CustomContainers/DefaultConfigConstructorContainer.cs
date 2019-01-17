using Manhasset.Core.src.Containers;
using Microsoft.CodeAnalysis;
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
                .WithParameterList(
                    SyntaxFactory.ParameterList(
                        SyntaxFactory.SeparatedList<ParameterSyntax>(
                            new SyntaxNodeOrToken[]{
                                SyntaxFactory.Parameter(
                                    SyntaxFactory.Identifier("config"))
                                .WithType(
                                    SyntaxFactory.IdentifierName("Config")),
                                SyntaxFactory.Token(SyntaxKind.CommaToken),
                                SyntaxFactory.Parameter(
                                    SyntaxFactory.Identifier("client"))
                                .WithType(
                                    SyntaxFactory.IdentifierName("Client"))
                                .WithDefault(
                                    SyntaxFactory.EqualsValueClause(
                                        SyntaxFactory.LiteralExpression(
                                            SyntaxKind.NullLiteralExpression)))})))
                .WithInitializer(
                    SyntaxFactory.ConstructorInitializer(
                        SyntaxKind.BaseConstructorInitializer,
                        SyntaxFactory.ArgumentList(
                            SyntaxFactory.SeparatedList<ArgumentSyntax>(
                                new SyntaxNodeOrToken[]{
                                    SyntaxFactory.Argument(
                                        SyntaxFactory.IdentifierName("config")),
                                    SyntaxFactory.Token(SyntaxKind.CommaToken),
                                    SyntaxFactory.Argument(
                                        SyntaxFactory.IdentifierName("client"))}))))
                .WithBody(
                    SyntaxFactory.Block());
        }
    }
}