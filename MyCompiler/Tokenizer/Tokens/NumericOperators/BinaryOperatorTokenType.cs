using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens.NumericOperators
{
    public class BinaryOperatorTokenType : BaseTokenType
    {
        public BinaryOperatorTokenType()
        {
            Pattern = new Regex("^(/|<<|-|%|\\+|>>|&|\\||\\^|\\*)");
        }
    }
}
