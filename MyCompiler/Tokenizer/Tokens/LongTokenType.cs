using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens
{
    public class LongTokenType : BaseTokenType
    {
        public LongTokenType()
        {
            Pattern = new Regex("^long");
        }
    }
}
