using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens
{
    public class RightParenthesesTokenType : BaseTokenType
    {
        public RightParenthesesTokenType()
        {
            Pattern = new Regex("^\\)"); 
        }
    }
}
