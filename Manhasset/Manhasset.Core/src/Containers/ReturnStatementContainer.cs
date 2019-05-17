using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Manhasset.Core.src.Containers
{
    public class ReturnStatementContainer : BaseContainer
    {
        public virtual StatementSyntax GetSyntax()
        {
            return SyntaxFactory.ReturnStatement();
        }
    }
}