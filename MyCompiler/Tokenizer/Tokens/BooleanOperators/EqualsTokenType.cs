using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens.BooleanOperators
{
    public class EqualsTokenType : BaseTokenType
    {
        public EqualsTokenType()
        {
            Pattern = new Regex("^==");
        }
    }
}
