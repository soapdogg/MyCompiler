using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens
{
    public class IfTokenType : BaseTokenType
    {
        public IfTokenType()
        {
            Pattern = new Regex("^if");
        }
    }
}
