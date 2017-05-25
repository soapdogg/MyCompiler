using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens
{
    public class BinaryRelationalOperatorTokenType : BaseTokenType
    {
        public BinaryRelationalOperatorTokenType()
        {
            Pattern = new Regex("^(={2}|>=|>|<=|<|!=)");
        }
    }
}
