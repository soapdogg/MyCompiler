using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens
{
    public class BinaryAssignOperatorTokenType : BaseTokenType
    {
        public BinaryAssignOperatorTokenType()
        {
            Pattern = new Regex("^((&|/|<<|-|%|\\*|\\|\\||\\+|>>|\\^)=)");
        }
    }
}
