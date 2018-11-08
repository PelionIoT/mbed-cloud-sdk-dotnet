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
                .WithParameterList(
                    SyntaxFactory.ParameterList(
                        SyntaxFactory.SingletonSeparatedList<ParameterSyntax>(
                            SyntaxFactory.Parameter(
                                SyntaxFactory.Identifier("config"))
                            .WithType(
                                SyntaxFactory.IdentifierName("Config")))))
                .WithInitializer(
                    SyntaxFactory.ConstructorInitializer(
                        SyntaxKind.BaseConstructorInitializer,
                        SyntaxFactory.ArgumentList(
                            SyntaxFactory.SingletonSeparatedList<ArgumentSyntax>(
                                SyntaxFactory.Argument(
                                    SyntaxFactory.IdentifierName("config"))))))
                .WithBody(
                    SyntaxFactory.Block());
        }
    }
}