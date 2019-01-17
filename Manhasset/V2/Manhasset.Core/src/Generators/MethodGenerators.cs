using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Manhasset.Core.src.Generators
{
    public static class MethodGenerators
    {
        public static TryStatementSyntax GetTryCatchBlock()
        {
            return SyntaxFactory.TryStatement(
                    SyntaxFactory.SingletonList<CatchClauseSyntax>(
                        SyntaxFactory.CatchClause()
                        .WithDeclaration(
                            SyntaxFactory.CatchDeclaration(
                                SyntaxFactory.IdentifierName("ApiException"))
                            .WithIdentifier(
                                SyntaxFactory.Identifier("e")))
                        .WithBlock(
                            SyntaxFactory.Block(
                                SyntaxFactory.SingletonList<StatementSyntax>(
                                    SyntaxFactory.ThrowStatement(
                                        SyntaxFactory.ObjectCreationExpression(
                                            SyntaxFactory.IdentifierName("CloudApiException"))
                                        .WithArgumentList(
                                            SyntaxFactory.ArgumentList(
                                                SyntaxFactory.SeparatedList<ArgumentSyntax>(
                                                    new SyntaxNodeOrToken[]{
                                                        SyntaxFactory.Argument(
                                                            SyntaxFactory.MemberAccessExpression(
                                                                SyntaxKind.SimpleMemberAccessExpression,
                                                                SyntaxFactory.IdentifierName("e"),
                                                                SyntaxFactory.IdentifierName("ErrorCode"))),
                                                        SyntaxFactory.Token(SyntaxKind.CommaToken),
                                                        SyntaxFactory.Argument(
                                                            SyntaxFactory.MemberAccessExpression(
                                                                SyntaxKind.SimpleMemberAccessExpression,
                                                                SyntaxFactory.IdentifierName("e"),
                                                                SyntaxFactory.IdentifierName("Message"))),
                                                        SyntaxFactory.Token(SyntaxKind.CommaToken),
                                                        SyntaxFactory.Argument(
                                                            SyntaxFactory.MemberAccessExpression(
                                                                SyntaxKind.SimpleMemberAccessExpression,
                                                                SyntaxFactory.IdentifierName("e"),
                                                                SyntaxFactory.IdentifierName("ErrorContent")))})))))))));
        }
    }
}