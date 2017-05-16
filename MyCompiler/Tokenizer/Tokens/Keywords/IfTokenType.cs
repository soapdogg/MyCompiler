using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens.Keywords
{
    public class IfTokenType : BaseTokenType
    {
        public IfTokenType()
        {
            Pattern = new Regex("^if");
        }
    }
}
