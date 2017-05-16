using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens.NumericOperators
{
    public class PlusTokenType : BaseTokenType
    {
        public PlusTokenType()
        {
            Pattern = new Regex("^\\+");
        }
    }
}
