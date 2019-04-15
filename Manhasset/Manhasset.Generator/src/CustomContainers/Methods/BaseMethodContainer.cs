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
        public List<MyParameterContainer> FormParams { get; set; }
        public bool DeferToForeignKey { get; set; }
        public DeferedMethodCallContainer DeferedMethodCall { get; set; }
        public bool CustomMethodCall { get; set; }
        public string CustomMethodName { get; set; }
        public bool privateMethod { get; set; }

        protected List<StatementSyntax> GetMethodBodyParams(bool ignoreQuery = false)
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

            if (QueryParams.Any() && !ignoreQuery)
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
                    VarType = "Stream",
                }.GetSyntax();

                methodBody.Add(fileParamDeclaration);
            }

            if (FormParams.Any())
            {
                var formParamDeclaration = new DictionaryParamaterLocalDeclarationSyntax
                {
                    Name = "formParams",
                    MyParams = FormParams,
                }.GetSyntax();

                methodBody.Add(formParamDeclaration);
            }

            // only add internal body params
            if (BodyParams.Where(b => b.External != true || b.ReplaceBody == true).Any())
            {
                var bodyParamDeclaration = new BodyParameterContainer
                {
                    BodyType = Returns,
                    BodyParams = BodyParams.Where(b => b.External != true || b.ReplaceBody == true).ToList(),
                }.GetSyntax();

                methodBody.Add(bodyParamDeclaration);
            }

            return methodBody;
        }

        protected StatementSyntax GetPaginatedQueryParams()
        {
            if (QueryParams.Any())
            {
                var queryParamDeclaration = new PaginatedQueryParamLocalDeclarationSyntax
                {
                    Name = "queryParams",
                    MyParams = QueryParams,
                }.GetSyntax();

                return queryParamDeclaration;
            }

            return default(StatementSyntax);
        }

        protected MethodDeclarationSyntax GetPaginatedSignature(string listOptionsName = "QueryOptions", MethodParameterContainer methodParams = null)
        {
            methodParams.Parameters = methodParams.Parameters.Where(p => p.Key != "after" && p.Key != "order" && p.Key != "limit" && p.Key != "include").OrderBy(p => !p.Required).ToList();
            var paginatedSyntax = SyntaxFactory.MethodDeclaration(
                    SyntaxFactory.GenericName(
                        SyntaxFactory.Identifier("PaginatedResponse"))
                    .WithTypeArgumentList(
                        SyntaxFactory.TypeArgumentList(
                            SyntaxFactory.SeparatedList<TypeSyntax>(
                                new SyntaxNodeOrToken[]{
                                    SyntaxFactory.IdentifierName(listOptionsName),
                                    SyntaxFactory.Token(SyntaxKind.CommaToken),
                                    SyntaxFactory.IdentifierName(Returns)}))),
                    SyntaxFactory.Identifier(Name))
                .WithModifiers(new SyntaxTokenList(MyModifiers.Values.ToArray()))
                .WithBody(
                    SyntaxFactory.Block())
                .WithParameterList(methodParams.GetSyntax());

            return IsInterface ? paginatedSyntax.WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken)) : paginatedSyntax.WithBody(SyntaxFactory.Block());
        }
    }
}