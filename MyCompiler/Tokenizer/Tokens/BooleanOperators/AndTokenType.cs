using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens.BooleanOperators
{
    public class AndTokenType : BaseTokenType
    {
        public AndTokenType()
        {
            Pattern = new Regex("^&&");
        }
    }
}
