using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens
{
    public class IntTokenType : BaseTokenType
    {
        public IntTokenType()
        {
            Pattern = new Regex("^int");
        }
    }
}
