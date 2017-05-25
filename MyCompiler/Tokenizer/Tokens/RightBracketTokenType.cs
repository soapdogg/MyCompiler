using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens
{
    public class RightBracketTokenType : BaseTokenType
    {
        public RightBracketTokenType()
        {
            Pattern = new Regex("^\\]");
        }
    }
}
