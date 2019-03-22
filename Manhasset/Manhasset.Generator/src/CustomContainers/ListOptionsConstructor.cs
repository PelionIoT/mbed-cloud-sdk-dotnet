using Manhasset.Core.src.Containers;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Manhasset.Generator.src.CustomContainers
{
    public class ListOptionsConstructor : ConstructorContainer
    {
        public override ConstructorDeclarationSyntax GetSyntax()
        {
            var syntax = base.GetSyntax();
            syntax = syntax.WithBody(SyntaxFactory.Block(
                        SyntaxFactory.SingletonList<StatementSyntax>(
                            SyntaxFactory.ExpressionStatement(
                                SyntaxFactory.AssignmentExpression(
                                    SyntaxKind.SimpleAssignmentExpression,
                                    SyntaxFactory.IdentifierName("Filter"),
                                    SyntaxFactory.ObjectCreationExpression(
                                        SyntaxFactory.IdentifierName("Filter"))
                                    .WithArgumentList(
                                        SyntaxFactory.ArgumentList()))))));
            return syntax;
        }
    }
}