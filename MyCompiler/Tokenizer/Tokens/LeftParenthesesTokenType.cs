using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens
{
    public class LeftParenthesesTokenType : BaseTokenType
    {
        public override Regex Pattern => new Regex("^\\(");
    }
}
