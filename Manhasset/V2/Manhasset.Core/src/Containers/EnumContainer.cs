using System.Collections.Generic;
using System.Linq;
using Manhasset.Core.src.Generators;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Manhasset.Core.src.Containers
{
    public class EnumContainer : BaseContainer
    {
        public string FilePath { get; set; }
        public string Namespace { get; set; }
        public List<string> Values { get; set; } = new List<string>();

        public virtual EnumDeclarationSyntax GetSyntax()
        {
            var nodeList = new List<SyntaxNodeOrToken>();

            Values.Select(v =>
            {
                return SyntaxFactory.EnumMemberDeclaration(SyntaxFactory.Identifier(v.ToUpper()));
            })
            .ToList()
            .ForEach(v => {
                nodeList.Add(v);
                nodeList.Add(SyntaxFactory.Token(SyntaxKind.CommaToken));
            });

            return SyntaxFactory.EnumDeclaration(Name)
                                .WithMembers(
                                    SyntaxFactory.SeparatedList<EnumMemberDeclarationSyntax>(nodeList.ToArray()))
                                .AddModifiers(MyModifiers.Values.ToArray());
        }

        public NamespaceDeclarationSyntax GetSyntaxWithNamespace()
        {
            var enumSyntax = GetSyntax();

            var namespaceSyntax = SyntaxFactory.NamespaceDeclaration(SyntaxFactory.ParseName(Namespace));

            namespaceSyntax = namespaceSyntax.AddFileHeader(Name, "Arm");

            namespaceSyntax = namespaceSyntax.AddMembers(enumSyntax);

            return namespaceSyntax;
        }
    }
}