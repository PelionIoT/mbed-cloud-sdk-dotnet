using System.Collections.Generic;
using System.Linq;
using Manhasset.Core.src.Common;
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
                return SyntaxFactory.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration)
                                    .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken));
            }
        }

        public virtual AccessorDeclarationSyntax SetAccessorSyntax
        {
            get
            {
                return SyntaxFactory.AccessorDeclaration(SyntaxKind.SetAccessorDeclaration)
                                    .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken));
            }
        }

        public string PropertyType { get; set; }

        public bool IsNullable { get; set; } = false;

        public bool SetAccessor { get; set; } = true;

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