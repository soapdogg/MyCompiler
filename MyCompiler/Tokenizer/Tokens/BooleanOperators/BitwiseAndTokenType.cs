using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens.BooleanOperators
{
    public class BitwiseAndTokenType : BaseTokenType
    {
        public BitwiseAndTokenType()
        {
            Pattern = new Regex("^&");
        }
    }
}
