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
        public bool HasRequest { get; set; }

        public override MethodDeclarationSyntax GetSyntax()
        {
            var syntax = base.GetSyntax();

            var tryCatch = MethodGenerators.GetTryCatchBlock();

            var methodBody = base.GetMethodBodyParams();

            var returnStatement = new ApiCallReturnStatementContainer
            {
                Path = Path,
                PathParams = PathParams,
                QueryParams = QueryParams,
                FileParams = FileParams,
                BodyParams = BodyParams,
                HttpMethod = HttpMethod,
                Returns = Returns,
                EntityName = EntityName,
                HasRequest = HasRequest,
                IsVoidTask = IsVoidTask,
            };

            methodBody.Add(returnStatement.GetSyntax());

            var block = SyntaxFactory.Block(methodBody.ToArray());

            tryCatch = tryCatch.WithBlock(block);

            syntax = syntax.WithBody(SyntaxFactory.Block(tryCatch));

            return syntax;
        }
    }
}