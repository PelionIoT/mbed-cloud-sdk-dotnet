using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Manhasset.Core.src.Common
{
    public static class Modifiers
    {
        public static readonly SyntaxToken PUBLIC = SyntaxFactory.Token(SyntaxKind.PublicKeyword);
        public static readonly SyntaxToken STATIC = SyntaxFactory.Token(SyntaxKind.StaticKeyword);
        public static readonly SyntaxToken PRIVATE = SyntaxFactory.Token(SyntaxKind.PrivateKeyword);
        public static readonly SyntaxToken ABSTRACT = SyntaxFactory.Token(SyntaxKind.AbstractKeyword);
        public static readonly SyntaxToken INTERNAL = SyntaxFactory.Token(SyntaxKind.InternalKeyword);
        public static readonly SyntaxToken PARTIAL = SyntaxFactory.Token(SyntaxKind.PartialKeyword);
        public static readonly SyntaxToken ASYNC = SyntaxFactory.Token(SyntaxKind.AsyncKeyword);
        public static readonly SyntaxToken PARAMS = SyntaxFactory.Token(SyntaxKind.ParamsKeyword);
    }
}