using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens
{
    public class WhileTokenType : BaseTokenType
    {
        public override Regex Pattern => new Regex("\\bwhile\\b");
    }
}
