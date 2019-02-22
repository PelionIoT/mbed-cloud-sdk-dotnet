using System.Linq;
using Manhasset.Core.src.Common;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Manhasset.Core.src.Containers
{
    public class PrivateFieldContainer : BaseContainer
    {
        public string FieldType { get; set; }

        public virtual FieldDeclarationSyntax GetSyntax()
        {
            return SyntaxFactory.FieldDeclaration(SyntaxFactory.VariableDeclaration(SyntaxFactory.ParseTypeName(FieldType))
                                                        .AddVariables(SyntaxFactory.VariableDeclarator(Name)))
                                                        .AddModifiers(MyModifiers.Values.ToArray());
        }
    }
}