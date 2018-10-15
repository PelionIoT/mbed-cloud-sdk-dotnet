using System.Collections.Generic;
using System.Linq;
using Manhasset.Core.src.Containers;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Manhasset.Generator.src.CustomContainers
{
    public class ApiCallReturnStatementContainer : ReturnStatementContainer
    {
        public string Path { get; set; }
        public List<MyParameterContainer> PathParams { get; set; }
        public List<MyParameterContainer> QueryParams { get; set; }
        public List<MyParameterContainer> FileParams { get; set; }
        public string HttpMethod { get; set; }

        public override ReturnStatementSyntax GetSyntax()
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

            if(FileParams.Any())
            {
                paramArgList.Add(GetVariableArg("fileParams", "fileParams"));
                paramArgList.Add(SyntaxFactory.Token(SyntaxKind.CommaToken));
            }

            paramArgList.Add(GetMemberAccessArg("method", "HttpMethods", HttpMethod));
            paramArgList.Add(SyntaxFactory.Token(SyntaxKind.CommaToken));

            paramArgList.Add(GetThisArg("objectToUnpack"));

            return SyntaxFactory.ReturnStatement(
                SyntaxFactory.AwaitExpression(
                    SyntaxFactory.InvocationExpression(
                        SyntaxFactory.MemberAccessExpression(
                            SyntaxKind.SimpleMemberAccessExpression,
                            SyntaxFactory.IdentifierName("Client"),
                            SyntaxFactory.GenericName(
                                SyntaxFactory.Identifier("CallApi"))
                            .WithTypeArgumentList(
                                SyntaxFactory.TypeArgumentList(
                                    SyntaxFactory.SingletonSeparatedList<TypeSyntax>(
                                        SyntaxFactory.IdentifierName("User"))))))
                    .WithArgumentList(
                        SyntaxFactory.ArgumentList(
                            SyntaxFactory.SeparatedList<ArgumentSyntax>(
                                paramArgList.ToArray()
                            )))));
        }

        private ArgumentSyntax GetLiteralArg(string identifier, string literal)
        {
            return SyntaxFactory.Argument(
                        SyntaxFactory.LiteralExpression(
                            SyntaxKind.StringLiteralExpression,
                            SyntaxFactory.Literal(literal)))
                    .WithNameColon(
                        SyntaxFactory.NameColon(
                            SyntaxFactory.IdentifierName(identifier)));
        }

        private ArgumentSyntax GetVariableArg(string identifier, string name)
        {
            return SyntaxFactory.Argument(
                        SyntaxFactory.IdentifierName(identifier))
                    .WithNameColon(
                        SyntaxFactory.NameColon(
                            SyntaxFactory.IdentifierName(name)));
        }

        private ArgumentSyntax GetMemberAccessArg(string identifier, string member, string value)
        {
            return SyntaxFactory.Argument(
                    SyntaxFactory.MemberAccessExpression(
                        SyntaxKind.SimpleMemberAccessExpression,
                        SyntaxFactory.IdentifierName(member),
                        SyntaxFactory.IdentifierName(value)))
                .WithNameColon(
                    SyntaxFactory.NameColon(
                        SyntaxFactory.IdentifierName(identifier)));
        }

        private ArgumentSyntax GetThisArg(string identifier)
        {
            return SyntaxFactory.Argument(
                    SyntaxFactory.ThisExpression())
                .WithNameColon(
                    SyntaxFactory.NameColon(
                        SyntaxFactory.IdentifierName(identifier)));
        }
    }
}