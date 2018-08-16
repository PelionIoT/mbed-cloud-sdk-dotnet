namespace Pelion.Generation.src.common.generators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    public static class NamespaceGenerators
    {
        public static NamespaceDeclarationSyntax CreateNamespace(string name, params string[] usings)
        {
            var @namespace = SyntaxFactory.NamespaceDeclaration(SyntaxFactory.ParseName(name));

            foreach (var @using in usings)
            {
                @namespace = @namespace.AddUsings(SyntaxFactory.UsingDirective(SyntaxFactory.ParseName(@using)));
            }

            return @namespace.NormalizeWhitespace();
        }

        public static NamespaceDeclarationSyntax AddClass(this NamespaceDeclarationSyntax me, ClassDeclarationSyntax @class)
        {
            return me.AddMembers(@class).NormalizeWhitespace();
        }

        public static NamespaceDeclarationSyntax AddEnum(this NamespaceDeclarationSyntax me, EnumDeclarationSyntax @enum)
        {
            return me.AddMembers(@enum).NormalizeWhitespace();
        }

        public static NamespaceDeclarationSyntax AddUsing(this NamespaceDeclarationSyntax me, string @using)
        {
            return me.AddUsings(SyntaxFactory.UsingDirective(SyntaxFactory.ParseName(@using))).NormalizeWhitespace();
        }

        public static NamespaceDeclarationSyntax RemoveDuplicateUsings(this NamespaceDeclarationSyntax me)
        {
            var temp = new List<UsingDirectiveSyntax>();
            foreach (var item in me.Usings)
            {
                if (!temp.Any(u => u.Name.ToFullString() == item.Name.ToFullString()))
                {
                    temp.Add(item);
                }
            }
            return me.WithUsings(SyntaxFactory.List(temp));
        }

        public static NamespaceDeclarationSyntax AddFileHeader(this NamespaceDeclarationSyntax me, string fileHeader)
        {
            var header = SyntaxFactory.TriviaList(
                new[]{
                    SyntaxFactory.Comment("// <copyright file=\"AccountManagementApi.Account.cs\" company=\"Arm\">"),
                    SyntaxFactory.LineFeed,
                    SyntaxFactory.Comment("// Copyright (c) Arm. All rights reserved."),
                    SyntaxFactory.LineFeed,
                    SyntaxFactory.Comment("// </copyright>"),
                    SyntaxFactory.LineFeed,
                    SyntaxFactory.LineFeed,
                }
            );

            return me.InsertTriviaBefore(me.GetLeadingTrivia().First(), header).NormalizeWhitespace();
        }
    }
}