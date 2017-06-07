using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens
{
    public class BinaryRelationalOperatorTokenType : BaseTokenType
    {
        public override Regex Pattern => new Regex("^(={2}|>=|>|<=|<|!=)");
    }
}
