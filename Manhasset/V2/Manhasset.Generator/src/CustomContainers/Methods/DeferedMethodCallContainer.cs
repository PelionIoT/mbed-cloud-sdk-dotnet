using System.Collections.Generic;
using Manhasset.Core.src.Extensions;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Manhasset.Generator.src.CustomContainers
{
    public class DeferedMethodCallContainer : BaseMethodContainer
    {
        public string Method { get; set; }

        public string Field { get; set; }

        public Dictionary<string, string> Assignments { get; set; } = new Dictionary<string, string>();

        public void AddAsignment(string externalKey, string selfKey)
        {
            Assignments.SafeAdd<string, string>(externalKey, selfKey);
        }

        public override MethodDeclarationSyntax GetSyntax()
        {
            var syntax = base.GetSyntax();

            var methodBody = new List<StatementSyntax>();

            foreach (var item in Assignments)
            {
                methodBody.Add(
                    SyntaxFactory.ExpressionStatement(
                            SyntaxFactory.AssignmentExpression(
                                SyntaxKind.SimpleAssignmentExpression,
                                SyntaxFactory.MemberAccessExpression(
                                    SyntaxKind.SimpleMemberAccessExpression,
                                    SyntaxFactory.IdentifierName(Field),
                                    SyntaxFactory.IdentifierName(item.Key)),
                                SyntaxFactory.IdentifierName(item.Value))));
            }

            // return entity method call
            var deferedMethodCallReturnStatementContainer = new DeferedMethodCallReturnStatementContainer
            {
                MethodName = Method,
                DeferedEntity = Field,
            }.GetSyntax();

            methodBody.Add(deferedMethodCallReturnStatementContainer);

            return syntax.WithBody(SyntaxFactory.Block(methodBody.ToArray()));
        }
    }
}