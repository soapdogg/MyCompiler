using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using MyCompiler.Tokenizer.Tokens;
using MyCompiler.Tokenizer.Tokens.Interfaces;

namespace MyCompiler.Tokenizer
{
    public class Tokenizer
    {
        private string[] lines;

        private static readonly IList<ITokenType> definitions;

        static Tokenizer(){
            definitions = new List<ITokenType>
            {
                new BinaryAssignOperatorTokenType(),
                new BinaryAssignTokenType(),
                new BinaryAndOperatorTokenType(),
                new BinaryOrOperatorTokenType(),
                new BinaryOperatorTokenType(),
                new BinaryRelationalOperatorTokenType(),
                new UnaryNotOperatorTokenType(),
                new DoubleTokenType(),
                new DoTokenType(),
                new ElseTokenType(),
                new FloatTokenType(),
                new IfTokenType(),
                new IntTokenType(),
                new LongTokenType(),
                new ReturnTokenType(),
                new VoidTokenType(),
                new WhileTokenType(),
                new PreOrPostOperatorTokenType(),
                new PlusOrMinusTokenType(),
                new BitNegationOperatorTokenType(),
                new LeftBraceTokenType(),
                new LeftBracketTokenType(),
                new LeftParenthesesTokenType(),
                new RightBraceTokenType(),
                new RightBracketTokenType(),
                new RightParenthesesTokenType(),
                new SemicolonTokenType(),
                new FloatingPointConstantTokenType(),
                new IdentifierTokenType(),
                new IntegerConstantTokenType()
            };

        }

        public Tokenizer(params string [] pathArray )
        {
			string path = AppDomain.CurrentDomain.BaseDirectory;
            foreach (string s in pathArray) path += Path.DirectorySeparatorChar + s;
            lines = File.ReadAllLines(path);
        }

        public IList<SimpleCToken> Tokenize()
        {
			var tokens = new List<SimpleCToken>();

            foreach (string line in lines) tokens.AddRange(TokenizeLine(line));

			return tokens;
        }

        public IList<SimpleCToken> Tokenize(params string [] inputText)
        {
            lines = inputText;
            return Tokenize();
        }

        private IList<SimpleCToken> TokenizeLine(string inputText)
        {
            var tokens = new List<SimpleCToken>();
			string remainingText = inputText;

			while (!string.IsNullOrWhiteSpace(remainingText))
			{
				var match = FindMatch(remainingText);

				if (match.IsMatch)
				{
					tokens.Add(new SimpleCToken(match.TokenType, match.Value));
					remainingText = match.RemainingText;
				}
				else
				{
					if (IsWhiteSpace(remainingText))
						remainingText = remainingText.Substring(1);
					else
					{
						var invalidTokenMatch = CreateInvalidTokenMatch(remainingText);
						tokens.Add(new SimpleCToken(invalidTokenMatch.TokenType, invalidTokenMatch.Value));
						remainingText = invalidTokenMatch.RemainingText;
					}
				}
			}
            return tokens;
        }


        private TokenMatch FindMatch(string inputText)
        {
            foreach (var tokenType in definitions)
            {
                var match = tokenType.Match(inputText);
                if (match.IsMatch) return match;
            }
            return new TokenMatch { IsMatch = false }; 
        }

        private static bool IsWhiteSpace(string inputText)
        {
            return Regex.IsMatch(inputText, "^\\s+");
        }

        private static TokenMatch CreateInvalidTokenMatch(string inputText)
        {
            return new TokenMatch
            {
                IsMatch = true,
                RemainingText = inputText.Substring(inputText.Length),
                TokenType = new InvalidTokenType(),
                Value = inputText
            };   
        }
    }
}
