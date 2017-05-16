using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens.BooleanOperators
{
    public class BitwiseXorTokenType : BaseTokenType
    {
        public BitwiseXorTokenType()
        {
            Pattern = new Regex("^\\^");
        }
    }
}
