using System.Text.RegularExpressions;
namespace MyCompiler.Tokenizer.Tokens.BooleanOperators
{
    public class GreaterThanOrEqualTokenType : BaseTokenType
    {
        public GreaterThanOrEqualTokenType()
        {
            Pattern = new Regex("^>=");
        }
    }
}
