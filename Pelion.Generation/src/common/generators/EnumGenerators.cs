using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Pelion.Generation.src.common.generators
{
    public static class EnumGenerators
    {
        public static EnumDeclarationSyntax CreateEnum(string name, List<string> members)
        {
            var memberList = new List<SyntaxNodeOrToken>();
            members.ForEach(m =>
            {
                memberList.Add(SyntaxFactory.EnumMemberDeclaration(SyntaxFactory.Identifier(m)));
                memberList.Add(SyntaxFactory.Token(SyntaxKind.CommaToken));
            });


            return SyntaxFactory.EnumDeclaration(name)
                .WithModifiers(
                    SyntaxFactory.TokenList(
                        SyntaxFactory.Token(SyntaxKind.PublicKeyword)))
                .WithMembers(
                    SyntaxFactory.SeparatedList<EnumMemberDeclarationSyntax>(
                        memberList.ToArray()
                    ));
                    //.NormalizeWhitespace();

            // var enumDec = SyntaxFactory.EnumDeclaration(
            //     attributeLists: new SyntaxList<AttributeListSyntax>(),
            //     baseList: null,
            //     modifiers: SyntaxFactory.TokenList(SyntaxFactory.Token(SyntaxKind.PublicKeyword)),
            //     identifier: SyntaxFactory.Identifier(name),
            //     members: new SeparatedSyntaxList<EnumMemberDeclarationSyntax>()
            // ).NormalizeWhitespace();
        }
    }
}