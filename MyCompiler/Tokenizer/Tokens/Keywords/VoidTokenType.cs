using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens.Keywords
{
    public class VoidTokenType : BaseTokenType
    {
        public VoidTokenType()
        {
            Pattern = new Regex("^void");
        }
    }
}
