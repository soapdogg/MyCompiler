using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens.Punctuation
{
    public class LeftBracketTokenType : BaseTokenType
    {
        public LeftBracketTokenType()
        {
            Pattern = new Regex("\\[");
        }
    }
}
