using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Manhasset.Core.src.Generators
{
    public static class CommonGenerators
    {
        public static SyntaxNode AddSummary(this SyntaxNode me, string summary)
        {
            var documentation = DocumentationGenerators.GenerateSummary(summary);

            return InsertTriviaAtStart(me, documentation);
        }

        public static SyntaxNode AddSummaryAndReturns(this SyntaxNode me, string summary, string returns)
        {
            var documentation = DocumentationGenerators.GenerateSummaryAndReturns(summary, returns);

            return InsertTriviaAtStart(me, documentation);
        }

        private static SyntaxNode InsertTriviaAtStart(SyntaxNode me, DocumentationCommentTriviaSyntax documentation)
        {
            if (me.GetLeadingTrivia().Any())
            {
                return me.InsertTriviaBefore(me.GetLeadingTrivia().First(), SyntaxFactory.TriviaList(SyntaxFactory.Trivia(documentation)));
            }

            return me.WithLeadingTrivia(SyntaxFactory.TriviaList(SyntaxFactory.Trivia(documentation)));
        }
    }
}