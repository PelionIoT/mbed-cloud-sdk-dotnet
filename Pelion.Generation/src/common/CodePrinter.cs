using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Formatting;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Formatting;
using Pelion.Generation.src.common.generators;

namespace Pelion.Generation.src.common
{
    public static class CodePrinter
    {
        public static string PrintCode(SyntaxNode node)
        {
            var workspace = new AdhocWorkspace();

            // var projName = "NewProject";
            // var projectId = ProjectId.CreateNewId();
            // var versionStamp = VersionStamp.Create();
            // var projectInfo = ProjectInfo.Create(projectId, versionStamp, projName, projName, LanguageNames.CSharp);
            // var newProject = workspace.AddProject(projectInfo);
            // var doc = workspace.AddDocument(newProject.Id, "newDoc", node.GetText());

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