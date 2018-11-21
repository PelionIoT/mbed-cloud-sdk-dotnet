using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Manhasset.Core.src.Containers;
using Manhasset.Core.src.Extensions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Formatting;
using Microsoft.CodeAnalysis.Formatting;

namespace Manhasset.Core.src.Compile
{
    public class Compilation
    {
        public Dictionary<string, ClassContainer> Classes { get; set; } = new Dictionary<string, ClassContainer>();

        public Dictionary<string, EnumContainer> Enums { get; set; } = new Dictionary<string, EnumContainer>();

        public void AddClass(string key, ClassContainer classContainer)
        {
            Classes.SafeAdd<string, ClassContainer>(key, classContainer);
        }

        public void AddEnum(string key, EnumContainer enumContainer)
        {
            Enums.SafeAdd<string, EnumContainer>(key, enumContainer);
        }

        public async System.Threading.Tasks.Task<int> Compile()
        {
            var workspace = CreateAdhocWorkspace();

            var projectId = workspace.CurrentSolution.Projects.FirstOrDefault().Id;

            foreach (var anEnum in Enums)
            {
                var formattedResult = Formatter.Format(anEnum.Value.GetSyntaxWithNamespace(), workspace, workspace.Options);

                // Console.WriteLine(formattedResult.ToFullString());

                AddDocumentToWorkspace(workspace, projectId, anEnum.Value.Name, formattedResult);
            }

            foreach (var aClass in Classes)
            {
                var formattedResult = Formatter.Format(aClass.Value.GetSyntaxWithNamespace(), workspace, workspace.Options);

                // Console.WriteLine(formattedResult.ToFullString());

                AddDocumentToWorkspace(workspace, projectId, aClass.Value.Name, formattedResult);
            }

            var currentProject = workspace.CurrentSolution.Projects.FirstOrDefault();
            currentProject = AddCompilationOptions(currentProject);
            var compilation = await currentProject.GetCompilationAsync();

            return ReviewDiagnosticMessages(compilation);
        }

        public void WriteFiles()
        {
            var workspace = new AdhocWorkspace();

            var options = workspace.Options
                .WithChangedOption(CSharpFormattingOptions.NewLineForMembersInObjectInit, true)
                .WithChangedOption(CSharpFormattingOptions.WrappingPreserveSingleLine, false)
                .WithChangedOption(CSharpFormattingOptions.WrappingKeepStatementsOnSingleLine, false)
                .WithChangedOption(CSharpFormattingOptions.NewLinesForBracesInObjectCollectionArrayInitializers, true)
                .WithChangedOption(CSharpFormattingOptions.IndentBlock, true);

            foreach (var anEnum in Enums)
            {
                var directory = Path.GetDirectoryName(anEnum.Value.FilePath);
                Directory.CreateDirectory(directory);
                // write all enums
                using (var file = new StreamWriter(File.Open(anEnum.Value.FilePath, FileMode.Create)))
                {
                    try
                    {
                        var formattedResult = Formatter.Format(anEnum.Value.GetSyntaxWithNamespace().SyntaxTree.GetRoot(), workspace, options);
                        file.Write(formattedResult.ToFullString());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
            }

            foreach (var aClass in Classes)
            {
                var directory = Path.GetDirectoryName(aClass.Value.FilePath);
                Directory.CreateDirectory(directory);
                // write all classes
                using (var file = new StreamWriter(File.Open(aClass.Value.FilePath, FileMode.Create)))
                {
                    try
                    {
                        var formattedResult = Formatter.Format(aClass.Value.GetSyntaxWithNamespace().SyntaxTree.GetRoot(), workspace, options);
                        file.Write(formattedResult.ToFullString());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
            }
        }

        public void AddMetadataReference(Type type)
        {
            AssemblyReferences.Add(MetadataReference.CreateFromFile(type.GetTypeInfo().Assembly.Location));
        }

        public void AddDocumentToWorkspace(AdhocWorkspace workspace, ProjectId projectId, string name, SyntaxNode formattedResult)
        {
            var doc = workspace.AddDocument(projectId, name, formattedResult.SyntaxTree.GetText());

            if (!workspace.TryApplyChanges(doc.Project.Solution))
            {
                Console.WriteLine("failed to add to project");
            }
        }

        private AdhocWorkspace CreateAdhocWorkspace()
        {
            var thisWorkspace = new AdhocWorkspace();

            var projName = "DefaultProject";

            var projId = ProjectId.CreateNewId();

            var versionStamp = VersionStamp.Create();

            var projectInfo = ProjectInfo.Create(projId, versionStamp, projName, projName, LanguageNames.CSharp);

            var newProject = thisWorkspace.AddProject(projectInfo);

            var options = thisWorkspace.Options
                    .WithChangedOption(CSharpFormattingOptions.NewLineForMembersInObjectInit, true)
                    .WithChangedOption(CSharpFormattingOptions.WrappingPreserveSingleLine, false)
                    .WithChangedOption(CSharpFormattingOptions.WrappingKeepStatementsOnSingleLine, false)
                    .WithChangedOption(CSharpFormattingOptions.NewLinesForBracesInObjectCollectionArrayInitializers, true)
                    .WithChangedOption(CSharpFormattingOptions.IndentBlock, true);

            return thisWorkspace;
        }

        private static Project AddCompilationOptions(Project project)
        {
            var options = new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary)
                                .WithOptimizationLevel(OptimizationLevel.Release)
                                .WithPlatform(Platform.AnyCpu);
            project = project.WithCompilationOptions(options)
                             .WithMetadataReferences(AssemblyReferences);
            return project;
        }

        private static List<MetadataReference> AssemblyReferences = new List<MetadataReference>
        {
            MetadataReference.CreateFromFile(typeof(object).GetTypeInfo().Assembly.Location),
            MetadataReference.CreateFromFile(Assembly.Load("Newtonsoft.Json, Version=11.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed").Location),
            MetadataReference.CreateFromFile(Assembly.Load("netstandard, Version=2.0.0.0").Location),
            MetadataReference.CreateFromFile(Assembly.Load("System.Runtime, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a").Location),
            MetadataReference.CreateFromFile(Assembly.Load("System.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a").Location),
        };

        private int ReviewDiagnosticMessages(Microsoft.CodeAnalysis.Compilation compiler)
        {
            var results = compiler.GetDiagnostics();
            // Console.WriteLine(results.Count());
            foreach (var item in results)
            {
                // Console.WriteLine(item.Location.SourceTree.GetRoot().ToFullString());
                Console.WriteLine(item.GetMessage() + item.Location);
            }
            return results.Length;
        }

    }
}