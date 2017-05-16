using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens.NumericOperators
{
    public class DivideTokenType : BaseTokenType
    {
        public DivideTokenType()
        {
            Pattern = new Regex("^/");
        }
    }
}
