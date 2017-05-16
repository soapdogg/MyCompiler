using System.Text.RegularExpressions;
namespace MyCompiler.Tokenizer.Tokens.NumericOperators
{
    public class RightShiftTokenType : BaseTokenType
    {
        public RightShiftTokenType()
        {
            Pattern = new Regex("^>>");
        }
    }
}
