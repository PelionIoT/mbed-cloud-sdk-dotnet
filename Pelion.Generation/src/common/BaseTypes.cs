namespace Pelion.Generation.src.common
{
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    public static class BaseTypes
    {
        public static SimpleBaseTypeSyntax BaseModel { get => SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName("BaseModel")); }

        public static SimpleBaseTypeSyntax CustomType(string name)
        {
            return SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName(name));
        }
    }
}