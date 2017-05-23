using System.Text.RegularExpressions;
namespace MyCompiler.Tokenizer.Tokens.BooleanOperators
{
    public class UnaryNotOperatorTokenType : BaseTokenType
    {
        public UnaryNotOperatorTokenType()
        {
            Pattern = new Regex("^!");
        }
    }
}
