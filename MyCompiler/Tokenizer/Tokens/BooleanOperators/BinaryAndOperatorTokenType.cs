using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens.BooleanOperators
{
    public class BinaryAndOperatorTokenType : BaseTokenType
    {
        public BinaryAndOperatorTokenType()
        {
            Pattern = new Regex("&&");
        }
    }
}
