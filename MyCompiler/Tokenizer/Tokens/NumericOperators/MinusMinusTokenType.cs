using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens.NumericOperators
{
    public class MinusMinusTokenType : BaseTokenType
    {
        public MinusMinusTokenType()
        {
            Pattern = new Regex("^--");
        }
    }
}
