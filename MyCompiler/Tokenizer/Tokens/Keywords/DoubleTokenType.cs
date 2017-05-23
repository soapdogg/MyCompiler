using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens.Keywords
{
    public class DoubleTokenType : BaseTokenType
    {
        public DoubleTokenType()
        {
            Pattern = new Regex("^double");
        }
    }
}
