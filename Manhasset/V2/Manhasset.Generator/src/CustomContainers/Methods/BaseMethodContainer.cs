using System.Collections.Generic;
using System.Linq;
using Manhasset.Core.src.Containers;
using Manhasset.Core.src.Generators;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Manhasset.Generator.src.CustomContainers
{
    public class BaseMethodContainer : MethodContainer
    {
        public string EntityName { get; set; }
        public string HttpMethod { get; set; }
        public string Path { get; set; }
        public bool Paginated { get; set; }
        public List<MyParameterContainer> PathParams { get; set; }
        public List<MyParameterContainer> QueryParams { get; set; }
        public List<MyParameterContainer> BodyParams { get; set; }
        public List<MyParameterContainer> FileParams { get; set; }
        public bool DeferToForeignKey { get; set; }
        public DeferedMethodCallContainer DeferedMethodCall { get; set; }
        public bool CustomMethodCall { get; set; }
        public string CustomMethodName { get; set; }
        public bool privateMethod { get; set; }

        protected List<StatementSyntax> GetMethodBodyParams()
        {
            var methodBody = new List<StatementSyntax>();

            if (PathParams.Any())
            {
                var pathDeclaration = new DictionaryParamaterLocalDeclarationSyntax
                {
                    Name = "pathParams",
                    MyParams = PathParams,
                }.GetSyntax();

                methodBody.Add(pathDeclaration);
            }

            if (QueryParams.Any())
            {
                var queryParamDeclaration = new DictionaryParamaterLocalDeclarationSyntax
                {
                    Name = "queryParams",
                    MyParams = QueryParams,
                }.GetSyntax();

                methodBody.Add(queryParamDeclaration);
            }

            if (FileParams.Any())
            {
                var fileParamDeclaration = new DictionaryParamaterLocalDeclarationSyntax
                {
                    Name = "fileParams",
                    MyParams = FileParams,
                }.GetSyntax();

                methodBody.Add(fileParamDeclaration);
            }

            if (BodyParams.Any())
            {
                var bodyParamDeclaration = new BodyParameterContainer
                {
                    BodyType = Returns,
                    BodyParams = BodyParams
                }.GetSyntax();

                methodBody.Add(bodyParamDeclaration);
            }

            return methodBody;
        }

        protected MethodDeclarationSyntax GetPaginatedSignature()
        {
            return SyntaxFactory.MethodDeclaration(
                    SyntaxFactory.GenericName(
                        SyntaxFactory.Identifier("PaginatedResponse"))
                    .WithTypeArgumentList(
                        SyntaxFactory.TypeArgumentList(
                            SyntaxFactory.SeparatedList<TypeSyntax>(
                                new SyntaxNodeOrToken[]{
                                    SyntaxFactory.IdentifierName("QueryOptions"),
                                    SyntaxFactory.Token(SyntaxKind.CommaToken),
                                    SyntaxFactory.IdentifierName(Returns)}))),
                    SyntaxFactory.Identifier(Name))
                .WithModifiers(
                    SyntaxFactory.TokenList(
                        SyntaxFactory.Token(SyntaxKind.PublicKeyword)))
                .WithBody(
                    SyntaxFactory.Block())
                .WithParameterList(MethodParams.GetSyntax());
        }
    }
}