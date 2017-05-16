using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens.BooleanOperators
{
    public class LessThanOrEqualTokenType : BaseTokenType
    {
        public LessThanOrEqualTokenType()
        {
            Pattern = new Regex("^<=");
        }
    }
}
