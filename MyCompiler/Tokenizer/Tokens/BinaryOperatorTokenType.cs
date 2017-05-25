using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens
{
    public class BinaryOperatorTokenType : BaseTokenType
    {
        public BinaryOperatorTokenType()
        {
            Pattern = new Regex("^(/|<<|-|%|\\+|>>|&|\\||\\^|\\*)");
        }
    }
}
