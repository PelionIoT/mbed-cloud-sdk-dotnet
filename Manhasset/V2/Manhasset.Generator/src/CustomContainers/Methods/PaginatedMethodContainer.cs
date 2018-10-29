using System;
using System.Collections.Generic;
using System.Linq;
using Manhasset.Core.src.Generators;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Manhasset.Generator.src.CustomContainers
{
    public class PaginatedMethodContainer : BaseMethodContainer
    {
        public override MethodDeclarationSyntax GetSyntax()
        {
            var syntax = base.GetPaginatedSignature();

            var tryCatch = MethodGenerators.GetTryCatchBlock();

            var methodBody = base.GetMethodBodyParams(ignoreQuery: true);

            var queryOptionsNullCheck = new QueryOptionsNullCheckContainer().GetSyntax();
            methodBody.Add(queryOptionsNullCheck);

            var queryParams = base.GetPaginatedQueryParams();

            // paginated function call
            var paginatedFunctionCallContainer = new PaginatedFunctionCallContainer
            {
                Path = Path,
                Returns = Returns,
                HttpMethod = HttpMethod,
                PathParams = PathParams,
                QueryParams = QueryParams,
                BodyParams = BodyParams,
                QueryParamDict = queryParams,
            }.GetSyntax();
            methodBody.Add(paginatedFunctionCallContainer);

            // return a paginated response
            var paginatedResponseReturnStatementContainer = new PaginatedResponseReturnStatementContainer
            {
                Returns = Returns,
            }.GetSyntax();
            methodBody.Add(paginatedResponseReturnStatementContainer);

            var block = SyntaxFactory.Block(methodBody.ToArray());

            tryCatch = tryCatch.WithBlock(block);

            syntax = syntax.WithBody(SyntaxFactory.Block(tryCatch));

            return syntax;
        }
    }
}