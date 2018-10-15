using System.Collections.Generic;
using System.Linq;
using Manhasset.Core.src.Containers;
using Manhasset.Generator.src.extensions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Manhasset.Generator.src.CustomContainers
{
    public class MyMethodParameterContainer : MethodParameterContainer
    {
        public MyMethodParameterContainer(List<MyParameterContainer> deferedParams,
                                        List<MyParameterContainer> pathParams,
                                        List<MyParameterContainer> queryParams,
                                        List<MyParameterContainer> bodyParams,
                                        List<MyParameterContainer> fileParams)
        {
            Parameters = new List<MyParameterContainer>()
                                .Concat(deferedParams)
                                .Concat(pathParams)
                                .Concat(queryParams)
                                .Concat(bodyParams)
                                .Concat(fileParams)
                                .Where(p => p.External == true)
                                .Select(p =>
                                {
                                    p.Key = p.Key.PascalToCamel();
                                    return p;
                                })
                                .OrderBy(p => p.Required)
                                .Cast<ParameterContainer>()
                                .ToList();
        }

        public override ParameterSyntax GetParamaterSyntax(ParameterContainer p)
        {
            var syntax = base.GetParamaterSyntax(p);

            if (!p.Required)
            {
                return syntax.WithDefault(
                    SyntaxFactory.EqualsValueClause(
                        SyntaxFactory.LiteralExpression(
                            SyntaxKind.NullLiteralExpression))
                );
            }

            return syntax;
        }
    }
}