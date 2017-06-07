using System.Text.RegularExpressions;

using MyCompiler.Tokenizer.Tokens.Interfaces;

namespace MyCompiler.Tokenizer.Tokens
{
    public abstract class BaseTokenType : ITokenType
    {
        public abstract Regex Pattern { get; }

        public TokenMatch Match(string inputString)
        {
            
            var match =
                Pattern.Match(inputString);
            if (!match.Success) return new TokenMatch {IsMatch = false};
            string remainingText = string.Empty;
            if (match.Length != inputString.Length) remainingText = inputString.Substring(match.Length);
            return new TokenMatch
            {
                IsMatch = true,
                RemainingText = remainingText,
                TokenType = this,
                Value = match.Value
            };
        }
    }
}
