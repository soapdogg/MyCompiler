using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens
{
    public abstract class BaseTokenType : ITokenType
    {
        public Regex Pattern { get; protected set; }

        public TokenMatch Match(string inputString)
        {
			var match = Pattern.Match(inputString);
			if (match.Success)
			{
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
			return new TokenMatch { IsMatch = false };
		}
    }
}
