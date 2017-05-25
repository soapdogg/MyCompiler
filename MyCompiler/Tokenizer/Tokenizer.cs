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
        string[] lines;

        static IList<ITokenType> definitions;

        static Tokenizer(){
            definitions = new List<ITokenType>();
            definitions.Add(new BinaryAssignOperatorTokenType());
            definitions.Add(new BinaryAssignTokenType());
            definitions.Add(new BinaryAndOperatorTokenType());
            definitions.Add(new BinaryOrOperatorTokenType());
            definitions.Add(new BinaryRelationalOperatorTokenType());
            definitions.Add(new UnaryNotOperatorTokenType());
            definitions.Add(new DoubleTokenType());
            definitions.Add(new DoTokenType());
            definitions.Add(new ElseTokenType());
            definitions.Add(new FloatTokenType());
            definitions.Add(new IfTokenType());
            definitions.Add(new IntTokenType());
            definitions.Add(new LongTokenType());
            definitions.Add(new ReturnTokenType());
            definitions.Add(new VoidTokenType());
            definitions.Add(new WhileTokenType());
            definitions.Add(new PreOrPostOperatorTokenType());
            definitions.Add(new BinaryOperatorTokenType());

            definitions.Add(new UnaryOperatorTokenType());
            definitions.Add(new LeftBraceTokenType());
            definitions.Add(new LeftBracketTokenType());
            definitions.Add(new LeftParenthesesTokenType());
            definitions.Add(new RightBraceTokenType());
            definitions.Add(new RightBracketTokenType());
            definitions.Add(new RightParenthesesTokenType());
            definitions.Add(new SemicolonTokenType());
            definitions.Add(new FloatingPointConstantTokenType());
            definitions.Add(new IdentifierTokenType());
            definitions.Add(new IntegerConstantTokenType());
        }

        public Tokenizer()
        {
            
        }

        public Tokenizer(string [] pathArray)
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

        public IList<SimpleCToken> Tokenize(string inputText)
        {
            lines = new string[] { inputText };
            return Tokenize();
        }

        public IList<SimpleCToken> Tokenize(string [] inputText)
        {
            lines = inputText;
            return Tokenize();
        }

        IList<SimpleCToken> TokenizeLine(string inputText)
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


        TokenMatch FindMatch(string inputText)
        {
            foreach (var tokenType in definitions)
            {
                var match = tokenType.Match(inputText);
                if (match.IsMatch) return match;
            }
            return new TokenMatch() { IsMatch = false }; 
        }

        bool IsWhiteSpace(string inputText)
        {
            return Regex.IsMatch(inputText, "^\\s+");
        }

        TokenMatch CreateInvalidTokenMatch(string inputText)
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
