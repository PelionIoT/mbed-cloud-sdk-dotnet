using System.Collections.Generic;
using System.Linq;
using Manhasset.Core.src.Containers;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Manhasset.Generator.src.CustomContainers
{
    public class CustomFunctionReturnStatementContainer : ReturnStatementContainer
    {
        public string CustomFunctionName { get; set; }
        public List<ParameterContainer> MethodParams { get; set; }
        public override StatementSyntax GetSyntax()
        {
            var paramList = new List<SyntaxNodeOrToken>();

            paramList.Add(SyntaxFactory.Argument(SyntaxFactory.ThisExpression()));
            paramList.Add(SyntaxFactory.Token(SyntaxKind.CommaToken));

            MethodParams.Select(m =>
            {
                return SyntaxFactory.Argument(
                    SyntaxFactory.IdentifierName(m.Key)
                );
            })
            .ToList()
            .ForEach(m =>
            {
                paramList.Add(m);
                paramList.Add(SyntaxFactory.Token(SyntaxKind.CommaToken));
            });

            if (paramList.Any())
            {
                paramList.RemoveAt(paramList.Count - 1);
            }

            return SyntaxFactory.ReturnStatement(
                SyntaxFactory.AwaitExpression(
                    SyntaxFactory.InvocationExpression(
                        SyntaxFactory.MemberAccessExpression(
                            SyntaxKind.SimpleMemberAccessExpression,
                            SyntaxFactory.IdentifierName("CustomFunctions"),
                            SyntaxFactory.IdentifierName(CustomFunctionName)))
                    .WithArgumentList(
                        SyntaxFactory.ArgumentList(
                            SyntaxFactory.SeparatedList<ArgumentSyntax>(
                                paramList.ToArray()
                    )))));
        }
    }
}