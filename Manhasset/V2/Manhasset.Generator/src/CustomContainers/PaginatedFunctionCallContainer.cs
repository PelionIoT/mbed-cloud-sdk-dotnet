using System.Collections.Generic;
using System.Linq;
using Manhasset.Core.src.Containers;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Manhasset.Generator.src.CustomContainers
{
    public class PaginatedFunctionCallContainer : LocalDeclarationContainer
    {
        public string Returns { get; set; }
        public string Path { get; set; }
        public List<MyParameterContainer> PathParams { get; set; }
        public List<MyParameterContainer> QueryParams { get; set; }
        public List<MyParameterContainer> BodyParams { get; set; }
        public string HttpMethod { get; set; }

        public override LocalDeclarationStatementSyntax GetSyntax()
        {
            var paramArgList = new List<SyntaxNodeOrToken>();

            paramArgList.Add(GetLiteralArg("path", Path));
            paramArgList.Add(SyntaxFactory.Token(SyntaxKind.CommaToken));

            if (PathParams.Any())
            {
                paramArgList.Add(GetVariableArg("pathParams", "pathParams"));
                paramArgList.Add(SyntaxFactory.Token(SyntaxKind.CommaToken));
            }

            if (QueryParams.Any())
            {
                paramArgList.Add(GetVariableArg("queryParams", "queryParams"));
                paramArgList.Add(SyntaxFactory.Token(SyntaxKind.CommaToken));
            }

            if (BodyParams.Any())
            {
                paramArgList.Add(GetVariableArg("bodyParams", "bodyParams"));
                paramArgList.Add(SyntaxFactory.Token(SyntaxKind.CommaToken));
            }

            paramArgList.Add(GetMemberAccessArg("method", "HttpMethods", HttpMethod));

            return SyntaxFactory.LocalDeclarationStatement(
                SyntaxFactory.VariableDeclaration(
                    SyntaxFactory.GenericName(
                        SyntaxFactory.Identifier("Func"))
                    .WithTypeArgumentList(
                        SyntaxFactory.TypeArgumentList(
                            SyntaxFactory.SeparatedList<TypeSyntax>(
                                new SyntaxNodeOrToken[]{
                                    SyntaxFactory.IdentifierName("QueryOptions"),
                                    SyntaxFactory.Token(SyntaxKind.CommaToken),
                                    SyntaxFactory.GenericName(
                                        SyntaxFactory.Identifier("ResponsePage"))
                                    .WithTypeArgumentList(
                                        SyntaxFactory.TypeArgumentList(
                                            SyntaxFactory.SingletonSeparatedList<TypeSyntax>(
                                                SyntaxFactory.IdentifierName(Returns))))}))))
                .WithVariables(
                    SyntaxFactory.SingletonSeparatedList<VariableDeclaratorSyntax>(
                        SyntaxFactory.VariableDeclarator(
                            SyntaxFactory.Identifier("paginatedFunc"))
                        .WithInitializer(
                            SyntaxFactory.EqualsValueClause(
                                SyntaxFactory.ParenthesizedLambdaExpression(
                                    SyntaxFactory.InvocationExpression(
                                        SyntaxFactory.MemberAccessExpression(
                                            SyntaxKind.SimpleMemberAccessExpression,
                                            SyntaxFactory.IdentifierName("AsyncHelper"),
                                            SyntaxFactory.GenericName(
                                                SyntaxFactory.Identifier("RunSync"))
                                            .WithTypeArgumentList(
                                                SyntaxFactory.TypeArgumentList(
                                                    SyntaxFactory.SingletonSeparatedList<TypeSyntax>(
                                                        SyntaxFactory.GenericName(
                                                            SyntaxFactory.Identifier("ResponsePage"))
                                                        .WithTypeArgumentList(
                                                            SyntaxFactory.TypeArgumentList(
                                                                SyntaxFactory.SingletonSeparatedList<TypeSyntax>(
                                                                    SyntaxFactory.IdentifierName(Returns)))))))))
                                    .WithArgumentList(
                                        SyntaxFactory.ArgumentList(
                                            SyntaxFactory.SingletonSeparatedList<ArgumentSyntax>(
                                                SyntaxFactory.Argument(
                                                    SyntaxFactory.ParenthesizedLambdaExpression(
                                                        SyntaxFactory.InvocationExpression(
                                                            SyntaxFactory.MemberAccessExpression(
                                                                SyntaxKind.SimpleMemberAccessExpression,
                                                                SyntaxFactory.IdentifierName("Client"),
                                                                SyntaxFactory.GenericName(
                                                                    SyntaxFactory.Identifier("CallApi"))
                                                                .WithTypeArgumentList(
                                                                    SyntaxFactory.TypeArgumentList(
                                                                        SyntaxFactory.SingletonSeparatedList<TypeSyntax>(
                                                                            SyntaxFactory.GenericName(
                                                                                SyntaxFactory.Identifier("ResponsePage"))
                                                                            .WithTypeArgumentList(
                                                                                SyntaxFactory.TypeArgumentList(
                                                                                    SyntaxFactory.SingletonSeparatedList<TypeSyntax>(
                                                                                        SyntaxFactory.IdentifierName(Returns)))))))))
                                                        .WithArgumentList(
                                                            SyntaxFactory.ArgumentList(
                                                                SyntaxFactory.SeparatedList<ArgumentSyntax>(
                                                                    paramArgList.ToArray()
                                                                )))))))))
                                .WithParameterList(
                                    SyntaxFactory.ParameterList(
                                        SyntaxFactory.SingletonSeparatedList<ParameterSyntax>(
                                            SyntaxFactory.Parameter(
                                                SyntaxFactory.Identifier("_options"))
                                            .WithType(
                                                SyntaxFactory.IdentifierName("QueryOptions"))))))))));
        }
    }
}