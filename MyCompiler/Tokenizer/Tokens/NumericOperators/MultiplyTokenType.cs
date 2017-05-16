using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens.NumericOperators
{
    public class MultiplyTokenType : BaseTokenType
    {
        public MultiplyTokenType()
        {
            Pattern = new Regex("^\\*");
        }
    }
}
