using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens.AssignmentOperators
{
    public class BinaryAssignOperatorTokenType : BaseTokenType
    {
        public BinaryAssignOperatorTokenType()
        {
            Pattern = new Regex("(&|/|<<|-|%|\\*|\\|\\||\\+|>>|\\^)=");
        }
    }
}
