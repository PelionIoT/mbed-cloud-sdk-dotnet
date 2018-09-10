using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Manhasset.Core.src.Generators
{
    public static class DictionaryGenerators
    {
        public static FieldDeclarationSyntax GenerateRenameDictionary(Dictionary<string, Dictionary<string, string>> renames)
        {
            return SyntaxFactory.FieldDeclaration(
                    GetDictionaryVariable()
                    .WithVariables(
                        SyntaxFactory.SingletonSeparatedList<VariableDeclaratorSyntax>(
                            SyntaxFactory.VariableDeclarator(
                                SyntaxFactory.Identifier("RenamesDict"))
                            .WithInitializer(
                                SyntaxFactory.EqualsValueClause(
                                    SyntaxFactory.ObjectCreationExpression(
                                        SyntaxFactory.GenericName(
                                            SyntaxFactory.Identifier("Dictionary"))
                                        .WithTypeArgumentList(
                                            SyntaxFactory.TypeArgumentList(
                                                SyntaxFactory.SeparatedList<TypeSyntax>(
                                                    new SyntaxNodeOrToken[]{
                                                        SyntaxFactory.IdentifierName("Type"),
                                                        SyntaxFactory.Token(SyntaxKind.CommaToken),
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
                                                                            SyntaxFactory.Token(SyntaxKind.StringKeyword))})))}))))
                                    .WithInitializer(
                                        GetOuterDictionary(renames)
                                    ))))))
                .WithModifiers(
                    SyntaxFactory.TokenList(
                        new[]{
                            SyntaxFactory.Token(SyntaxKind.PublicKeyword),
                            SyntaxFactory.Token(SyntaxKind.StaticKeyword)}));
        }

        private static InitializerExpressionSyntax GetOuterDictionary(Dictionary<string, Dictionary<string, string>> renames)
        {
            var outerDict = new List<SyntaxNodeOrToken>();

            foreach (var item in renames)
            {
                var innerDict = GetInternalDictionary(item.Key, item.Value);

                outerDict.Add(innerDict);
                outerDict.Add(SyntaxFactory.Token(SyntaxKind.CommaToken));
            }

            return SyntaxFactory.InitializerExpression(
                    SyntaxKind.CollectionInitializerExpression,
                    SyntaxFactory.SeparatedList<ExpressionSyntax>(
                        outerDict.ToArray()
                    ));
        }

        private static InitializerExpressionSyntax GetInternalDictionary(string type, Dictionary<string, string> renames)
        {
            var split = type.Split('.');

            var innerDict = new List<SyntaxNodeOrToken>();

            foreach (var item in renames)
            {
                var keyVal = SyntaxFactory.InitializerExpression(
                                SyntaxKind.ComplexElementInitializerExpression,
                                SyntaxFactory.SeparatedList<ExpressionSyntax>(
                                    new SyntaxNodeOrToken[]{
                                        SyntaxFactory.LiteralExpression(
                                            SyntaxKind.StringLiteralExpression,
                                            SyntaxFactory.Literal(item.Key)),
                                        SyntaxFactory.Token(SyntaxKind.CommaToken),
                                        SyntaxFactory.LiteralExpression(
                                            SyntaxKind.StringLiteralExpression,
                                            SyntaxFactory.Literal(item.Value))}));

                innerDict.Add(keyVal);
                innerDict.Add(SyntaxFactory.Token(SyntaxKind.CommaToken));
            }

            return SyntaxFactory.InitializerExpression(
                    SyntaxKind.ComplexElementInitializerExpression,
                    SyntaxFactory.SeparatedList<ExpressionSyntax>(
                        new SyntaxNodeOrToken[]{
                            SyntaxFactory.TypeOfExpression(
                                SyntaxFactory.QualifiedName(
                                    SyntaxFactory.QualifiedName(
                                        SyntaxFactory.QualifiedName(
                                            SyntaxFactory.IdentifierName(split[0]),
                                            SyntaxFactory.IdentifierName(split[1])),
                                        SyntaxFactory.IdentifierName(split[2])),
                                    SyntaxFactory.IdentifierName(split[3]))),
                            SyntaxFactory.Token(SyntaxKind.CommaToken),
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
                            .WithInitializer(
                                SyntaxFactory.InitializerExpression(
                                    SyntaxKind.CollectionInitializerExpression,
                                    SyntaxFactory.SeparatedList<ExpressionSyntax>(
                                        innerDict.ToArray()
                                    )))}));
        }

        private static VariableDeclarationSyntax GetDictionaryVariable()
        {
            return SyntaxFactory.VariableDeclaration(
                        SyntaxFactory.GenericName(
                            SyntaxFactory.Identifier("Dictionary"))
                        .WithTypeArgumentList(
                            SyntaxFactory.TypeArgumentList(
                                SyntaxFactory.SeparatedList<TypeSyntax>(
                                    new SyntaxNodeOrToken[]{
                                        SyntaxFactory.IdentifierName("Type"),
                                        SyntaxFactory.Token(SyntaxKind.CommaToken),
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
                                                            SyntaxFactory.Token(SyntaxKind.StringKeyword))})))}))));
        }
    }
}