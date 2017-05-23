using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens.NumericOperators
{
    public class PreOrPostOperatorTokenType : BaseTokenType
    {
        public PreOrPostOperatorTokenType()
        {
            Pattern = new Regex("\\+\\+|--");
        }
    }
}
