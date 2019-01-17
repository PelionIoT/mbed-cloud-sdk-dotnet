using Manhasset.Core.src.Containers;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Manhasset.Generator.src.CustomContainers
{
    public class EntityFactoryMethodContainer : MethodContainer
    {
        public override MethodDeclarationSyntax GetSyntax()
        {
            return base.GetSyntax().WithBody(SyntaxFactory.Block(
        SyntaxFactory.SingletonList<StatementSyntax>(
            SyntaxFactory.ReturnStatement(
                SyntaxFactory.ObjectCreationExpression(
                    SyntaxFactory.IdentifierName(Name))
                .WithArgumentList(
                    SyntaxFactory.ArgumentList(
                        SyntaxFactory.SeparatedList<ArgumentSyntax>(
                            new SyntaxNodeOrToken[]{
                                SyntaxFactory.Argument(
                                    SyntaxFactory.IdentifierName("config")),
                                SyntaxFactory.Token(SyntaxKind.CommaToken),
                                SyntaxFactory.Argument(
                                    SyntaxFactory.IdentifierName("client"))})))))));
        }
    }
}