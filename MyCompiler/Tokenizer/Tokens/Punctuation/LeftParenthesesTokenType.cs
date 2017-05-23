using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens.Punctuation
{
    public class LeftParenthesesTokenType : BaseTokenType
    {
        public LeftParenthesesTokenType()
        {
            Pattern = new Regex("^\\(");
        }
    }
}
