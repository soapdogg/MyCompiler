using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens.BooleanOperators
{
    public class BinaryRelationalOperatorTokenType : BaseTokenType
    {
        public BinaryRelationalOperatorTokenType()
        {
            Pattern = new Regex("^==|>=|>|<=|<|!=");
        }
    }
}
