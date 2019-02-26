using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Manhasset.Generator.src.CustomContainers
{
    public class CustomFunctionMethodContainer : BaseMethodContainer
    {
        public override MethodDeclarationSyntax GetSyntax()
        {
            var methodParams = base.MethodParams.Parameters;

            var syntax = base.GetSyntax();
            // return the custom function call
            var customFunctionReturnStatementContainer = new CustomFunctionReturnStatementContainer
            {
                CustomFunctionName = CustomMethodName,
                MethodParams = methodParams,
            }.GetSyntax();

            return syntax.WithBody(SyntaxFactory.Block(customFunctionReturnStatementContainer));
        }
    }
}