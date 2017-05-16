using System.Text.RegularExpressions;
namespace MyCompiler.Tokenizer.Tokens.BooleanOperators
{
    public class LessThanTokenType : BaseTokenType
    {
        public LessThanTokenType()
        {
            Pattern = new Regex("^>");
        }
    }
}
