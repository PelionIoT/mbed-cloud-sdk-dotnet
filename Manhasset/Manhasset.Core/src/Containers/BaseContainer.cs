using System;
using System.Collections.Generic;
using Manhasset.Core.src.Common;
using Manhasset.Core.src.Extensions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Manhasset.Core.src.Containers
{
    public abstract class BaseContainer
    {
        public Dictionary<string, SyntaxToken> MyModifiers { get; set; } = new Dictionary<string, SyntaxToken>();

        public string Name { get; set; }

        public string DocString { get; set; }

        public bool IsInterface { get; set; } = false;

        public void AddModifier(string key, SyntaxToken modifier)
        {
            MyModifiers.SafeAdd<string, SyntaxToken>(key, modifier);
        }

        protected ArgumentSyntax GetLiteralArg(string identifier, string literal)
        {
            return SyntaxFactory.Argument(
                        SyntaxFactory.LiteralExpression(
                            SyntaxKind.StringLiteralExpression,
                            SyntaxFactory.Literal(literal)))
                    .WithNameColon(
                        SyntaxFactory.NameColon(
                            SyntaxFactory.IdentifierName(identifier)));
        }

        protected ArgumentSyntax GetVariableArg(string identifier, string name)
        {
            return SyntaxFactory.Argument(
                        SyntaxFactory.IdentifierName(identifier))
                    .WithNameColon(
                        SyntaxFactory.NameColon(
                            SyntaxFactory.IdentifierName(name)));
        }

        protected ArgumentSyntax GetMemberAccessArg(string identifier, string member, string value)
        {
            return SyntaxFactory.Argument(
                    SyntaxFactory.MemberAccessExpression(
                        SyntaxKind.SimpleMemberAccessExpression,
                        SyntaxFactory.IdentifierName(member),
                        SyntaxFactory.IdentifierName(value)))
                .WithNameColon(
                    SyntaxFactory.NameColon(
                        SyntaxFactory.IdentifierName(identifier)));
        }

        protected ArgumentSyntax GetThisArg(string identifier)
        {
            return SyntaxFactory.Argument(
                    SyntaxFactory.ThisExpression())
                .WithNameColon(
                    SyntaxFactory.NameColon(
                        SyntaxFactory.IdentifierName(identifier)));
        }
    }
}