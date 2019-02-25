using System.Collections.Generic;
using System.Linq;
using Manhasset.Core.src.Containers;
using Manhasset.Core.src.Extensions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Manhasset.Generator.src.CustomContainers
{
    public class RenameContainer : PrivateFieldContainer
    {
        public Dictionary<string, string> Renames = new Dictionary<string, string>();

        public void AddRename(string key, string value)
        {
            Renames.SafeAdd<string, string>(key, value);
        }

        public override FieldDeclarationSyntax GetSyntax()
        {
            var renameDict = new List<SyntaxNodeOrToken>();

            Renames.Select(r =>
            {
                return SyntaxFactory.InitializerExpression(
                            SyntaxKind.ComplexElementInitializerExpression,
                            SyntaxFactory.SeparatedList<ExpressionSyntax>(
                                new SyntaxNodeOrToken[]{
                                    SyntaxFactory.LiteralExpression(
                                        SyntaxKind.StringLiteralExpression,
                                        SyntaxFactory.Literal(r.Key)),
                                    SyntaxFactory.Token(SyntaxKind.CommaToken),
                                    SyntaxFactory.LiteralExpression(
                                        SyntaxKind.StringLiteralExpression,
                                        SyntaxFactory.Literal(r.Value))}));
            })
            .ToList()
            .ForEach(r =>
            {
                renameDict.Add(r);
                renameDict.Add(SyntaxFactory.Token(SyntaxKind.CommaToken));
            });

            return SyntaxFactory.FieldDeclaration(
                    SyntaxFactory.VariableDeclaration(
                        SyntaxFactory.GenericName(
                            SyntaxFactory.Identifier("Dictionary"))
                        .WithTypeArgumentList(
                            SyntaxFactory.TypeArgumentList(
                                SyntaxFactory.SeparatedList<TypeSyntax>(
                                    new SyntaxNodeOrToken[]{
                                        SyntaxFactory.PredefinedType(
                                            SyntaxFactory.Token(SyntaxKind.StringKeyword)),
                                        SyntaxFactory.Token(SyntaxKind.CommaToken),
                                        SyntaxFactory.PredefinedType(
                                            SyntaxFactory.Token(SyntaxKind.StringKeyword))}))))
                    .WithVariables(
                        SyntaxFactory.SingletonSeparatedList<VariableDeclaratorSyntax>(
                            SyntaxFactory.VariableDeclarator(
                                SyntaxFactory.Identifier("Renames"))
                            .WithInitializer(
                                SyntaxFactory.EqualsValueClause(
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
                                                        SyntaxFactory.PredefinedType(
                                                            SyntaxFactory.Token(SyntaxKind.StringKeyword))}))))
                                    .WithArgumentList(
                                        SyntaxFactory.ArgumentList())
                                    .WithInitializer(
                                SyntaxFactory.InitializerExpression(
                                    SyntaxKind.CollectionInitializerExpression,
                                    SyntaxFactory.SeparatedList<ExpressionSyntax>(
                                        renameDict.ToArray()
                                    ))))))))
                .WithModifiers(
                    SyntaxFactory.TokenList(
                        new[]{
                            SyntaxFactory.Token(SyntaxKind.InternalKeyword),
                            SyntaxFactory.Token(SyntaxKind.StaticKeyword)}));
        }
    }
}