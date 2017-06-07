using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens
{
    public class BinaryOperatorTokenType : BaseTokenType
    {
        public override Regex Pattern => new Regex("^(/|<<|-|%|\\+|>>|&|\\||\\^|\\*)");
    }
}
