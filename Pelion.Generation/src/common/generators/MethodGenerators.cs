using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Pelion.Generation.src.common.generators
{
    public static class MethodGenerators
    {
        public static MethodDeclarationSyntax GenerateDebugDumpMethod()
        {
            return SyntaxFactory.MethodDeclaration(
                    SyntaxFactory.PredefinedType(
                        SyntaxFactory.Token(
                            SyntaxFactory.TriviaList(),
                            SyntaxKind.StringKeyword,
                            SyntaxFactory.TriviaList(
                                SyntaxFactory.Space))),
                    SyntaxFactory.Identifier("ToString"))
                .WithModifiers(
                    SyntaxFactory.TokenList(
                        new[]{
                            SyntaxFactory.Token(
                                SyntaxFactory.TriviaList(),
                                SyntaxKind.PublicKeyword,
                                SyntaxFactory.TriviaList(
                                    SyntaxFactory.Space)),
                            SyntaxFactory.Token(
                                SyntaxFactory.TriviaList(),
                                SyntaxKind.OverrideKeyword,
                                SyntaxFactory.TriviaList(
                                    SyntaxFactory.Space))}))
                .WithParameterList(
                    SyntaxFactory.ParameterList()
                    .WithCloseParenToken(
                        SyntaxFactory.Token(
                            SyntaxFactory.TriviaList(),
                            SyntaxKind.CloseParenToken,
                            SyntaxFactory.TriviaList(
                                SyntaxFactory.LineFeed))))
                .WithExpressionBody(
                    SyntaxFactory.ArrowExpressionClause(
                        SyntaxFactory.InvocationExpression(
                            SyntaxFactory.MemberAccessExpression(
                                SyntaxKind.SimpleMemberAccessExpression,
                                SyntaxFactory.ThisExpression(),
                                SyntaxFactory.IdentifierName("DebugDump"))))
                    .WithArrowToken(
                        SyntaxFactory.Token(
                            SyntaxFactory.TriviaList(
                                SyntaxFactory.Whitespace("    ")),
                            SyntaxKind.EqualsGreaterThanToken,
                            SyntaxFactory.TriviaList(
                                SyntaxFactory.Space))))
                .WithSemicolonToken(
                    SyntaxFactory.Token(SyntaxKind.SemicolonToken));
        }
    }
}