using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens.Keywords
{
    public class FloatTokenType : BaseTokenType
    {
        public FloatTokenType()
        {
            Pattern = new Regex("^float");
        }
    }
}
