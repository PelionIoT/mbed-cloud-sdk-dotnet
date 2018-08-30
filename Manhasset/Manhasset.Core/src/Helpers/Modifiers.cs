namespace Manhasset.Core.src.Helpers
{
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    public static class Modifiers
    {
        public static SyntaxToken PublicMod { get => SyntaxFactory.Token(SyntaxKind.PublicKeyword); }
        public static SyntaxToken StaticMod { get => SyntaxFactory.Token(SyntaxKind.StaticKeyword); }
        public static SyntaxToken PrivateMod { get => SyntaxFactory.Token(SyntaxKind.PrivateKeyword); }
        public static SyntaxToken AbstractMod { get => SyntaxFactory.Token(SyntaxKind.AbstractKeyword); }
        public static SyntaxToken InternalMod { get => SyntaxFactory.Token(SyntaxKind.InternalKeyword); }
        public static SyntaxToken PartialMod { get => SyntaxFactory.Token(SyntaxKind.PartialKeyword); }
    }
}