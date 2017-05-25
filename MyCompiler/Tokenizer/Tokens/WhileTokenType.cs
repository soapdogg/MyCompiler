using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens
{
    public class WhileTokenType : BaseTokenType
    {
        public WhileTokenType()
        {
            Pattern = new Regex("^while");
        }
    }
}
