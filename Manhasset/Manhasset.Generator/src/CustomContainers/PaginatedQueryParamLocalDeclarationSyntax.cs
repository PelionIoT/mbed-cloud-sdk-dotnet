using System.Collections.Generic;
using System.Linq;
using Manhasset.Generator.src.extensions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Manhasset.Generator.src.CustomContainers
{
    public class PaginatedQueryParamLocalDeclarationSyntax : DictionaryParamaterLocalDeclarationSyntax
    {
        public override EqualsValueClauseSyntax GetInitalizerSyntax()
        {
            var dictObjs = new List<SyntaxNodeOrToken>();

            MyParams
            .Select(p =>
            {
                return SyntaxFactory.InitializerExpression(
                        SyntaxKind.ComplexElementInitializerExpression,
                        SyntaxFactory.SeparatedList<ExpressionSyntax>(
                            new SyntaxNodeOrToken[]{
                                SyntaxFactory.LiteralExpression(
                                    SyntaxKind.StringLiteralExpression,
                                    SyntaxFactory.Literal(p.FieldName)),
                                SyntaxFactory.Token(SyntaxKind.CommaToken),
                                SyntaxFactory.MemberAccessExpression(
                                    SyntaxKind.SimpleMemberAccessExpression,
                                    SyntaxFactory.IdentifierName("_options"),
                                    SyntaxFactory.IdentifierName(p.Key.ToPascal()))}));
            })
            .ToList()
            .ForEach(p =>
            {
                dictObjs.Add(p);
                dictObjs.Add(SyntaxFactory.Token(SyntaxKind.CommaToken));
            });


            return SyntaxFactory.EqualsValueClause(
                                SyntaxFactory.ObjectCreationExpression(
                                    SyntaxFactory.GenericName(
                                        SyntaxFactory.Identifier("Dictionary"))
                                    .WithTypeArgumentList(
                                        SyntaxFactory.TypeArgumentList(
                                            SyntaxFactory.SeparatedList<TypeSyntax>(
                                                new SyntaxNodeOrToken[]{
                                                    SyntaxFactory.PredefinedType(
                                                        SyntaxFactory.Token(SyntaxKind.StringKeyword)),
                                                    SyntaxFactory.Token(SyntaxKind.CommaToken),
                                                        SyntaxFactory.IdentifierName(VarType)}))))
                                .WithInitializer(
                                    SyntaxFactory.InitializerExpression(
                                        SyntaxKind.CollectionInitializerExpression,
                                        SyntaxFactory.SeparatedList<ExpressionSyntax>(
                                            dictObjs.ToArray()
                                        ))));
        }
    }
}