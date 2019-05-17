using Manhasset.Core.src.Containers;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Manhasset.Generator.src.CustomContainers
{
    public class QueryOptionsNullCheckContainer : BaseContainer
    {
        public string ListOptionsName { get; set; }
        public virtual IfStatementSyntax GetSyntax()
        {
            return SyntaxFactory.IfStatement(
                SyntaxFactory.BinaryExpression(
                    SyntaxKind.EqualsExpression,
                    SyntaxFactory.IdentifierName("options"),
                    SyntaxFactory.LiteralExpression(
                        SyntaxKind.NullLiteralExpression)),
                SyntaxFactory.Block(
                    SyntaxFactory.SingletonList<StatementSyntax>(
                        SyntaxFactory.ExpressionStatement(
                            SyntaxFactory.AssignmentExpression(
                                SyntaxKind.SimpleAssignmentExpression,
                                SyntaxFactory.IdentifierName("options"),
                                SyntaxFactory.ObjectCreationExpression(
                                    SyntaxFactory.IdentifierName(ListOptionsName))
                                .WithArgumentList(
                                    SyntaxFactory.ArgumentList()))))));
        }
    }
}