using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens
{
    public class LeftBracketTokenType : BaseTokenType
    {
        public LeftBracketTokenType()
        {
            Pattern = new Regex("^\\[");
        }
    }
}
