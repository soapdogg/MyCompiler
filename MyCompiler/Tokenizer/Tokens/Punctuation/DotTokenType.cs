using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens.Punctuation
{
    public class DotTokenType : BaseTokenType
    {
        public DotTokenType() 
        {
            Pattern = new Regex("\\.");
        }
    }
}
