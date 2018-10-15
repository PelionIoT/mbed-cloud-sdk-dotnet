using System.Collections.Generic;
using System.Linq;
using Manhasset.Core.src.Containers;
using Manhasset.Core.src.Generators;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Manhasset.Generator.src.CustomContainers
{
    public class DefaultMethodContainer : BaseMethodContainer
    {
        public override MethodDeclarationSyntax GetSyntax()
        {
            var syntax = base.GetSyntax();

            var tryCatch = MethodGenerators.GetTryCatchBlock();

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
                // body
            }

            var returnStatement = new ApiCallReturnStatementContainer{
                Path = Path,
                PathParams = PathParams,
                QueryParams = QueryParams,
                FileParams = FileParams,
                HttpMethod = HttpMethod
            };

            methodBody.Add(returnStatement.GetSyntax());

            var block = SyntaxFactory.Block(methodBody.ToArray());

            tryCatch = tryCatch.WithBlock(block);

            syntax = syntax.WithBody(SyntaxFactory.Block(tryCatch));

            return syntax;
        }
    }
}