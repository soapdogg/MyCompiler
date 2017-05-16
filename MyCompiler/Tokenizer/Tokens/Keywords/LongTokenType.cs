using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens.Keywords
{
    public class LongTokenType : BaseTokenType
    {
        public LongTokenType()
        {
            Pattern = new Regex("^long");
        }
    }
}
