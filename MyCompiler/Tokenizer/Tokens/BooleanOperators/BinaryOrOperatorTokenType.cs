using System.Text.RegularExpressions;
namespace MyCompiler.Tokenizer.Tokens.BooleanOperators
{
    public class BinaryOrOperatorTokenType : BaseTokenType
    {
        public BinaryOrOperatorTokenType()
        {
            Pattern = new Regex("\\|\\|");
        }
    }
}
