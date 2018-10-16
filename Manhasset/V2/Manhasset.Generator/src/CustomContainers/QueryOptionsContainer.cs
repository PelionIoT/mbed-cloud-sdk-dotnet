using System.Collections.Generic;
using System.Linq;
using Manhasset.Core.src.Containers;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Manhasset.Generator.src.CustomContainers
{
    public class QueryOptionsContainer : LocalDeclarationContainer
    {
        public MethodParameterContainer MethodParams { get; internal set; }

        public override EqualsValueClauseSyntax GetInitalizerSyntax()
        {
            var paramList = new List<SyntaxNodeOrToken>();

            if (MethodParams.Parameters.FirstOrDefault(f => f.Key == "after") != null)
            {
                paramList.Add(
                    SyntaxFactory.AssignmentExpression(
                        SyntaxKind.SimpleAssignmentExpression,
                        SyntaxFactory.IdentifierName("After"),
                        SyntaxFactory.IdentifierName("after"))
                );
                paramList.Add(SyntaxFactory.Token(SyntaxKind.CommaToken));
            }

            if (MethodParams.Parameters.FirstOrDefault(f => f.Key == "include") != null)
            {
                paramList.Add(
                    SyntaxFactory.AssignmentExpression(
                        SyntaxKind.SimpleAssignmentExpression,
                        SyntaxFactory.IdentifierName("Include"),
                        SyntaxFactory.IdentifierName("include"))
                );
                paramList.Add(SyntaxFactory.Token(SyntaxKind.CommaToken));
            }

            if (MethodParams.Parameters.FirstOrDefault(f => f.Key == "limit") != null)
            {
                paramList.Add(
                    SyntaxFactory.AssignmentExpression(
                        SyntaxKind.SimpleAssignmentExpression,
                        SyntaxFactory.IdentifierName("Limit"),
                        SyntaxFactory.IdentifierName("limit"))
                );
                paramList.Add(SyntaxFactory.Token(SyntaxKind.CommaToken));
            }

            if (MethodParams.Parameters.FirstOrDefault(f => f.Key == "order") != null)
            {
                paramList.Add(
                    SyntaxFactory.AssignmentExpression(
                        SyntaxKind.SimpleAssignmentExpression,
                        SyntaxFactory.IdentifierName("Order"),
                        SyntaxFactory.IdentifierName("order"))
                );
                paramList.Add(SyntaxFactory.Token(SyntaxKind.CommaToken));
            }

            return SyntaxFactory.EqualsValueClause(
                SyntaxFactory.ObjectCreationExpression(
                    SyntaxFactory.IdentifierName("QueryOptions"))
                .WithInitializer(
                    SyntaxFactory.InitializerExpression(
                        SyntaxKind.ObjectInitializerExpression,
                        SyntaxFactory.SeparatedList<ExpressionSyntax>(
                            paramList.ToArray()
                        ))));
        }
    }
}