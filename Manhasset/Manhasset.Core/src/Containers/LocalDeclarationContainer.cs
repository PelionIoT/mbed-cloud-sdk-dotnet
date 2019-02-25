using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Manhasset.Core.src.Containers
{
    public class LocalDeclarationContainer : BaseContainer
    {
        public string VarType { get; set; }

        public virtual EqualsValueClauseSyntax GetInitalizerSyntax()
        {
            return SyntaxFactory.EqualsValueClause(
                                SyntaxFactory.DefaultExpression(
                                    SyntaxFactory.IdentifierName(VarType)
                                ));
        }

        public virtual LocalDeclarationStatementSyntax GetSyntax()
        {
            return SyntaxFactory.LocalDeclarationStatement(
                                        SyntaxFactory.VariableDeclaration(
                                            SyntaxFactory.IdentifierName("var"))
                                        .WithVariables(
                                            SyntaxFactory.SingletonSeparatedList<VariableDeclaratorSyntax>(
                                                SyntaxFactory.VariableDeclarator(
                                                    SyntaxFactory.Identifier(Name))
                                                .WithInitializer(
                                                    GetInitalizerSyntax()
                                                ))));
        }
    }
}