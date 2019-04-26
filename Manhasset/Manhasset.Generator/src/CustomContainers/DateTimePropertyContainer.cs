using Manhasset.Core.src.Generators;
using Manhasset.Generator.src.common;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Manhasset.Generator.src.CustomContainers
{
    public class DateTimePropertyContainer : PropertyWithSummaryContainer
    {
        public string DateFormat { get; set; }

        public override PropertyDeclarationSyntax GetSyntax()
        {
            var format = DateFormat == "date" ? TypeHelpers.PythonDateFormatString : TypeHelpers.DateTimeFormatString;

            var syntax = base.GetSyntax();

            return syntax.WithAttributeLists(
                    SyntaxFactory.SingletonList<AttributeListSyntax>(
                        SyntaxFactory.AttributeList(
                            SyntaxFactory.SingletonSeparatedList<AttributeSyntax>(
                                SyntaxFactory.Attribute(
                                    SyntaxFactory.IdentifierName("JsonConverter"))
                                .WithArgumentList(
                                    SyntaxFactory.AttributeArgumentList(
                                        SyntaxFactory.SeparatedList<AttributeArgumentSyntax>(
                                            new SyntaxNodeOrToken[]{
                                                SyntaxFactory.AttributeArgument(
                                                    SyntaxFactory.TypeOfExpression(
                                                        SyntaxFactory.IdentifierName("CustomDateConverter"))),
                                                SyntaxFactory.Token(SyntaxKind.CommaToken),
                                                SyntaxFactory.AttributeArgument(
                                                    SyntaxFactory.LiteralExpression(
                                                        SyntaxKind.StringLiteralExpression,
                                                        SyntaxFactory.Literal(format)))})))))));
        }
    }
}