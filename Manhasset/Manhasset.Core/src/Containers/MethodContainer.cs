using System;
using System.Collections.Generic;
using System.Linq;
using Manhasset.Core.src.Common;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Manhasset.Core.src.Containers
{
    public class MethodContainer : BaseContainer
    {
        public string Returns { get; set; }

        public MethodParameterContainer MethodParams { get; set; } = new MethodParameterContainer();

        public bool IsAsync { get; set; } = false;

        public bool IsVoidTask { get; set; } = false;

        public virtual MethodDeclarationSyntax GetSyntax()
        {
            MethodDeclarationSyntax method = null;
            if (IsAsync)
            {
                // if method is async and not an interface, add the async modifier to end of modifiers list
                IEnumerable<SyntaxToken> modifiers = MyModifiers.Values.ToArray();
                if (!IsInterface)
                {
                    modifiers = modifiers.Concat(new[] { Modifiers.ASYNC });
                }

                if (IsVoidTask)
                {
                    method = SyntaxFactory.MethodDeclaration(
                    SyntaxFactory.IdentifierName("Task"),
                    SyntaxFactory.Identifier(Name))
                        .AddModifiers(modifiers.ToArray())
                        .WithParameterList(MethodParams.GetSyntax());
                }
                else
                {
                    // if async, wrap the return type in task
                    method = SyntaxFactory.MethodDeclaration(
                        SyntaxFactory.GenericName(
                            SyntaxFactory.Identifier("Task"))
                        .WithTypeArgumentList(
                            SyntaxFactory.TypeArgumentList(
                                SyntaxFactory.SingletonSeparatedList<TypeSyntax>(
                                    SyntaxFactory.IdentifierName(Returns)))),
                        SyntaxFactory.Identifier(Name)
                    ).AddModifiers(modifiers.ToArray())
                     .WithParameterList(MethodParams.GetSyntax());
                }
            }
            else
            {
                method = SyntaxFactory.MethodDeclaration(SyntaxFactory.IdentifierName(Returns), SyntaxFactory.Identifier(Name))
                                    .AddModifiers(MyModifiers.Values.ToArray())
                                    .WithParameterList(MethodParams.GetSyntax());
            }

            // if method is on an interface, don't return an empty method body
            return IsInterface ? method.WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken)) : method.WithBody(SyntaxFactory.Block());
        }
    }
}