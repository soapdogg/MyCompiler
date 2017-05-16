using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens.NumericOperators
{
    public class MinusTokenType : BaseTokenType
    {
        public MinusTokenType()
        {
            Pattern = new Regex("^-");
        }
    }
}
