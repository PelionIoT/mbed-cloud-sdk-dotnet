using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Manhasset.Core.src.Generators
{
    public static class DocumentationGenerators
    {
        public static DocumentationCommentTriviaSyntax GenerateSummary(string summary)
        {
            return SyntaxFactory.DocumentationCommentTrivia(
                SyntaxKind.SingleLineDocumentationCommentTrivia,
                SyntaxFactory.List<XmlNodeSyntax>(
                    new XmlNodeSyntax[]{
                        SyntaxFactory.XmlText()
                        .WithTextTokens(
                            SyntaxFactory.TokenList(
                                SyntaxFactory.XmlTextLiteral(
                                    SyntaxFactory.TriviaList(
                                        SyntaxFactory.DocumentationCommentExterior("///")),
                                    " ",
                                    " ",
                                    SyntaxFactory.TriviaList()))),
                        SyntaxFactory.XmlExampleElement(
                            SyntaxFactory.SingletonList<XmlNodeSyntax>(
                                SyntaxFactory.XmlText()
                                .WithTextTokens(
                                    SyntaxFactory.TokenList(
                                        new []{
                                            SyntaxFactory.XmlTextNewLine(
                                                SyntaxFactory.TriviaList(),
                                                "\n",
                                                "\n",
                                                SyntaxFactory.TriviaList()),
                                            SyntaxFactory.XmlTextLiteral(
                                                SyntaxFactory.TriviaList(
                                                    SyntaxFactory.DocumentationCommentExterior("///")),
                                                $" {summary}",
                                                $" {summary}",
                                                SyntaxFactory.TriviaList()),
                                            SyntaxFactory.XmlTextNewLine(
                                                SyntaxFactory.TriviaList(),
                                                "\n",
                                                "\n",
                                                SyntaxFactory.TriviaList()),
                                            SyntaxFactory.XmlTextLiteral(
                                                SyntaxFactory.TriviaList(
                                                    SyntaxFactory.DocumentationCommentExterior("///")),
                                                " ",
                                                " ",
                                                SyntaxFactory.TriviaList())}))))
                        .WithStartTag(
                            SyntaxFactory.XmlElementStartTag(
                                SyntaxFactory.XmlName(
                                    SyntaxFactory.Identifier("summary"))))
                        .WithEndTag(
                            SyntaxFactory.XmlElementEndTag(
                                SyntaxFactory.XmlName(
                                    SyntaxFactory.Identifier("summary")))),
                        SyntaxFactory.XmlText()
                        .WithTextTokens(
                            SyntaxFactory.TokenList(
                                SyntaxFactory.XmlTextNewLine(
                                    SyntaxFactory.TriviaList(),
                                    "\n",
                                    "\n",
                                    SyntaxFactory.TriviaList())))}));
        }

        public static DocumentationCommentTriviaSyntax GenerateSummaryAndReturns(string summary, string returns)
        {
            return SyntaxFactory.DocumentationCommentTrivia(
                SyntaxKind.SingleLineDocumentationCommentTrivia,
                SyntaxFactory.List<XmlNodeSyntax>(
                    new XmlNodeSyntax[]{
                        SyntaxFactory.XmlText()
                        .WithTextTokens(
                            SyntaxFactory.TokenList(
                                SyntaxFactory.XmlTextLiteral(
                                    SyntaxFactory.TriviaList(
                                        SyntaxFactory.DocumentationCommentExterior("///")),
                                    " ",
                                    " ",
                                    SyntaxFactory.TriviaList()))),
                        SyntaxFactory.XmlExampleElement(
                            SyntaxFactory.SingletonList<XmlNodeSyntax>(
                                SyntaxFactory.XmlText()
                                .WithTextTokens(
                                    SyntaxFactory.TokenList(
                                        new []{
                                            SyntaxFactory.XmlTextNewLine(
                                                SyntaxFactory.TriviaList(),
                                                "\n",
                                                "\n",
                                                SyntaxFactory.TriviaList()),
                                            SyntaxFactory.XmlTextLiteral(
                                                SyntaxFactory.TriviaList(
                                                    SyntaxFactory.DocumentationCommentExterior("///")),
                                                $" {summary}",
                                                $" {summary}",
                                                SyntaxFactory.TriviaList()),
                                            SyntaxFactory.XmlTextNewLine(
                                                SyntaxFactory.TriviaList(),
                                                "\n",
                                                "\n",
                                                SyntaxFactory.TriviaList()),
                                            SyntaxFactory.XmlTextLiteral(
                                                SyntaxFactory.TriviaList(
                                                    SyntaxFactory.DocumentationCommentExterior("///")),
                                                " ",
                                                " ",
                                                SyntaxFactory.TriviaList())}))))
                        .WithStartTag(
                            SyntaxFactory.XmlElementStartTag(
                                SyntaxFactory.XmlName(
                                    SyntaxFactory.Identifier("summary"))))
                        .WithEndTag(
                            SyntaxFactory.XmlElementEndTag(
                                SyntaxFactory.XmlName(
                                    SyntaxFactory.Identifier("summary")))),
                        SyntaxFactory.XmlText()
                        .WithTextTokens(
                            SyntaxFactory.TokenList(
                                new []{
                                    SyntaxFactory.XmlTextNewLine(
                                        SyntaxFactory.TriviaList(),
                                        "\n",
                                        "\n",
                                        SyntaxFactory.TriviaList()),
                                    SyntaxFactory.XmlTextLiteral(
                                        SyntaxFactory.TriviaList(
                                            SyntaxFactory.DocumentationCommentExterior("///")),
                                        " ",
                                        " ",
                                        SyntaxFactory.TriviaList())})),
                        SyntaxFactory.XmlExampleElement(
                            SyntaxFactory.SingletonList<XmlNodeSyntax>(
                                SyntaxFactory.XmlText()
                                .WithTextTokens(
                                    SyntaxFactory.TokenList(
                                        SyntaxFactory.XmlTextLiteral(
                                            SyntaxFactory.TriviaList(),
                                            returns,
                                            returns,
                                            SyntaxFactory.TriviaList())))))
                        .WithStartTag(
                            SyntaxFactory.XmlElementStartTag(
                                SyntaxFactory.XmlName(
                                    SyntaxFactory.Identifier("returns"))))
                        .WithEndTag(
                            SyntaxFactory.XmlElementEndTag(
                                SyntaxFactory.XmlName(
                                    SyntaxFactory.Identifier("returns")))),
                        SyntaxFactory.XmlText()
                        .WithTextTokens(
                            SyntaxFactory.TokenList(
                                SyntaxFactory.XmlTextNewLine(
                                    SyntaxFactory.TriviaList(),
                                    "\n",
                                    "\n",
                                    SyntaxFactory.TriviaList())))}));
        }
    }
}