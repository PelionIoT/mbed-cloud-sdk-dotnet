using System.Collections.Generic;
using System.Linq;
using Manhasset.Core.src.Containers;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Manhasset.Generator.src.CustomContainers
{
    public class BodyParameterContainer : BaseContainer
    {
        public string BodyType { get; set; }
        public List<MyParameterContainer> BodyParams { get; set; }

        public virtual LocalDeclarationStatementSyntax GetSyntax()
        {
            if (BodyParams.FirstOrDefault()?.ReplaceBody == true)
            {
                // this is a replace body
                return SyntaxFactory.LocalDeclarationStatement(
                        SyntaxFactory.VariableDeclaration(
                            SyntaxFactory.IdentifierName("var"))
                        .WithVariables(
                            SyntaxFactory.SingletonSeparatedList<VariableDeclaratorSyntax>(
                                SyntaxFactory.VariableDeclarator(
                                    SyntaxFactory.Identifier(Name))
                                .WithInitializer(
                                    SyntaxFactory.EqualsValueClause(
                                        SyntaxFactory.IdentifierName(BodyParams.FirstOrDefault()?.Key))))));
            }

            ExpressionSyntax objectCreation;

            if (BodyType == "Annonymous")
            {
                var anonPropList = new List<SyntaxNodeOrToken>();

                BodyParams.Select(b =>
                {
                    return b.CallContext != null ?
                    SyntaxFactory.AnonymousObjectMemberDeclarator(
                        SyntaxFactory.MemberAccessExpression(
                            SyntaxKind.SimpleMemberAccessExpression,
                            SyntaxFactory.IdentifierName(b.CallContext),
                            SyntaxFactory.IdentifierName(b.Key)))
                        .WithNameEquals(
                            SyntaxFactory.NameEquals(
                                SyntaxFactory.IdentifierName(b.Key)))
                    :
                    SyntaxFactory.AnonymousObjectMemberDeclarator(
                        SyntaxFactory.IdentifierName(b.Key))
                    .WithNameEquals(
                        SyntaxFactory.NameEquals(
                            SyntaxFactory.IdentifierName(b.Key)));
                })
                .ToList()
                .ForEach(b =>
                {
                    anonPropList.Add(b);
                    anonPropList.Add(SyntaxFactory.Token(SyntaxKind.CommaToken));
                });

                objectCreation = SyntaxFactory.AnonymousObjectCreationExpression(
                        SyntaxFactory.SeparatedList<AnonymousObjectMemberDeclaratorSyntax>(
                            anonPropList.ToArray()
                        ));
            }
            else
            {
                var propList = new List<SyntaxNodeOrToken>();

                BodyParams.Select(b =>
                {
                    return b.CallContext != null ?
                    SyntaxFactory.AssignmentExpression(
                    SyntaxKind.SimpleAssignmentExpression,
                    SyntaxFactory.IdentifierName(b.Key),
                    SyntaxFactory.MemberAccessExpression(
                        SyntaxKind.SimpleMemberAccessExpression,
                        SyntaxFactory.IdentifierName(b.CallContext),
                        SyntaxFactory.IdentifierName(b.Key)
                    ))
                    :
                    SyntaxFactory.AssignmentExpression(
                    SyntaxKind.SimpleAssignmentExpression,
                    SyntaxFactory.IdentifierName(b.Key),
                    SyntaxFactory.IdentifierName(b.Key));
                })
                .ToList()
                .ForEach(b =>
                {
                    propList.Add(b);
                    propList.Add(SyntaxFactory.Token(SyntaxKind.CommaToken));
                });

                objectCreation = SyntaxFactory.ObjectCreationExpression(
                    SyntaxFactory.IdentifierName(BodyType))
                .WithInitializer(
                    SyntaxFactory.InitializerExpression(
                        SyntaxKind.ObjectInitializerExpression,
                        SyntaxFactory.SeparatedList<ExpressionSyntax>(
                            propList.ToArray()
                        )));
            }

            return SyntaxFactory.LocalDeclarationStatement(
                SyntaxFactory.VariableDeclaration(
                    SyntaxFactory.IdentifierName("var"))
                .WithVariables(
                    SyntaxFactory.SingletonSeparatedList<VariableDeclaratorSyntax>(
                        SyntaxFactory.VariableDeclarator(
                            SyntaxFactory.Identifier(Name))
                        .WithInitializer(
                            SyntaxFactory.EqualsValueClause(
                                objectCreation
                            )))));
        }
    }
}