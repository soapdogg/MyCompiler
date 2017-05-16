using System.Text.RegularExpressions;
namespace MyCompiler.Tokenizer.Tokens.NumericOperators
{
    public class PlusPlusTokenType : BaseTokenType
    {
        public PlusPlusTokenType()
        {
            Pattern = new Regex("^\\+\\+");
        }
    }
}
