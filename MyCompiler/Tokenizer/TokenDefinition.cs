using System.Text.RegularExpressions;
using MyCompiler.Tokenizer.Tokens;

namespace MyCompiler.Tokenizer
{
    public class TokenDefinition
    {
        private readonly Regex pattern;
        private readonly ITokenType tokenType;

        public TokenDefinition(ITokenType tokenType, string regexPattern)
        {
            pattern = new Regex(regexPattern);
            this.tokenType = tokenType;
        }

        public TokenMatch Match(string inputString)
        {
            var match = pattern.Match(inputString);
            if (match.Success)
            {
                string remainingText = string.Empty;
                if (match.Length != inputString.Length) remainingText = inputString.Substring(match.Length);
                return new TokenMatch
                {
                    IsMatch = true,
                    RemainingText = remainingText,
                    TokenType = tokenType,
                    Value = match.Value
                };
            }
            return new TokenMatch { IsMatch = false };  
        }
    }
}
