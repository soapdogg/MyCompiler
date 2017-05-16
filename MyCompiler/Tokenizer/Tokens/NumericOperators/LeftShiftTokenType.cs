using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens.NumericOperators
{
    public class LeftShiftTokenType : BaseTokenType
    {
        public LeftShiftTokenType()
        {
            Pattern = new Regex("^<<");
        }
    }
}
