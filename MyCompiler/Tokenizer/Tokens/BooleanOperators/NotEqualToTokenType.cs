using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens.BooleanOperators
{
    public class NotEqualToTokenType : BaseTokenType
    {
        public NotEqualToTokenType()
        {
            Pattern = new Regex("^!=");
        }
    }
}
