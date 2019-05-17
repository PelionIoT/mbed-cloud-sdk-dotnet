using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Manhasset.Core.src.Containers
{
    public class ConstructorContainer : BaseContainer
    {
        public virtual ConstructorDeclarationSyntax GetSyntax()
        {
            return SyntaxFactory.ConstructorDeclaration(
                        SyntaxFactory.Identifier(Name))
                    .WithModifiers(new SyntaxTokenList(MyModifiers.Values.ToArray()))
                    .WithBody(
                        SyntaxFactory.Block());
        }
    }
}