using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens.BooleanOperators
{
    public class GreaterThanTokenType : BaseTokenType
    {
        public GreaterThanTokenType()
        {
            Pattern = new Regex("^>");
        }
    }
}
