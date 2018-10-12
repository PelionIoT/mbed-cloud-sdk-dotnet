using System.Collections.Generic;
using Manhasset.Core.src.Common;
using Manhasset.Core.src.Extensions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Manhasset.Core.src.Containers
{
    public abstract class BaseContainer
    {
        public Dictionary<string, SyntaxToken> MyModifiers { get; set; } = new Dictionary<string, SyntaxToken>();

        public string Name { get; set; }

        public string DocString { get; set; }

        public void AddModifier(string key, SyntaxToken modifier)
        {
            MyModifiers.SafeAdd<string, SyntaxToken>(key, modifier);
        }
    }
}