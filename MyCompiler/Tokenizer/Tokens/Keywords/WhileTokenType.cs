using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens.Keywords
{
    public class WhileTokenType : BaseTokenType
    {
        public WhileTokenType()
        {
            Pattern = new Regex("^while");
        }
    }
}
