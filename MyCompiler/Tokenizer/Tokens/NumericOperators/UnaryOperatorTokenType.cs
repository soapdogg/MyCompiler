using System.Text.RegularExpressions;
namespace MyCompiler.Tokenizer.Tokens.NumericOperators
{
    public class UnaryOperatorTokenType : BaseTokenType
    {
        public UnaryOperatorTokenType()
        {
            Pattern = new Regex("^\\+|-|~");
        }
    }
}
