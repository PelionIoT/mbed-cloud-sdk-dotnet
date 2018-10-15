using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Manhasset.Generator.src.CustomContainers
{
    public class PaginatedMethodContainer : BaseMethodContainer
    {
        public override MethodDeclarationSyntax GetSyntax()
        {
            return SyntaxFactory.MethodDeclaration(
                    SyntaxFactory.GenericName(
                        SyntaxFactory.Identifier("PaginatedResponse"))
                    .WithTypeArgumentList(
                        SyntaxFactory.TypeArgumentList(
                            SyntaxFactory.SeparatedList<TypeSyntax>(
                                new SyntaxNodeOrToken[]{
                                    SyntaxFactory.IdentifierName("QueryOptions"),
                                    SyntaxFactory.Token(SyntaxKind.CommaToken),
                                    SyntaxFactory.IdentifierName(Returns)}))),
                    SyntaxFactory.Identifier(Name))
                .WithModifiers(
                    SyntaxFactory.TokenList(
                        SyntaxFactory.Token(SyntaxKind.PublicKeyword)))
                .WithBody(
                    SyntaxFactory.Block())
                .WithParameterList(MethodParams.GetSyntax());
        }
    }
}