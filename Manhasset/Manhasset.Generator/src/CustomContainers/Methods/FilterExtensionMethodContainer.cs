using Manhasset.Core.src.Containers;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Manhasset.Generator.src.CustomContainers.Methods
{
    public class FilterExtensionMethodContainer : MethodContainer
    {
        public string FilterKey { get; set; }
        public string FilterOperator { get; set; }
        public override MethodDeclarationSyntax GetSyntax()
        {
            var syntax = base.GetSyntax();
            return syntax.WithBody(SyntaxFactory.Block(
                        SyntaxFactory.ExpressionStatement(
                            SyntaxFactory.InvocationExpression(
                                SyntaxFactory.MemberAccessExpression(
                                    SyntaxKind.SimpleMemberAccessExpression,
                                    SyntaxFactory.MemberAccessExpression(
                                        SyntaxKind.SimpleMemberAccessExpression,
                                        SyntaxFactory.ThisExpression(),
                                        SyntaxFactory.IdentifierName("Filter")),
                                    SyntaxFactory.IdentifierName("AddFilterItem")))
                            .WithArgumentList(
                                SyntaxFactory.ArgumentList(
                                    SyntaxFactory.SeparatedList<ArgumentSyntax>(
                                        new SyntaxNodeOrToken[]{
                                            SyntaxFactory.Argument(
                                                SyntaxFactory.LiteralExpression(
                                                    SyntaxKind.StringLiteralExpression,
                                                    SyntaxFactory.Literal(FilterKey))),
                                            SyntaxFactory.Token(SyntaxKind.CommaToken),
                                            SyntaxFactory.Argument(
                                                SyntaxFactory.ObjectCreationExpression(
                                                    SyntaxFactory.IdentifierName("FilterItem"))
                                                .WithArgumentList(
                                                    SyntaxFactory.ArgumentList(
                                                        SyntaxFactory.SeparatedList<ArgumentSyntax>(
                                                            new SyntaxNodeOrToken[]{
                                                                SyntaxFactory.Argument(
                                                                    SyntaxFactory.IdentifierName("value")),
                                                                SyntaxFactory.Token(SyntaxKind.CommaToken),
                                                                SyntaxFactory.Argument(
                                                                    GetOperatorMember(FilterOperator)
                                                                )}))))})))),
                                                                        SyntaxFactory.ReturnStatement(
                                                                        SyntaxFactory.ThisExpression())));
        }

        private MemberAccessExpressionSyntax GetOperatorMember(string filterOperator)
        {

            switch (filterOperator)
            {
                case "eq":
                    return SyntaxFactory.MemberAccessExpression(
                            SyntaxKind.SimpleMemberAccessExpression,
                            SyntaxFactory.IdentifierName("FilterOperator"),
                            SyntaxFactory.IdentifierName("Equals"));
                case "neq":
                    return SyntaxFactory.MemberAccessExpression(
                            SyntaxKind.SimpleMemberAccessExpression,
                            SyntaxFactory.IdentifierName("FilterOperator"),
                            SyntaxFactory.IdentifierName("NotEqual"));
                case "gte":
                    return SyntaxFactory.MemberAccessExpression(
                            SyntaxKind.SimpleMemberAccessExpression,
                            SyntaxFactory.IdentifierName("FilterOperator"),
                            SyntaxFactory.IdentifierName("GreaterThan"));
                case "lte":
                    return SyntaxFactory.MemberAccessExpression(
                            SyntaxKind.SimpleMemberAccessExpression,
                            SyntaxFactory.IdentifierName("FilterOperator"),
                            SyntaxFactory.IdentifierName("LessThan"));
                case "in":
                    return SyntaxFactory.MemberAccessExpression(
                            SyntaxKind.SimpleMemberAccessExpression,
                            SyntaxFactory.IdentifierName("FilterOperator"),
                            SyntaxFactory.IdentifierName("In"));
                case "nin":
                    return SyntaxFactory.MemberAccessExpression(
                            SyntaxKind.SimpleMemberAccessExpression,
                            SyntaxFactory.IdentifierName("FilterOperator"),
                            SyntaxFactory.IdentifierName("NotIn"));
                case "like":
                    return SyntaxFactory.MemberAccessExpression(
                            SyntaxKind.SimpleMemberAccessExpression,
                            SyntaxFactory.IdentifierName("FilterOperator"),
                            SyntaxFactory.IdentifierName("Like"));
                default:
                    return SyntaxFactory.MemberAccessExpression(
                            SyntaxKind.SimpleMemberAccessExpression,
                            SyntaxFactory.IdentifierName("FilterOperator"),
                            SyntaxFactory.IdentifierName("Equals"));
            }
        }
    }
}