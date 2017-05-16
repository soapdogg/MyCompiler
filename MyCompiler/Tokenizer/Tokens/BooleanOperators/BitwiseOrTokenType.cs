using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens.BooleanOperators
{
    public class BitwiseOrTokenType : BaseTokenType
    {
        public BitwiseOrTokenType()
        {
            Pattern = new Regex("^|");
        }
    }
}
