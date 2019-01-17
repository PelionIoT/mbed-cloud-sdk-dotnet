using System.Collections.Generic;
using System.Linq;
using Manhasset.Core.src.Common;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Manhasset.Core.src.Containers
{
    public class PropertyContainer : BaseContainer
    {
        public virtual AccessorDeclarationSyntax GetAccessorSyntax
        {
            get
            {
                var accessor = SyntaxFactory.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration)
                                    .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken));
                return GetAccessorModifier != Modifiers.PUBLIC ? accessor.WithModifiers(SyntaxFactory.TokenList(GetAccessorModifier)) : accessor;
            }
        }

        public virtual AccessorDeclarationSyntax SetAccessorSyntax
        {
            get
            {
                var accessor = SyntaxFactory.AccessorDeclaration(SyntaxKind.SetAccessorDeclaration)
                                    .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken));
                return SetAccessorModifier != Modifiers.PUBLIC ? accessor.WithModifiers(SyntaxFactory.TokenList(SetAccessorModifier)) : accessor;
            }
        }

        public string PropertyType { get; set; }

        public bool IsNullable { get; set; } = false;

        public bool SetAccessor { get; set; } = true;

        public SyntaxToken SetAccessorModifier { get; set; } = Modifiers.PUBLIC;
        public SyntaxToken GetAccessorModifier { get; set; } = Modifiers.PUBLIC;

        public bool GetAccessor { get; set; } = true;

        public Dictionary<string, string> Attributes { get; set; } = new Dictionary<string, string>();

        public virtual PropertyDeclarationSyntax GetSyntax()
        {
            // get the typa as a TypeSyntax
            var type = SyntaxFactory.ParseTypeName(PropertyType);

            type = IsNullable ? SyntaxFactory.NullableType(type) : type;

            // create property with name, type and correct modifiers
            var syntax = SyntaxFactory.PropertyDeclaration(type, Name)
                                .AddModifiers(MyModifiers.Values.ToArray());

            // add a get accessor
            if (GetAccessor)
            {
                syntax = syntax.AddAccessorListAccessors(GetAccessorSyntax);
            }

            // add a set accessor
            if (SetAccessor)
            {
                syntax = syntax.AddAccessorListAccessors(SetAccessorSyntax);
            }

            return syntax;
        }
    }
}