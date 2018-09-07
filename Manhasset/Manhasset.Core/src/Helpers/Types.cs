namespace Manhasset.Core.src.Helpers
{
    using System;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    public static class Types
    {
        public static TypeSyntax @bool { get => SyntaxFactory.ParseTypeName("bool?"); }
        public static TypeSyntax @int { get => SyntaxFactory.ParseTypeName("int?"); }
        public static TypeSyntax @string { get => SyntaxFactory.ParseTypeName("string"); }
        public static TypeSyntax date { get => SyntaxFactory.ParseTypeName("DateTime?"); }
        public static TypeSyntax @long { get => SyntaxFactory.ParseTypeName("long?"); }
        public static TypeSyntax @object { get => SyntaxFactory.ParseTypeName("Dictionary<string, object>"); }

        public static TypeSyntax List(string type)
        {
            return SyntaxFactory.ParseTypeName($"List<{type}>");
        }

        public static TypeSyntax CustomType(string name, bool nullable = false)
        {
            return nullable ? SyntaxFactory.ParseTypeName($"{name}?") : SyntaxFactory.ParseTypeName(name);
        }
    }
}