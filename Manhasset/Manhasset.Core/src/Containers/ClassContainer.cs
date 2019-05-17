using System;
using System.Collections.Generic;
using System.Linq;
using Manhasset.Core.src.Common;
using Manhasset.Core.src.Extensions;
using Manhasset.Core.src.Generators;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Manhasset.Core.src.Containers
{
    public class ClassContainer : BaseContainer
    {
        private string filePath;
        public string FileName { get; set; } = "";
        public string FilePath
        {
            get
            {
                return filePath + FileName;
            }
            set
            {
                filePath = value;
            }
        }

        public string Namespace { get; set; }

        public Dictionary<string, string> Usings { get; set; } = new Dictionary<string, string>();

        public Dictionary<string, string> BaseTypes { get; set; } = new Dictionary<string, string>();

        public Dictionary<string, ConstructorContainer> Constructors { get; set; } = new Dictionary<string, ConstructorContainer>();

        public Dictionary<string, PrivateFieldContainer> PrivateFields { get; set; } = new Dictionary<string, PrivateFieldContainer>();

        public Dictionary<string, PropertyContainer> Properties { get; set; } = new Dictionary<string, PropertyContainer>();

        public Dictionary<string, MethodContainer> Methods { get; set; } = new Dictionary<string, MethodContainer>();

        public virtual void AddBaseType(string key, string type)
        {
            BaseTypes.SafeAdd<string, string>(key, type);
        }

        public virtual void AddConstructor(string key, ConstructorContainer constructorContainer)
        {
            Constructors.SafeAdd<string, ConstructorContainer>(key, constructorContainer);
        }

        public virtual void AddUsing(string key, string value)
        {
            Usings.SafeAdd<string, string>(key, value);
        }

        public virtual void AddPrivateField(string key, PrivateFieldContainer container)
        {
            PrivateFields.SafeAdd<string, PrivateFieldContainer>(key, container);
        }

        public virtual void AddProperty(string key, PropertyContainer container)
        {
            Properties.SafeAdd<string, PropertyContainer>(key, container);
        }

        public virtual void AddMethod(string key, MethodContainer container)
        {
            Methods.SafeAdd<string, MethodContainer>(key, container);
        }

        public virtual MemberDeclarationSyntax GetSyntax()
        {
            if (IsInterface)
            {
                return GetInterfaceSyntax();
            }

            return GetClassSyntax();
        }

        private ClassDeclarationSyntax GetClassSyntax()
        {
            // create class
            var classSyntax = SyntaxFactory.ClassDeclaration(Name)
                                .AddModifiers(MyModifiers.Values.ToArray());

            // add base types
            if (BaseTypes.Any())
            {
                classSyntax = classSyntax.AddBaseListTypes(BaseTypes.Values.Select(b => SyntaxFactory.SimpleBaseType(SyntaxFactory.IdentifierName(b))).ToArray());
            }

            // add doc
            classSyntax = classSyntax.AddSummary(DocString) as ClassDeclarationSyntax;

            // add any constructors
            var constructors = Constructors.Values.Select(c => c.GetSyntax()).ToArray();
            classSyntax = classSyntax.AddMembers(constructors);

            // add any private fields
            var privateFields = PrivateFields.Values.Select(p => p.GetSyntax()).ToArray();
            classSyntax = classSyntax.AddMembers(privateFields);

            // add properties
            var properties = Properties.Values.Select(p => p.GetSyntax()).ToArray();
            classSyntax = classSyntax.AddMembers(properties);

            // add methods
            var methods = Methods.Values.Select(m => m.GetSyntax()).ToArray();
            classSyntax = classSyntax.AddMembers(methods);

            return classSyntax;
        }

        private InterfaceDeclarationSyntax GetInterfaceSyntax()
        {
            // TODO for some reason my modifiers seems to be null for the interface. Needs further investigation
            // create interface
            var interfaceSyntax = SyntaxFactory.InterfaceDeclaration(Name).AddModifiers(MyModifiers.Values.ToArray());

            // add doc
            interfaceSyntax = interfaceSyntax.AddSummary(DocString) as InterfaceDeclarationSyntax;

            // add base types
            if (BaseTypes.Any())
            {
                interfaceSyntax = interfaceSyntax.AddBaseListTypes(BaseTypes.Values.Select(b => SyntaxFactory.SimpleBaseType(SyntaxFactory.IdentifierName(b))).ToArray());
            }

            // add properties
            var properties = Properties.Values.Select(c =>
            {
                c.MyModifiers.Clear();
                c.GetAccessorModifier = default(SyntaxToken);
                if (c.SetAccessorModifier.ToString() == "public")
                {
                    c.SetAccessorModifier = default(SyntaxToken);
                }
                else if (c.SetAccessorModifier.ToString() == "private" || c.SetAccessorModifier.ToString() == "internal")
                {
                    c.SetAccessor = false;
                }
                c.IsInterface = true;
                return c.GetSyntax();
            }).ToArray();

            interfaceSyntax = interfaceSyntax.AddMembers(properties);

            // add methods
            var methods = Methods.Values.Select(c =>
            {
                c.MyModifiers.Clear();
                c.IsInterface = true;
                return c.GetSyntax();
            })
            .Select(s =>
            {
                s = s.WithBody(null);
                return s;
            }).ToArray();
            interfaceSyntax = interfaceSyntax.AddMembers(methods);

            return interfaceSyntax;
        }

        public NamespaceDeclarationSyntax GetSyntaxWithNamespace()
        {
            var classSyntax = GetSyntax();
            return GetSyntaxWithNamespaceCore(classSyntax);
        }

        private NamespaceDeclarationSyntax GetSyntaxWithNamespaceCore(MemberDeclarationSyntax syntax)
        {
            var namespaceSyntax = SyntaxFactory.NamespaceDeclaration(SyntaxFactory.ParseName(Namespace));

            var usingsSyntax = Usings.Values.Select(u => SyntaxFactory.UsingDirective(SyntaxFactory.ParseName(u))).ToArray();
            namespaceSyntax = namespaceSyntax.AddUsings(usingsSyntax);

            namespaceSyntax = namespaceSyntax.AddFileHeader(Name, "Arm");

            namespaceSyntax = namespaceSyntax.AddMembers(syntax);

            return namespaceSyntax;
        }
    }
}