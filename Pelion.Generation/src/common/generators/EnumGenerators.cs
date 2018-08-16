using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Pelion.Generation.src.common.generators
{
    public static class EnumGenerators
    {
        public static EnumDeclarationSyntax CreateEnum(string name)
        {
            var enumDec = SyntaxFactory.EnumDeclaration(
                attributeLists: new SyntaxList<AttributeListSyntax>(),
                baseList: null,
                modifiers: SyntaxFactory.TokenList(SyntaxFactory.Token(SyntaxKind.PublicKeyword)),
                identifier: SyntaxFactory.Identifier(name),
                members: new SeparatedSyntaxList<EnumMemberDeclarationSyntax>()
            ).NormalizeWhitespace();

            return enumDec;
        }
    }
}