using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens.Punctuation
{
    public class RightBracketTokenType : BaseTokenType
    {
        public RightBracketTokenType()
        {
            Pattern = new Regex("\\]");
        }
    }
}
