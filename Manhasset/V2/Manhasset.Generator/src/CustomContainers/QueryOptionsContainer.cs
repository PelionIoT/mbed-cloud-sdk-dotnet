using Manhasset.Core.src.Containers;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Manhasset.Generator.src.CustomContainers
{
    public class QueryOptionsContainer : LocalDeclarationContainer
    {
        public override EqualsValueClauseSyntax GetInitalizerSyntax()
        {
            return SyntaxFactory.EqualsValueClause(
                SyntaxFactory.ObjectCreationExpression(
                    SyntaxFactory.IdentifierName("QueryOptions"))
                .WithInitializer(
                    SyntaxFactory.InitializerExpression(
                        SyntaxKind.ObjectInitializerExpression,
                        SyntaxFactory.SeparatedList<ExpressionSyntax>(
                            new SyntaxNodeOrToken[]{
                                SyntaxFactory.AssignmentExpression(
                                    SyntaxKind.SimpleAssignmentExpression,
                                    SyntaxFactory.IdentifierName("After"),
                                    SyntaxFactory.IdentifierName("after")),
                                SyntaxFactory.Token(SyntaxKind.CommaToken),
                                SyntaxFactory.AssignmentExpression(
                                    SyntaxKind.SimpleAssignmentExpression,
                                    SyntaxFactory.IdentifierName("Include"),
                                    SyntaxFactory.IdentifierName("include")),
                                SyntaxFactory.Token(SyntaxKind.CommaToken),
                                SyntaxFactory.AssignmentExpression(
                                    SyntaxKind.SimpleAssignmentExpression,
                                    SyntaxFactory.IdentifierName("Limit"),
                                    SyntaxFactory.IdentifierName("limit")),
                                SyntaxFactory.Token(SyntaxKind.CommaToken),
                                SyntaxFactory.AssignmentExpression(
                                    SyntaxKind.SimpleAssignmentExpression,
                                    SyntaxFactory.IdentifierName("Order"),
                                    SyntaxFactory.IdentifierName("order")),
                                SyntaxFactory.Token(SyntaxKind.CommaToken)}))));
        }
    }
}