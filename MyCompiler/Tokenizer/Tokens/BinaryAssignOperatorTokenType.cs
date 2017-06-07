using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens
{
    public class BinaryAssignOperatorTokenType : BaseTokenType
    {
        public override Regex Pattern => new Regex("^((&|/|<<|-|%|\\*|\\||\\+|>>|\\^)=)");
    }
}
