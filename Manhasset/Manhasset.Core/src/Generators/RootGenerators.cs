using System.Collections.Generic;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Manhasset.Core.src.Generators
{
    public static class RootGenerators
    {
        public static CompilationUnitSyntax CreateRoot()
        {
            return SyntaxFactory.CompilationUnit();
        }

        public static CompilationUnitSyntax AddNamespace(this CompilationUnitSyntax me, NamespaceDeclarationSyntax @namespace)
        {
            return me.AddMembers(@namespace);
        }

        public static CompilationUnitSyntax AddNamespace(this CompilationUnitSyntax me, List<NamespaceDeclarationSyntax> @namespace)
        {
            return me.AddMembers(@namespace.ToArray());
        }
    }
}