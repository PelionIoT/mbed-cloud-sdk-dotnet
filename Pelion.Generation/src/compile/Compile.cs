using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Buildalyzer;
using Buildalyzer.Workspaces;
using MbedCloudSDK.AccountManagement.Model.ApiKey;
using MbedCloudSDK.Bootstrap.Model;
using MbedCloudSDK.Common;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Newtonsoft.Json.Converters;

namespace Pelion.Generation.src.compile
{
    public class Compile
    {
        private readonly string targetProject;
        private readonly string targetProjectName;
        public Compile(string targetProject, string targetProjectName)
        {
            this.targetProject = targetProject;
            this.targetProjectName = targetProjectName;
        }

        public int CompileFiles(SyntaxTree tree)
        {
            AnalyzerManager manager = new AnalyzerManager();
            ProjectAnalyzer analyzer = manager.GetProject(targetProject);
            AdhocWorkspace workspace = new AdhocWorkspace();
            Project roslynProject = analyzer.AddToWorkspace(workspace);

            var proj = LoadProject(workspace);
            var doc = SafeAddDocument(proj, tree, "doc");
            if (!workspace.TryApplyChanges(doc.Project.Solution))
            {
                Console.WriteLine("failed to add to project");
            }
            proj = doc.Project;
            proj = AddCompilationOptions(proj);
            var compiler = proj.GetCompilationAsync().Result;
            return ReviewDiagnosticMessages(compiler);
        }

        private Project LoadProject(AdhocWorkspace work)
        {
            var solution = work.CurrentSolution;
            var project = solution.Projects.FirstOrDefault(p => p.Name == targetProjectName);
            if (project == null)
            {
                throw new Exception("Could not find empty project");
            }
            return project;
        }

        private static Document SafeAddDocument(Project project, SyntaxTree tree, string documentName)
        {
            var targetDocument = project.Documents.FirstOrDefault(d => d.Name.StartsWith(documentName));
            if (targetDocument != null)
            {
                project = project.RemoveDocument(targetDocument.Id);
            }
            var doc = project.AddDocument(documentName, tree.GetRoot().NormalizeWhitespace());
            return doc;
        }

        private static Project AddCompilationOptions(Project project)
        {
            var options = new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary)
                                .WithOptimizationLevel(OptimizationLevel.Release)
                                .WithPlatform(Platform.AnyCpu);
            project = project.WithCompilationOptions(options)
                             .WithMetadataReferences(DefaultReferences);
            return project;
        }

        private int ReviewDiagnosticMessages(Compilation compiler)
        {
            var results = compiler.GetDiagnostics();
            foreach (var item in results)
            {
                Console.WriteLine(item.GetMessage() + item.Location);
            }
            return results.Length;
        }

        private static IEnumerable<MetadataReference> DefaultReferences = new[]
        {
            MetadataReference.CreateFromFile(typeof(object).GetTypeInfo().Assembly.Location),
            MetadataReference.CreateFromFile(typeof(PreSharedKey).GetTypeInfo().Assembly.Location),
            // MetadataReference.CreateFromFile(typeof(Newtonsoft.Json.JsonException).GetTypeInfo().Assembly.Location),
            MetadataReference.CreateFromFile(typeof(StringEnumConverter).GetTypeInfo().Assembly.Location),
            MetadataReference.CreateFromFile(typeof(RestSharp.Http).GetTypeInfo().Assembly.Location),
            MetadataReference.CreateFromFile(Assembly.Load("Newtonsoft.Json, Version=11.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed").Location),
            MetadataReference.CreateFromFile(Assembly.Load("netstandard, Version=2.0.0.0").Location),
            MetadataReference.CreateFromFile(Assembly.Load("System.Runtime, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a").Location),
            MetadataReference.CreateFromFile(Assembly.Load("System.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a").Location),
            //MetadataReference.CreateFromFile(typeof(Enum).GetTypeInfo().Assembly.Location),
    };
    }
}