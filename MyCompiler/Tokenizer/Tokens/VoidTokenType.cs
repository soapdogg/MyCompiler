using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens
{
    public class VoidTokenType : BaseTokenType
    {
        public VoidTokenType()
        {
            Pattern = new Regex("^void");
        }
    }
}
