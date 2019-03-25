using System.Collections.Generic;
using System.Linq;
using Manhasset.Core.src.Common;
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
        public List<EnumItem> Values { get; set; } = new List<EnumItem>();

        public virtual EnumDeclarationSyntax GetSyntax()
        {
            var nodeList = new List<SyntaxNodeOrToken>();

            Values.Select(v =>
            {
                return SyntaxFactory.EnumMemberDeclaration(SyntaxFactory.Identifier(v.EnumValue))
                .WithAttributeLists(
                        SyntaxFactory.SingletonList<AttributeListSyntax>(
                            SyntaxFactory.AttributeList(
                                SyntaxFactory.SingletonSeparatedList<AttributeSyntax>(
                                    SyntaxFactory.Attribute(
                                        SyntaxFactory.IdentifierName("EnumMember"))
                                    .WithArgumentList(
                                        SyntaxFactory.AttributeArgumentList(
                                            SyntaxFactory.SingletonSeparatedList<AttributeArgumentSyntax>(
                                                SyntaxFactory.AttributeArgument(
                                                    SyntaxFactory.LiteralExpression(
                                                        SyntaxKind.StringLiteralExpression,
                                                        SyntaxFactory.Literal(v.ApiValue ?? "UNKNOWN_ENUM_VALUE_RECEIVED")))
                                                .WithNameEquals(
                                                    SyntaxFactory.NameEquals(
                                                        SyntaxFactory.IdentifierName("Value"))))))))));
            })
            .ToList()
            .ForEach(v =>
            {
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

            namespaceSyntax = namespaceSyntax.AddUsings(SyntaxFactory.UsingDirective(
                    SyntaxFactory.QualifiedName(
                        SyntaxFactory.QualifiedName(
                            SyntaxFactory.IdentifierName("System"),
                            SyntaxFactory.IdentifierName("Runtime")),
                        SyntaxFactory.IdentifierName("Serialization"))));

            return namespaceSyntax;
        }
    }
}