using Manhasset.Core.src.Containers;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Manhasset.Generator.src.CustomContainers
{
    public class PaginatedResponseReturnStatementContainer : ReturnStatementContainer
    {
        public string Returns { get; set; }
        public string ListOptionsName { get; set; }
        public override StatementSyntax GetSyntax()
        {
            return SyntaxFactory.ReturnStatement(
                SyntaxFactory.ObjectCreationExpression(
                    SyntaxFactory.GenericName(
                        SyntaxFactory.Identifier("PaginatedResponse"))
                    .WithTypeArgumentList(
                        SyntaxFactory.TypeArgumentList(
                            SyntaxFactory.SeparatedList<TypeSyntax>(
                                new SyntaxNodeOrToken[]{
                                    SyntaxFactory.IdentifierName(ListOptionsName),
                                    SyntaxFactory.Token(SyntaxKind.CommaToken),
                                    SyntaxFactory.IdentifierName(Returns)}))))
                .WithArgumentList(
                    SyntaxFactory.ArgumentList(
                        SyntaxFactory.SeparatedList<ArgumentSyntax>(
                            new SyntaxNodeOrToken[]{
                                SyntaxFactory.Argument(
                                    SyntaxFactory.IdentifierName("paginatedFunc")),
                                SyntaxFactory.Token(SyntaxKind.CommaToken),
                                SyntaxFactory.Argument(
                                    SyntaxFactory.IdentifierName("options"))}))));
        }
    }
}