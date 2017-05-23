using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens.Punctuation
{
    public class RightParenthesesTokenType : BaseTokenType
    {
        public RightParenthesesTokenType()
        {
            Pattern = new Regex("^\\)"); 
        }
    }
}
