using System;
using Manhasset.Core.src.Generators;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Formatting;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Formatting;

namespace Manhasset.Generator.src.Helpers
{
    public static class CodePrinter
    {
        public static string PrintCode(SyntaxNode node)
        {
            var workspace = new AdhocWorkspace();

            var options = workspace.Options
                .WithChangedOption(CSharpFormattingOptions.NewLineForMembersInObjectInit, true)
                .WithChangedOption(CSharpFormattingOptions.WrappingPreserveSingleLine, false)
                .WithChangedOption(CSharpFormattingOptions.WrappingKeepStatementsOnSingleLine, false)
                .WithChangedOption(CSharpFormattingOptions.NewLinesForBracesInObjectCollectionArrayInitializers, true)
                .WithChangedOption(CSharpFormattingOptions.IndentBlock, true);

            try
            {
                var formattedResult = Formatter.Format(node, workspace, options);
                return formattedResult.ToFullString();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return "";
            }
        }

        public static string PrintCodeNamespace(MemberDeclarationSyntax node)
        {
            var root = RootGenerators.CreateRoot();

            root = root.AddMembers(node);

            root.Members.FirstOrDefault();

            return PrintCode(root.Members.FirstOrDefault());
        }
    }
}