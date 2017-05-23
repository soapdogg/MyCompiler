using System.Collections.Generic;
using System.Text.RegularExpressions;

using MyCompiler.Tokenizer.Tokens;

namespace MyCompiler.Tokenizer
{
    public class Tokenizer
    {
        private static IList<ITokenType> definitions;

        static Tokenizer(){

        }

        public Tokenizer()
        {
        }

        public IList<SimpleCToken> Tokenize(string inputText)
        {
            var tokens = new List<SimpleCToken>();

            string remainingText = inputText;

            while(!string.IsNullOrWhiteSpace(remainingText))
            {
                var match = FindMatch(remainingText);

                if(match.IsMatch)
                {
                    tokens.Add(new SimpleCToken(match.TokenType, match.Value));
                    remainingText = match.RemainingText;
                }
                else
                {
                    if (IsWhiteSpace(remainingText)) remainingText = remainingText.Substring(1);
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
            return new TokenMatch() { IsMatch = false }; 
        }

        private bool IsWhiteSpace(string inputText)
        {
            return Regex.IsMatch(inputText, "^\\s+");
        }

        private TokenMatch CreateInvalidTokenMatch(string inputText)
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
