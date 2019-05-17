using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Manhasset.Core.src.Containers
{
    public class MethodParameterContainer
    {
        public List<ParameterContainer> Parameters { get; set; } = new List<ParameterContainer>();

        public virtual ParameterSyntax GetParamaterSyntax(ParameterContainer p)
        {
            return SyntaxFactory.Parameter(
                    SyntaxFactory.Identifier(p.Key)
                ).WithType(
                    SyntaxFactory.IdentifierName(p.ParamType)
                ).WithModifiers(
                    new SyntaxTokenList(p.MyModifiers.Values.ToArray())
                );
        }

        public virtual ParameterListSyntax GetSyntax()
        {
            // add comma tokens to params
            var parameters = new List<SyntaxNodeOrToken>();

            Parameters.Select(p =>
            {
                return GetParamaterSyntax(p);
            })
            .ToList()
            .ForEach(p =>
            {
                parameters.Add(p);
                parameters.Add(SyntaxFactory.Token(SyntaxKind.CommaToken));
            });

            // remove trailing comma
            if (parameters.Any())
            {
                parameters.RemoveAt(parameters.Count - 1);
            }

            return SyntaxFactory.ParameterList(
                SyntaxFactory.SeparatedList<ParameterSyntax>(
                    parameters.ToArray()
                )
            );
        }
    }
}