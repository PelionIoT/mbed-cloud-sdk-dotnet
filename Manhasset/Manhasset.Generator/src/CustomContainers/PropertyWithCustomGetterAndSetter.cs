using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Manhasset.Generator.src.CustomContainers
{
    public class PropertyWithCustomGetterAndSetter : PropertyWithSummaryContainer
    {
        public string CustomGetterName { get; set; }

        public string CustomSetterName { get; set; }

        public override AccessorDeclarationSyntax GetAccessorSyntax
        {
            get
            {
                var declaration = SyntaxFactory.AccessorDeclaration(
                        SyntaxKind.GetAccessorDeclaration);

                return IsInterface ? declaration.WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken)) : declaration.WithBody(
                                SyntaxFactory.Block(
                                    SyntaxFactory.SingletonList<StatementSyntax>(
                                        SyntaxFactory.ReturnStatement(
                                            SyntaxFactory.InvocationExpression(
                                                SyntaxFactory.MemberAccessExpression(
                                                SyntaxKind.SimpleMemberAccessExpression,
                                                SyntaxFactory.IdentifierName("CustomFunctions"),
                                                SyntaxFactory.IdentifierName(CustomGetterName))
                                            )
                                            .WithArgumentList(
                                                SyntaxFactory.ArgumentList(
                                                    SyntaxFactory.SingletonSeparatedList<ArgumentSyntax>(
                                                        SyntaxFactory.Argument(
                                                            SyntaxFactory.ThisExpression()))))))));
            }
        }

        public override AccessorDeclarationSyntax SetAccessorSyntax
        {
            get
            {
                var declaration = SyntaxFactory.AccessorDeclaration(
                        SyntaxKind.SetAccessorDeclaration);

                return IsInterface ? declaration.WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken)) : declaration.WithBody(
                        SyntaxFactory.Block(
                            SyntaxFactory.SingletonList<StatementSyntax>(
                                SyntaxFactory.ExpressionStatement(
                                    SyntaxFactory.InvocationExpression(
                                        SyntaxFactory.MemberAccessExpression(
                                                SyntaxKind.SimpleMemberAccessExpression,
                                                SyntaxFactory.IdentifierName("CustomFunctions"),
                                                SyntaxFactory.IdentifierName(CustomSetterName)))
                                    .WithArgumentList(
                                        SyntaxFactory.ArgumentList(
                                            SyntaxFactory.SeparatedList<ArgumentSyntax>(
                                                new SyntaxNodeOrToken[]{
                                                    SyntaxFactory.Argument(
                                                        SyntaxFactory.ThisExpression()),
                                                    SyntaxFactory.Token(SyntaxKind.CommaToken),
                                                    SyntaxFactory.Argument(
                                                        SyntaxFactory.IdentifierName("value"))})))))));
            }
        }

        public override PropertyDeclarationSyntax GetSyntax()
        {
            return base.GetSyntax();
        }
    }
}