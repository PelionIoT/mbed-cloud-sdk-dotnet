using System.Linq;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Manhasset.Core.src.Containers
{
    public class MethodContainer : BaseContainer
    {
        public string Returns { get; set; }

        public MethodParameterContainer MethodParams { get; set; }

        public bool IsAsync { get; set; }

        public bool IsVoidTask { get; set; }

        public virtual MethodDeclarationSyntax GetSyntax()
        {
            if (IsAsync)
            {
                if (IsVoidTask)
                {
                    return SyntaxFactory.MethodDeclaration(
                    SyntaxFactory.IdentifierName("Task"),
                    SyntaxFactory.Identifier(Name))
                        .AddModifiers(MyModifiers.Values.ToArray())
                        .AddModifiers(SyntaxFactory.Token(SyntaxKind.AsyncKeyword))
                        .WithParameterList(MethodParams.GetSyntax())
                        .WithBody(SyntaxFactory.Block());
                }
                // if async, wrap the return type in task
                return SyntaxFactory.MethodDeclaration(
                    SyntaxFactory.GenericName(
                        SyntaxFactory.Identifier("Task"))
                    .WithTypeArgumentList(
                        SyntaxFactory.TypeArgumentList(
                            SyntaxFactory.SingletonSeparatedList<TypeSyntax>(
                                SyntaxFactory.IdentifierName(Returns)))),
                    SyntaxFactory.Identifier(Name)
                ).AddModifiers(MyModifiers.Values.ToArray())
                 .AddModifiers(SyntaxFactory.Token(SyntaxKind.AsyncKeyword))
                 .WithParameterList(MethodParams.GetSyntax())
                 .WithBody(SyntaxFactory.Block());
            }

            return SyntaxFactory.MethodDeclaration(SyntaxFactory.IdentifierName(Returns), SyntaxFactory.Identifier(Name))
                                .AddModifiers(MyModifiers.Values.ToArray())
                                .WithParameterList(MethodParams.GetSyntax())
                                .WithBody(SyntaxFactory.Block());
        }
    }
}