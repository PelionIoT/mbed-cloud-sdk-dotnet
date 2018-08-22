using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Pelion.Generation.src.common.generators
{
    public static class MethodGenerators
    {
        public static MethodDeclarationSyntax GenerateDebugDumpMethod()
        {
            return SyntaxFactory.MethodDeclaration(
                    SyntaxFactory.PredefinedType(
                        SyntaxFactory.Token(
                            SyntaxFactory.TriviaList(),
                            SyntaxKind.StringKeyword,
                            SyntaxFactory.TriviaList(
                                SyntaxFactory.Space))),
                    SyntaxFactory.Identifier("ToString"))
                .WithModifiers(
                    SyntaxFactory.TokenList(
                        new[]{
                            SyntaxFactory.Token(
                                SyntaxFactory.TriviaList(),
                                SyntaxKind.PublicKeyword,
                                SyntaxFactory.TriviaList(
                                    SyntaxFactory.Space)),
                            SyntaxFactory.Token(
                                SyntaxFactory.TriviaList(),
                                SyntaxKind.OverrideKeyword,
                                SyntaxFactory.TriviaList(
                                    SyntaxFactory.Space))}))
                .WithParameterList(
                    SyntaxFactory.ParameterList()
                    .WithCloseParenToken(
                        SyntaxFactory.Token(
                            SyntaxFactory.TriviaList(),
                            SyntaxKind.CloseParenToken,
                            SyntaxFactory.TriviaList(
                                SyntaxFactory.LineFeed))))
                .WithExpressionBody(
                    SyntaxFactory.ArrowExpressionClause(
                        SyntaxFactory.InvocationExpression(
                            SyntaxFactory.MemberAccessExpression(
                                SyntaxKind.SimpleMemberAccessExpression,
                                SyntaxFactory.ThisExpression(),
                                SyntaxFactory.IdentifierName("DebugDump"))))
                    .WithArrowToken(
                        SyntaxFactory.Token(
                            SyntaxFactory.TriviaList(
                                SyntaxFactory.Whitespace("    ")),
                            SyntaxKind.EqualsGreaterThanToken,
                            SyntaxFactory.TriviaList(
                                SyntaxFactory.Space))))
                .WithSemicolonToken(
                    SyntaxFactory.Token(SyntaxKind.SemicolonToken));
        }

        public static MethodDeclarationSyntax GenerateCrudMethod(
            string returns,
            string methodName,
            string method,
            string path,
            Dictionary<string, string> renames = null,
            Dictionary<string, string> methodParams = null,
            Dictionary<string, string> pathParams = null,
            Dictionary<string, string> queryParams = null,
            Dictionary<string, string> bodyParams = null
        )
        {
            var argList = new List<SyntaxNodeOrToken>();

            argList.Add(GetPath(path));
            argList.Add(SyntaxFactory.Token(SyntaxKind.CommaToken));
            argList.Add(GetMethod(method));
            argList.Add(SyntaxFactory.Token(SyntaxKind.CommaToken));
            argList.Add(GetSerializerSettingsWithRenames());
            argList.Add(SyntaxFactory.Token(SyntaxKind.CommaToken));
            if (method != "delete")
            {
                argList.Add(GetPopulateObject());
                argList.Add(SyntaxFactory.Token(SyntaxKind.CommaToken));
                argList.Add(GetObjectToPopulate());
                argList.Add(SyntaxFactory.Token(SyntaxKind.CommaToken));
            }

            argList.Add(GetAcceptsArray());
            argList.Add(SyntaxFactory.Token(SyntaxKind.CommaToken));
            argList.Add(GetContentTypesArray());
            argList.Add(SyntaxFactory.Token(SyntaxKind.CommaToken));
            argList.Add(GetBodyArg());
            argList.Add(SyntaxFactory.Token(SyntaxKind.CommaToken));

            if (pathParams != null)
            {
                argList.Add(GetPathParams(pathParams));
                argList.Add(SyntaxFactory.Token(SyntaxKind.CommaToken));
            }

            argList.Add(GetConfiguration());

            if (method == "delete")
            {
                return GenerateMethodSyntax("object", methodName, argList.ToArray(), renames, bodyParams, true);
            }

            return GenerateMethodSyntax(returns, methodName, argList.ToArray(), renames, bodyParams, false);
        }


        private static MethodDeclarationSyntax GenerateMethodSyntax(
            string returns,
            string name,
            SyntaxNodeOrToken[] argList,
            Dictionary<string, string> renames,
            Dictionary<string, string> body,
            bool voidMethod)
        {
            var returnCall = SyntaxFactory.Block(
                                SyntaxFactory.SingletonList<StatementSyntax>(
                                    SyntaxFactory.ReturnStatement(
                                                SyntaxFactory.AwaitExpression(
                                                    SyntaxFactory.InvocationExpression(
                                                        SyntaxFactory.MemberAccessExpression(
                                                            SyntaxKind.SimpleMemberAccessExpression,
                                                            SyntaxFactory.MemberAccessExpression(
                                                                SyntaxKind.SimpleMemberAccessExpression,
                                                                SyntaxFactory.MemberAccessExpression(
                                                                    SyntaxKind.SimpleMemberAccessExpression,
                                                                    SyntaxFactory.IdentifierName("MbedCloudSDK"),
                                                                    SyntaxFactory.IdentifierName("Client")),
                                                                SyntaxFactory.IdentifierName("ApiCall")),
                                                            SyntaxFactory.GenericName(
                                                                SyntaxFactory.Identifier("CallApi"))
                                                            .WithTypeArgumentList(
                                                                SyntaxFactory.TypeArgumentList(
                                                                    SyntaxFactory.SingletonSeparatedList<TypeSyntax>(
                                                                        // return type
                                                                        SyntaxFactory.IdentifierName(returns))))))
                                                    .WithArgumentList(
                                                        SyntaxFactory.ArgumentList(
                                                            SyntaxFactory.SeparatedList<ArgumentSyntax>(
                                                                // arguments
                                                                argList
                                                            )))))));

            var voidCall = SyntaxFactory.Block(
                                SyntaxFactory.SingletonList<StatementSyntax>(
                                    SyntaxFactory.ExpressionStatement(
                                                SyntaxFactory.AwaitExpression(
                                                    SyntaxFactory.InvocationExpression(
                                                        SyntaxFactory.MemberAccessExpression(
                                                            SyntaxKind.SimpleMemberAccessExpression,
                                                            SyntaxFactory.MemberAccessExpression(
                                                                SyntaxKind.SimpleMemberAccessExpression,
                                                                SyntaxFactory.MemberAccessExpression(
                                                                    SyntaxKind.SimpleMemberAccessExpression,
                                                                    SyntaxFactory.IdentifierName("MbedCloudSDK"),
                                                                    SyntaxFactory.IdentifierName("Client")),
                                                                SyntaxFactory.IdentifierName("ApiCall")),
                                                            SyntaxFactory.GenericName(
                                                                SyntaxFactory.Identifier("CallApi"))
                                                            .WithTypeArgumentList(
                                                                SyntaxFactory.TypeArgumentList(
                                                                    SyntaxFactory.SingletonSeparatedList<TypeSyntax>(
                                                                        SyntaxFactory.IdentifierName(returns))))))
                                                    .WithArgumentList(
                                                        SyntaxFactory.ArgumentList(
                                                            SyntaxFactory.SeparatedList<ArgumentSyntax>(
                                                                argList)))))));

            var voidDeclaration = SyntaxFactory.MethodDeclaration(
                SyntaxFactory.IdentifierName("Task"),
                SyntaxFactory.Identifier(name)
            );
            var returnDeclaration = SyntaxFactory.MethodDeclaration(
                    SyntaxFactory.GenericName(
                    SyntaxFactory.Identifier("Task"))
                    .WithTypeArgumentList(
                        SyntaxFactory.TypeArgumentList(
                            SyntaxFactory.SingletonSeparatedList<TypeSyntax>(
                                SyntaxFactory.IdentifierName(returns)))),
                    SyntaxFactory.Identifier(name)
                );

            return (voidMethod ? voidDeclaration : returnDeclaration)
                .WithModifiers(
                    SyntaxFactory.TokenList(
                        new[]{
                            SyntaxFactory.Token(SyntaxKind.PublicKeyword),
                            SyntaxFactory.Token(SyntaxKind.AsyncKeyword)}))
                .WithBody(
                    SyntaxFactory.Block(
                        // rename dictionary
                        GetRenameDictionary(renames),
                        // data
                        GetBody(body),
                        // try catch
                        GetTryCatchBlock()
                        .WithBlock(
                            voidMethod ? voidCall : returnCall
                        )).NormalizeWhitespace())
            .NormalizeWhitespace();
        }

        private static ArgumentSyntax GetBodyArg()
        {
            return SyntaxFactory.Argument(
                    SyntaxFactory.IdentifierName("data"))
                .WithNameColon(
                    SyntaxFactory.NameColon(
                        SyntaxFactory.IdentifierName("body")));
        }

        private static LocalDeclarationStatementSyntax GetBody(Dictionary<string, string> body)
        {
            if (body.Any())
            {
                var bodyArgs = new List<SyntaxNodeOrToken>();

                foreach (var item in body)
                {
                    var bodyItem = SyntaxFactory.AnonymousObjectMemberDeclarator(
                                        SyntaxFactory.IdentifierName(item.Key))
                                    .WithNameEquals(
                                        SyntaxFactory.NameEquals(
                                            SyntaxFactory.IdentifierName(item.Value)));

                    bodyArgs.Add(bodyItem);
                    bodyArgs.Add(SyntaxFactory.Token(SyntaxKind.CommaToken));
                }

                return SyntaxFactory.LocalDeclarationStatement(
                        SyntaxFactory.VariableDeclaration(
                            SyntaxFactory.IdentifierName("var"))
                        .WithVariables(
                            SyntaxFactory.SingletonSeparatedList<VariableDeclaratorSyntax>(
                                SyntaxFactory.VariableDeclarator(
                                    SyntaxFactory.Identifier("data"))
                                .WithInitializer(
                                    SyntaxFactory.EqualsValueClause(
                                        SyntaxFactory.AnonymousObjectCreationExpression(
                                            SyntaxFactory.SeparatedList<AnonymousObjectMemberDeclaratorSyntax>(
                                                bodyArgs.ToArray()
                                            ))))))).NormalizeWhitespace();
            }

            return SyntaxFactory.LocalDeclarationStatement(
                    SyntaxFactory.VariableDeclaration(
                        SyntaxFactory.IdentifierName("object"))
                    .WithVariables(
                        SyntaxFactory.SingletonSeparatedList<VariableDeclaratorSyntax>(
                            SyntaxFactory.VariableDeclarator(
                                SyntaxFactory.Identifier("data"))
                            .WithInitializer(
                                SyntaxFactory.EqualsValueClause(
                                    SyntaxFactory.LiteralExpression(
                                        SyntaxKind.NullLiteralExpression))))));
        }

        private static ArgumentSyntax GetMethod(string methodType)
        {
            return SyntaxFactory.Argument(
                SyntaxFactory.MemberAccessExpression(
                    SyntaxKind.SimpleMemberAccessExpression,
                    SyntaxFactory.IdentifierName("Method"),
                    SyntaxFactory.IdentifierName(methodType.ToUpper())))
            .WithNameColon(
                SyntaxFactory.NameColon(
                    SyntaxFactory.IdentifierName("method"))).NormalizeWhitespace();
        }

        private static ArgumentSyntax GetSerializerSettingsWithRenames()
        {
            return SyntaxFactory.Argument(
                SyntaxFactory.InvocationExpression(
                    SyntaxFactory.MemberAccessExpression(
                        SyntaxKind.SimpleMemberAccessExpression,
                        SyntaxFactory.IdentifierName("SerializationSettings"),
                        SyntaxFactory.IdentifierName("GetSettings")))
                .WithArgumentList(
                    SyntaxFactory.ArgumentList(
                        SyntaxFactory.SingletonSeparatedList<ArgumentSyntax>(
                            SyntaxFactory.Argument(
                                SyntaxFactory.IdentifierName("renames"))))))
            .WithNameColon(
                SyntaxFactory.NameColon(
                    SyntaxFactory.IdentifierName("settings"))).NormalizeWhitespace();
        }

        private static ArgumentSyntax GetConfiguration()
        {
            return SyntaxFactory.Argument(
                SyntaxFactory.IdentifierName("Config"))
            .WithNameColon(
                SyntaxFactory.NameColon(
                    SyntaxFactory.IdentifierName("configuration"))).NormalizeWhitespace();
        }

        private static ArgumentSyntax GetAcceptsArray()
        {
            return SyntaxFactory.Argument(
                SyntaxFactory.ArrayCreationExpression(
                    SyntaxFactory.ArrayType(
                        SyntaxFactory.PredefinedType(
                            SyntaxFactory.Token(SyntaxKind.StringKeyword)))
                    .WithRankSpecifiers(
                        SyntaxFactory.SingletonList<ArrayRankSpecifierSyntax>(
                            SyntaxFactory.ArrayRankSpecifier(
                                SyntaxFactory.SingletonSeparatedList<ExpressionSyntax>(
                                    SyntaxFactory.OmittedArraySizeExpression())))))
                .WithInitializer(
                    SyntaxFactory.InitializerExpression(
                        SyntaxKind.ArrayInitializerExpression,
                        SyntaxFactory.SingletonSeparatedList<ExpressionSyntax>(
                            SyntaxFactory.LiteralExpression(
                                SyntaxKind.StringLiteralExpression,
                                SyntaxFactory.Literal("application/json"))))))
            .WithNameColon(
                SyntaxFactory.NameColon(
                    SyntaxFactory.IdentifierName("accepts"))).NormalizeWhitespace();
        }

        private static ArgumentSyntax GetContentTypesArray()
        {
            return SyntaxFactory.Argument(
                SyntaxFactory.ArrayCreationExpression(
                    SyntaxFactory.ArrayType(
                        SyntaxFactory.PredefinedType(
                            SyntaxFactory.Token(SyntaxKind.StringKeyword)))
                    .WithRankSpecifiers(
                        SyntaxFactory.SingletonList<ArrayRankSpecifierSyntax>(
                            SyntaxFactory.ArrayRankSpecifier(
                                SyntaxFactory.SingletonSeparatedList<ExpressionSyntax>(
                                    SyntaxFactory.OmittedArraySizeExpression())))))
                .WithInitializer(
                    SyntaxFactory.InitializerExpression(
                        SyntaxKind.ArrayInitializerExpression,
                        SyntaxFactory.SingletonSeparatedList<ExpressionSyntax>(
                            SyntaxFactory.LiteralExpression(
                                SyntaxKind.StringLiteralExpression,
                                SyntaxFactory.Literal("application/json"))))))
            .WithNameColon(
                SyntaxFactory.NameColon(
                    SyntaxFactory.IdentifierName("contentTypes"))).NormalizeWhitespace();
        }

        private static ArgumentSyntax GetPathParams(Dictionary<string, string> pathParams)
        {
            var keyValueList = new List<SyntaxNodeOrToken>();

            foreach (var item in pathParams)
            {
                var dictProp = SyntaxFactory.InitializerExpression(
                                SyntaxKind.ComplexElementInitializerExpression,
                                SyntaxFactory.SeparatedList<ExpressionSyntax>(
                                    new SyntaxNodeOrToken[]{
                                        SyntaxFactory.LiteralExpression(
                                            SyntaxKind.StringLiteralExpression,
                                            SyntaxFactory.Literal(item.Key)),
                                        SyntaxFactory.Token(SyntaxKind.CommaToken),
                                        SyntaxFactory.IdentifierName(item.Value)}));

                keyValueList.Add(dictProp);
                keyValueList.Add(SyntaxFactory.Token(SyntaxKind.CommaToken));
            }

            return SyntaxFactory.Argument(
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
                                        SyntaxFactory.Token(SyntaxKind.ObjectKeyword))}))))
                .WithArgumentList(
                    SyntaxFactory.ArgumentList())
                .WithInitializer(
                    SyntaxFactory.InitializerExpression(
                        SyntaxKind.CollectionInitializerExpression,
                        SyntaxFactory.SeparatedList<ExpressionSyntax>(
                            keyValueList.ToArray()
                        ))))
            .WithNameColon(
                SyntaxFactory.NameColon(
                    SyntaxFactory.IdentifierName("pathParams"))).NormalizeWhitespace();
        }

        private static ArgumentSyntax GetPath(string path)
        {
            return SyntaxFactory.Argument(
                SyntaxFactory.LiteralExpression(
                    SyntaxKind.StringLiteralExpression,
                    SyntaxFactory.Literal(path)))
            .WithNameColon(
                SyntaxFactory.NameColon(
                    SyntaxFactory.IdentifierName("path"))).NormalizeWhitespace();
        }

        private static ArgumentSyntax GetPopulateObject()
        {
            return SyntaxFactory.Argument(
                SyntaxFactory.LiteralExpression(
                    SyntaxKind.TrueLiteralExpression))
            .WithNameColon(
                SyntaxFactory.NameColon(
                    SyntaxFactory.IdentifierName("populateObject")));
        }

        private static ArgumentSyntax GetObjectToPopulate()
        {
            return SyntaxFactory.Argument(
                SyntaxFactory.ThisExpression())
            .WithNameColon(
                SyntaxFactory.NameColon(
                    SyntaxFactory.IdentifierName("objectToPopulate")));
        }

        private static LocalDeclarationStatementSyntax GetRenameDictionary(Dictionary<string, string> renames)
        {
            if (renames.Any())
            {
                var renameList = new List<SyntaxNodeOrToken>();

                foreach (var item in renames)
                {
                    var renameItem = SyntaxFactory.InitializerExpression(
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

                    renameList.Add(renameItem);
                    renameList.Add(SyntaxFactory.Token(SyntaxKind.CommaToken));
                }

                return SyntaxFactory.LocalDeclarationStatement(
                    SyntaxFactory.VariableDeclaration(
                            SyntaxFactory.IdentifierName("var"))
                        .WithVariables(
                            SyntaxFactory.SingletonSeparatedList<VariableDeclaratorSyntax>(
                                SyntaxFactory.VariableDeclarator(
                                    SyntaxFactory.Identifier("renames"))
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
                                        .WithInitializer(
                                            SyntaxFactory.InitializerExpression(
                                                SyntaxKind.CollectionInitializerExpression,
                                                SyntaxFactory.SeparatedList<ExpressionSyntax>(
                                                    renameList.ToArray()
                                                )))))))
                ).NormalizeWhitespace();
            }

            return SyntaxFactory.LocalDeclarationStatement(
                    SyntaxFactory.VariableDeclaration(
                        SyntaxFactory.IdentifierName("var"))
                    .WithVariables(
                        SyntaxFactory.SingletonSeparatedList<VariableDeclaratorSyntax>(
                            SyntaxFactory.VariableDeclarator(
                                SyntaxFactory.Identifier("renames"))
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
                                        SyntaxFactory.ArgumentList())))))).NormalizeWhitespace();
        }

        private static TryStatementSyntax GetTryCatchBlock()
        {
            return SyntaxFactory.TryStatement(
                    SyntaxFactory.SingletonList<CatchClauseSyntax>(
                        SyntaxFactory.CatchClause()
                        .WithDeclaration(
                            SyntaxFactory.CatchDeclaration(
                                SyntaxFactory.QualifiedName(
                                    SyntaxFactory.QualifiedName(
                                        SyntaxFactory.IdentifierName("MbedCloudSDK"),
                                        SyntaxFactory.IdentifierName("Client")),
                                    SyntaxFactory.IdentifierName("ApiException")))
                            .WithIdentifier(
                                SyntaxFactory.Identifier("e")))
                        .WithBlock(
                            SyntaxFactory.Block(
                                SyntaxFactory.SingletonList<StatementSyntax>(
                                    SyntaxFactory.ThrowStatement(
                                        SyntaxFactory.ObjectCreationExpression(
                                            SyntaxFactory.IdentifierName("CloudApiException"))
                                        .WithArgumentList(
                                            SyntaxFactory.ArgumentList(
                                                SyntaxFactory.SeparatedList<ArgumentSyntax>(
                                                    new SyntaxNodeOrToken[]{
                                                        SyntaxFactory.Argument(
                                                            SyntaxFactory.MemberAccessExpression(
                                                                SyntaxKind.SimpleMemberAccessExpression,
                                                                SyntaxFactory.IdentifierName("e"),
                                                                SyntaxFactory.IdentifierName("ErrorCode"))),
                                                        SyntaxFactory.Token(SyntaxKind.CommaToken),
                                                        SyntaxFactory.Argument(
                                                            SyntaxFactory.MemberAccessExpression(
                                                                SyntaxKind.SimpleMemberAccessExpression,
                                                                SyntaxFactory.IdentifierName("e"),
                                                                SyntaxFactory.IdentifierName("Message"))),
                                                        SyntaxFactory.Token(SyntaxKind.CommaToken),
                                                        SyntaxFactory.Argument(
                                                            SyntaxFactory.MemberAccessExpression(
                                                                SyntaxKind.SimpleMemberAccessExpression,
                                                                SyntaxFactory.IdentifierName("e"),
                                                                SyntaxFactory.IdentifierName("ErrorContent")))}))))))))).NormalizeWhitespace();
        }
    }
}