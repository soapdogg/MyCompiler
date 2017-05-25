using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens
{
    public class LeftParenthesesTokenType : BaseTokenType
    {
        public LeftParenthesesTokenType()
        {
            Pattern = new Regex("^\\(");
        }
    }
}
